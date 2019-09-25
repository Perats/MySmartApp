using Infrastructure.Interface.Models;
using System.Collections.Generic;

namespace Infrastructure.Interface.Interface
{
    public interface IDeviceRepository
    {
        //List<User> GetUsers();
        List<DevicesInfrastructureModel> GetDevices(int userId);
        void AddNewDevice(DevicesInfrastructureModel device, int userId);
        void DeleteDevice(int userId, int deviceId);
    }
}
