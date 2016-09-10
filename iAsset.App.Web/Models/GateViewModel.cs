using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iAsset.App.Web.Models
{
    public class GateViewModel
    {
        public int GateId { get; set; }
        public string Name { get; set; }
        public FlightViewModel[] Flights { get; set; }
    }
}