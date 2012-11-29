﻿using System;
using System.Collections.Generic;
using Fleck;

namespace DeviceHive.WebSockets.Network
{
	public abstract class WebSocketServerBase
	{
		private readonly IDictionary<Guid, WebSocketConnectionBase> _connections =
			new Dictionary<Guid, WebSocketConnectionBase>();

		protected void RegisterConnection(WebSocketConnectionBase connection)
		{
			_connections[connection.Identity] = connection;
		}

		protected void UnregisterConnection(Guid connectionIdentity)
		{
			_connections.Remove(connectionIdentity);
		}

		public abstract void Start(string url);

		public abstract void Stop();

		public event EventHandler<WebSocketMessageEventArgs> MessageReceived;

		protected void OnMessageReceived(WebSocketMessageEventArgs e)
		{
			var handler = MessageReceived;
			if (handler != null)
				handler(this, e);
		}

		public IEnumerable<WebSocketConnectionBase> GetAllConnections()
		{
			return _connections.Values;
		}

		public WebSocketConnectionBase GetConnection(Guid identity)
		{
			WebSocketConnectionBase connection;
			return _connections.TryGetValue(identity, out connection) ? connection : null;
		}
	}

	public class FleckWebSocketServer : WebSocketServerBase
	{
		private WebSocketServer _webSocketServer;

		public override void Start(string url)
		{
			_webSocketServer = new WebSocketServer(url);
			_webSocketServer.Start(c =>
			{
				c.OnOpen = () => RegisterConnection(new FleckWebSocketConnection(c));
				c.OnClose = () => UnregisterConnection(c.ConnectionInfo.Id);
				
				c.OnMessage = msg =>
				{
					var fc = GetConnection(c.ConnectionInfo.Id);
					var e = new WebSocketMessageEventArgs(fc, msg);
					OnMessageReceived(e);
				};
			});
		}

		public override void Stop()
		{
			_webSocketServer.Dispose();
		}
	}
}