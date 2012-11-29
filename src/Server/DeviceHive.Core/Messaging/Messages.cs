using System;

namespace DeviceHive.Core.Messaging
{
	public class DeviceCommandAddedMessage
	{
		public DeviceCommandAddedMessage()
		{
		}

		public DeviceCommandAddedMessage(Guid deviceGuid, int commandId)
		{
			DeviceGuid = deviceGuid;
			CommandId = commandId;
		}

		public Guid DeviceGuid { get; set; }

		public int CommandId { get; set; }
	}

	public class DeviceNotificationAddedMessage
	{
		public DeviceNotificationAddedMessage()
		{
		}

		public DeviceNotificationAddedMessage(Guid deviceGuid, int notificationId)
		{
			DeviceGuid = deviceGuid;
			NotificationId = notificationId;
		}

		public Guid DeviceGuid { get; set; }

		public int NotificationId { get; set; }
	}
}