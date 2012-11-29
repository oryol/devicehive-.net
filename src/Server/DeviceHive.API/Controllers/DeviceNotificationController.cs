﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeviceHive.API.Business;
using DeviceHive.API.Filters;
using DeviceHive.API.Mapping;
using DeviceHive.Core.Messaging;
using DeviceHive.Data.Model;
using Newtonsoft.Json.Linq;
using Ninject;

namespace DeviceHive.API.Controllers
{
    /// <resource cref="DeviceNotification" />
    public class DeviceNotificationController : BaseController
    {
        private ObjectWaiter<DeviceNotification> _notificationWaiter;
        private INotificationManager _notificationManager;
        private readonly MessageBus _messageBus;

        public DeviceNotificationController(ObjectWaiter<DeviceNotification> notificationWaiter,
            INotificationManager notificationManager, MessageBus messageBus)
        {
            _notificationWaiter = notificationWaiter;
            _notificationManager = notificationManager;
            _messageBus = messageBus;
        }

        /// <name>query</name>
        /// <summary>
        /// Queries device notifications.
        /// </summary>
        /// <param name="deviceGuid">Device unique identifier.</param>
        /// <param name="start">Notification start date (inclusive, UTC).</param>
        /// <param name="end">Notification end date (inclusive, UTC)</param>
        /// <returns cref="DeviceNotification">If successful, this method returns array of <see cref="DeviceNotification"/> resources in the response body.</returns>
        [AuthorizeUser]
        public JToken Get(Guid deviceGuid, DateTime? start = null, DateTime? end = null)
        {
            var device = DataContext.Device.Get(deviceGuid);
            if (device == null || !IsNetworkAccessible(device.NetworkID))
                ThrowHttpResponse(HttpStatusCode.NotFound, "Device not found!");

            return new JArray(DataContext.DeviceNotification.GetByDevice(device.ID, start, end).Select(n => Mapper.Map(n)));
        }

        /// <name>get</name>
        /// <summary>
        /// Gets information about device notification.
        /// </summary>
        /// <param name="deviceGuid">Device unique identifier.</param>
        /// <param name="id">Notification identifier.</param>
        /// <returns cref="DeviceNotification">If successful, this method returns a <see cref="DeviceNotification"/> resource in the response body.</returns>
        [AuthorizeUser]
        public JObject Get(Guid deviceGuid, int id)
        {
            var device = DataContext.Device.Get(deviceGuid);
            if (device == null || !IsNetworkAccessible(device.NetworkID))
                ThrowHttpResponse(HttpStatusCode.NotFound, "Device not found!");

            var notification = DataContext.DeviceNotification.Get(id);
            if (notification == null || notification.DeviceID != device.ID)
                ThrowHttpResponse(HttpStatusCode.NotFound, "Device notification not found!");

            return Mapper.Map(notification);
        }

        /// <name>insert</name>
        /// <summary>
        /// Creates new device notification.
        /// </summary>
        /// <param name="deviceGuid">Device unique identifier.</param>
        /// <param name="json" cref="DeviceNotification">In the request body, supply a <see cref="DeviceNotification"/> resource.</param>
        /// <returns cref="DeviceNotification">If successful, this method returns a <see cref="DeviceNotification"/> resource in the response body.</returns>
        [HttpCreatedResponse]
        [AuthorizeDeviceOrUser(Roles = "Administrator")]
        public JObject Post(Guid deviceGuid, JObject json)
        {
            EnsureDeviceAccess(deviceGuid);

            var device = DataContext.Device.Get(deviceGuid);
            if (device == null || !IsNetworkAccessible(device.NetworkID))
                ThrowHttpResponse(HttpStatusCode.NotFound, "Device not found!");

            var notification = Mapper.Map(json);
            notification.Device = device;
            Validate(notification);

            DataContext.DeviceNotification.Save(notification);
            _notificationManager.ProcessNotification(notification);
            _notificationWaiter.NotifyChanges(device.ID);
            _messageBus.Notify(new DeviceNotificationAddedMessage(deviceGuid, notification.ID));
            return Mapper.Map(notification);
        }

        private IJsonMapper<DeviceNotification> Mapper
        {
            get { return GetMapper<DeviceNotification>(); }
        }
    }
}