using PlyTracker.Core.Entities;
using System;

namespace PlyTracker.Core.Attributes
{
    public sealed class ServiceAttribute : Attribute
    {
        public ServiceAttribute(ServiceType serviceType = ServiceType.SINGLETON)
        {
            ServiceType = serviceType;
        }

        public ServiceType ServiceType { get; private set; }
    }
}
