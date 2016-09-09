using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iAsset.App.Web.Models
{
    public class GatesViewModel
    {
        public int GateId { get; set; }
        public List<FlightViewModel> Flights { get; set; }
    }
}