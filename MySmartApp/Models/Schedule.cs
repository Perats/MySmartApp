using System;

namespace MySmartApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string ScheduleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public bool IsActive { get; set; }
    }
}