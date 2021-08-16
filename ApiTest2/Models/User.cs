using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest2.Models
{
    public partial class User
    {
        public User()
        {
            Booking = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public string Userpassword { get; set; }
        public int AccountStatus { get; set; }
        public double Deposit { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
