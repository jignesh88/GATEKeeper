using iAsset.App.Domain.Entity;
using iAsset.App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iAsset.App.Domain.Common;
namespace iAsset.App.Domain.Repository
{
    public class GateManagerRepository : IGateManagerRepository
    {

        private static List<Gate> gates { get; set; }
        private static List<Flight> flights { get; set; }

        static GateManagerRepository()
        {
            gates = new List<Gate>();
            flights = new List<Flight>();

            var firstGate = new Gate();
            firstGate.Name = "GATE 1";
            firstGate.GateId = 1;
            
            var secondGate = new Gate();
            secondGate.Name = "GATE 2";
            secondGate.GateId = 2;

            for (int i = 0; i <= 20; i++)
            {
                var flight = new Flight(i, string.Format("FLIGHT {0}", i), DateTime.Now.SetTime(0, 0).AddMinutes(i * 30), DateTime.Now.SetTime(0, 29).AddMinutes(i * 30), (i % 2) + 1); 
                
                flights.Add(flight);

                if (i % 2 == 0)
                {
                    firstGate.AddFlight(flight);
                }
                else
                {
                    secondGate.AddFlight(flight);
                }
            }

            gates.Add(firstGate);
            gates.Add(secondGate);
        }

        public GateManagerRepository()
        {

        }

        public Entity.Flight addFlight(Entity.Flight flight)
        {
            bool doRearrange = false;
            
            var gate = gates.Where(g => g.GateId == flight.GateId).FirstOrDefault();
            
            var getGateFlights = gate.GetFlights();
            foreach (var item in getGateFlights)
            {
                if ((item.ArrivalTime <= flight.ArrivalTime && flight.ArrivalTime <= item.DepartureTime) ||
                    (item.ArrivalTime <= flight.DepartureTime && flight.DepartureTime <= item.DepartureTime))
                {
                    var disembarkingTime = item.DepartureTime.Subtract(item.ArrivalTime).Minutes;
                    item.UpdateArrivalTime(flight.DepartureTime.AddMinutes(1));
                    item.UpdateDepartureTime(item.ArrivalTime.AddMinutes(disembarkingTime));
                    doRearrange = true;
                }
            }
            
            if (doRearrange)
            {
                RearrangeFlights(gate);
            }

            flight.FlightId = flights.Count + 1;
            
            gate.AddFlight(flight);
            flights.Add(flight);
            return flight;
        }

        private void RearrangeFlights(Gate gate)
        {

            foreach (var checkItem in gate.GetFlights())
            {
                foreach (var item in gate.GetFlights())
                {
                    if (!checkItem.Equals(item))
                    {
                        if ((item.ArrivalTime <= checkItem.ArrivalTime && checkItem.ArrivalTime <= item.DepartureTime) ||
                            item.ArrivalTime <= checkItem.DepartureTime && checkItem.DepartureTime <= item.DepartureTime)
                        {
                            var disembarkingTime = item.DepartureTime.Subtract(item.ArrivalTime).Minutes;
                            item.UpdateArrivalTime(checkItem.DepartureTime.AddMinutes(1));
                            item.UpdateDepartureTime(item.ArrivalTime.AddMinutes(disembarkingTime));
                        }
                    }
                }
                
            }
        }

        public void updateFlight(Entity.Flight flight)
        {
            var gate = gates.Where(g => g.GateId == flight.GateId).FirstOrDefault();
            var orig = gate.GetFlights(null).FirstOrDefault();
            orig.Name = flight.Name;

        }

        public void removeFlight(Entity.Flight flight)
        {
            var gate = gates.Where(g => g.GateId == flight.GateId).FirstOrDefault();
            gate.RemoveFlight(flight);
        }

        public List<Entity.Gate> getGates(DateTime? date)
        {
            gates.ForEach(g => g.GetFlights(date));
            return gates;
        }

        public List<Entity.Gate> getGates()
        {
            gates.ForEach(g => g.GetFlights());
            return gates;
        }


        public void ChangeFlightGates(int newGateId, Flight flight)
        {
            // remove flight from existing gate
            removeFlight(flight);
            // update flight gate
            flight.UpdateGate(newGateId);
            // add flight to new gate
            addFlight(flight);
        }


        public Flight getFlight(int id)
        {
            return flights.Where(f => f.FlightId == id).FirstOrDefault();
        }
    }
}
