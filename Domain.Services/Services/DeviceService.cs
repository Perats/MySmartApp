using Domain.Interface.Interface;
using Domain.Interface.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Services
{
    public class DeviceService : IDeviceInterface
    {
        public void AddNewDevice(DeviceServiceModel device, int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteDevice(int userId, int deviceId)
        {
            throw new NotImplementedException();
        }

        public List<DeviceServiceModel> GetDevices(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
