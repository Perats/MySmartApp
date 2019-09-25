using System;

namespace Infrastructure.Interface.Models
{
    public class DevicesInfrastructureModel
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public DateTime LastPinDate { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public RoomType RoomType { get; set; }
    }
    public enum RoomType : byte
    {
        LivingRoom = 0,
        Bedroom = 1,
        Kitchen = 2,
        ChildrensRoom = 3,
        Garage = 4
    }
    public enum DeviceStatus : byte
    {
        Waiting = 0,
        TurnOn = 1,
        TurnOff = 2
    }
}
