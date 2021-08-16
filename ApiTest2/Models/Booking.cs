using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest2.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Refund = new HashSet<Refund>();
            Seat = new HashSet<Seat>();
        }

        public int BookingId { get; set; }
        public int ScheduleId { get; set; }
        public int NumberOfSeats { get; set; }
        public double FareAmount { get; set; }
        public double TotalAmount { get; set; }
        public int BookingStatus { get; set; }
        public int? UserId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerEmail { get; set; }
        public string Feedback { get; set; }
        public int? PaymentId { get; set; }
        public int? Bushire { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Refund> Refund { get; set; }
        public virtual ICollection<Seat> Seat { get; set; }
    }
}
