using System;

namespace MySmartApp.Models
{
    public class DevicesViewModel
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public DateTime LastPinDate { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public RoomType RoomType { get; set; }
    }
}