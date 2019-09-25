using DI.Interface;
using Domain.Interface.Interface;
using Domain.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace DI.Moduls
{
    public class DomainModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IDeviceInterface, DeviceService>(new HierarchicalLifetimeManager());
        }
    }
}
