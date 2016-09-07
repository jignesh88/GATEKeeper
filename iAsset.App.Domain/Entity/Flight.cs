using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAsset.App.Domain.Entity
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int GateId { get; set; }
    }
}
