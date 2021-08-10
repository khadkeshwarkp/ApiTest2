using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest2.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Schedule = new HashSet<Schedule>();
        }

        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverContact { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
