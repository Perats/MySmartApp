using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface.Models
{
    public class DeviceServiceModel
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public DateTime LastPinDate { get; set; }
        public int DeviceStatus { get; set; }
        public int RoomType { get; set; }
    }
}
