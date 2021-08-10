using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest2.Models
{
    public partial class Bus
    {
        public Bus()
        {
            Schedule = new HashSet<Schedule>();
        }

        public int BusId { get; set; }
        public int BusNumber { get; set; }
        public int BusPlateNumber { get; set; }
        public int BusType { get; set; }
        public int Capacity { get; set; }
        public int RouteId { get; set; }

        public virtual Routes Route { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
