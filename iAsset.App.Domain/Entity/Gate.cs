using iAsset.App.Domain.Exception;
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
        public string Name { get; set; }
        private List<Flight> Flights { get; set; }

        public Gate()
        {
            Flights = new List<Flight>();
        }

        public Flight AddFlight(int id, string name, DateTime arrivalTime, DateTime departureTime)
        {
            var flight = new Flight(id, name, arrivalTime, departureTime, GateId);
            Flights.Add(flight);
            return flight;
        }

        public void RemoveFlight(Flight flight)
        {
            Flights.Remove(flight);
        }

        
        public List<Flight> GetFlights()
        {
            return Flights;
        }
        
        public Flight UpdateFlightArrival(int flightId, DateTime arrivalTime)
        {
            var orig = Flights.Where(f => f.FlightId == flightId).FirstOrDefault();
            orig.UpdateArrivalTime(arrivalTime);
            return orig;
        }
    }
}
