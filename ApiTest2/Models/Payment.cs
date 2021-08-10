using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest2.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Booking = new HashSet<Booking>();
            Refund = new HashSet<Refund>();
        }

        public int PaymentId { get; set; }
        public int AmountPaid { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Refund> Refund { get; set; }
    }
}
