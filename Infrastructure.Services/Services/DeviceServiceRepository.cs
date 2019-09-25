using Infrastructure.Interface.Interface;
using Infrastructure.Interface.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services.Services
{
    public class DeviceServiceRepository : IDeviceRepository
    {
        public void AddNewDevice(DevicesInfrastructureModel device, int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteDevice(int userId, int deviceId)
        {
            throw new NotImplementedException();
        }

        public List<DevicesInfrastructureModel> GetDevices(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
