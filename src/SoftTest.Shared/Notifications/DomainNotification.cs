﻿using MediatR;
using System;

namespace SoftTest.Shared.Notifications
{
    public class DomainNotification : INotification
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;            
        }
    }
}