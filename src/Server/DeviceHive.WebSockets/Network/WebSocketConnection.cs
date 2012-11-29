﻿using System;
using Fleck;

namespace DeviceHive.WebSockets.Network
{
	public abstract class WebSocketConnectionBase : IEquatable<WebSocketConnectionBase>
	{
		private readonly SessionContext _sessionContext = new SessionContext();

		public abstract Guid Identity { get; }

		public abstract string Path { get; }

		public abstract void Send(string message);

		public SessionContext Session
		{
			get { return _sessionContext; }
		}

		public bool Equals(WebSocketConnectionBase other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Identity.Equals(other.Identity);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((WebSocketConnectionBase) obj);
		}

		public override int GetHashCode()
		{
			return Identity.GetHashCode();
		}

		public static bool operator ==(WebSocketConnectionBase left, WebSocketConnectionBase right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(WebSocketConnectionBase left, WebSocketConnectionBase right)
		{
			return !Equals(left, right);
		}
	}

	public class FleckWebSocketConnection : WebSocketConnectionBase
	{
		private readonly IWebSocketConnection _fleckConnection;

		public FleckWebSocketConnection(IWebSocketConnection fleckConnection)
		{
			_fleckConnection = fleckConnection;
		}

		#region Overrides of WebSocketConnectionBase

		public override Guid Identity
		{
			get { return _fleckConnection.ConnectionInfo.Id; }
		}

		public override string Path
		{
			get { return _fleckConnection.ConnectionInfo.Path; }
		}

		public override void Send(string message)
		{
			_fleckConnection.Send(message);
		}

		#endregion
	}
}