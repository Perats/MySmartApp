using System;

namespace MySmartApp.Models
{
    public class Devices
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public DateTime LastPinDate { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public RoomType RoomType { get; set; }
        public string Rooms { get; set; }
        public int? RoomId { get; set; }
        public Schedule Schedule { get; set; }
    }
}