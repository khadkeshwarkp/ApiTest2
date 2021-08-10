using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest2.Models
{
    public partial class Routes
    {
        public Routes()
        {
            Bus = new HashSet<Bus>();
        }

        public int RouteId { get; set; }
        public string StartingPoint { get; set; }
        public string Destination { get; set; }

        public virtual ICollection<Bus> Bus { get; set; }
    }
}
