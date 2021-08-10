using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest2.Models
{
    public partial class Refund
    {
        public int RefundId { get; set; }
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public double Amount { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
