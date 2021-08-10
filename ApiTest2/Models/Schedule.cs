using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest2.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Booking = new HashSet<Booking>();
        }

        public int ScheduleId { get; set; }
        public int BusId { get; set; }
        public int DriverId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public TimeSpan EstimatedArrivalTime { get; set; }
        public double FareAmount { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }
        public TimeSpan Time { get; set; }

        public virtual Bus Bus { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
