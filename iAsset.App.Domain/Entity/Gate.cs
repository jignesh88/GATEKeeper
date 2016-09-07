using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAsset.App.Domain.Entity
{
    public class Gate
    {
        public int GateId { get; set; }
        public List<Flight> Flights { get; set; }

        public Flight AddFlight(Flight flight)
        {
            // check are there any flight in gate
            if (Flights.Count == 0)
            {
                Flights.Add(flight);
            }
            else
            {
                foreach (var f in Flights)
                {
                    
                }
            }

            return flight;
        }

        public void RemoveFlight(Flight flight)
        {

        }

        public Flight UpdateFlight(Flight flight)
        {
            return flight;
        }
    }
}
