using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iAsset.App.Web.Models
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }
        public string Name { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int GateId { get; set; }
    }
}