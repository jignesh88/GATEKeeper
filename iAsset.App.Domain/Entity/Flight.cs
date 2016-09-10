using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAsset.App.Domain.Entity
{
    public class Flight
    {
        public int FlightId { get; private set; }
        public string Name { get; set; }
        public DateTime ArrivalTime { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public int GateId { get; private set; }

        public Flight()
        {

        }


        public Flight(int id, string name, DateTime arrivalTime, DateTime departureTime, int gateid)
        {
            FlightId = id;
            Name = name;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
            GateId = gateid;
        }

        public void UpdateArrivalTime(DateTime newTime )
        {
            ArrivalTime = newTime;
        }
        
        public void UpdateDepartureTime(DateTime newTime)
        {
            DepartureTime = newTime;
        }
        
        public void UpdateGate(int newGateId)
        {
            GateId = newGateId;
        }
    }
}
