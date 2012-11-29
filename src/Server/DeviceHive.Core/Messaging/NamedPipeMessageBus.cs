using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace DeviceHive.Core.Messaging
{
	public class NamedPipeMessageBus : MessageBus, IDisposable
	{
		private readonly string _pipeName;
		private readonly Thread _readThread;
		private volatile bool _stopReading = false;

		public NamedPipeMessageBus(string pipeName)
		{
			_pipeName = pipeName;

			_readThread = new Thread(ReadData);
			_readThread.Start();
		}

		public NamedPipeMessageBus() : this("DeviceHive")
		{			
		}

		protected override void SendMessage(byte[] data)
		{			
			var serversNotified = 0;

			while (true)
			{
				using (var namedPipeClient = new NamedPipeClientStream(_pipeName))
				{
					namedPipeClient.Connect();
					namedPipeClient.Write(data, 0, data.Length);

					if (++serversNotified >= namedPipeClient.NumberOfServerInstances)
						break;
				}
			}
		}

		private void ReadData()
		{
			using (var namedPipeServer = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, -1))
			{
				while (true)
				{
					if (_stopReading)
						return;

					ReadMessage(namedPipeServer);
				}
			}
		}

		private void ReadMessage(NamedPipeServerStream namedPipeServer)
		{
			namedPipeServer.WaitForConnection();

			byte[] data;
			
			using (var ms = new MemoryStream())
			{
				var buffer = new byte[256 * 1024];

				int bytesRead;
				while ((bytesRead = namedPipeServer.Read(buffer, 0, buffer.Length)) > 0)
					ms.Write(buffer, 0, bytesRead);

				data = ms.ToArray();
			}

			namedPipeServer.Disconnect();

			HandleMessage(data);
		}

		public void Dispose()
		{
			if (_readThread != null && _readThread.IsAlive)
			{
				_stopReading = true;
				_readThread.Join();
			}
		}
	}
}