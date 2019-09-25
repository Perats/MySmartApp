using Domain.Interface.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface.Interface
{
    public interface IDeviceInterface
    {
        List<DeviceServiceModel> GetDevices(int userId);
        void AddNewDevice(DeviceServiceModel device, int userId);
        void DeleteDevice(int userId, int deviceId);
    }
}
