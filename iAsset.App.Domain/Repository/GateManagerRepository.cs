using iAsset.App.Domain.Entity;
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

        static GateManagerRepository()
        {
            gates = new List<Gate>();
        }

        public GateManagerRepository()
        {

            var firstGate = new Gate();
            firstGate.Name = "GATE 1";
            firstGate.GateId = 1;
            for (int i = 0; i < 10; i++)
            {
                firstGate.AddFlight(i, string.Format("FLIGHT {0}", i), DateTime.Now.SetTime(0, 0).AddMinutes(i * 30), DateTime.Now.SetTime(0, 29).AddMinutes(i * 30));
            }

            var secondGate = new Gate();
            secondGate.Name = "GATE 2";
            secondGate.GateId = 2;
            for (int i = 11; i < 20; i++)
            {
                secondGate.AddFlight(i, string.Format("FLIGHT {0}", i), DateTime.Now.SetTime(0, 0).AddMinutes(i * 30), DateTime.Now.SetTime(0, 29).AddMinutes(i * 30));
            }

            gates.Add(firstGate);
            gates.Add(secondGate);
        }

        public Entity.Flight addFlight(Entity.Flight flight)
        {
            var gate = gates.Where(g => g.GateId == flight.GateId).FirstOrDefault();
            gate.AddFlight(flight.FlightId, flight.Name, flight.ArrivalTime, flight.DepartureTime);
            return flight;
        }

        public void updateFlight(Entity.Flight flight)
        {
            var gate = gates.Where(g => g.GateId == flight.GateId).FirstOrDefault();
            var orig = gate.GetFlights().FirstOrDefault();
            orig.Name = flight.Name;
            
        }

        public void removeFlight(Entity.Flight flight)
        {
            var gate = gates.Where(g => g.GateId == flight.GateId).FirstOrDefault();
            gate.RemoveFlight(flight);
        }

        public List<Entity.Gate> getGates()
        {
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
    }
}
