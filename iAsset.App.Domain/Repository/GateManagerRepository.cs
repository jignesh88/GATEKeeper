using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAsset.App.Domain.Repository
{
    public class GateManagerRepository : IGateManagerRepository
    {
        public Entity.Flight addNewFlightToGate(int gateId, Entity.Flight flight)
        {
            var gate = getGateById(gateId);
            gate.AddFlight(flight);
            return flight;
        }

        public void moveFlightFromGate(int newGateId, Entity.Flight flight)
        {
            throw new NotImplementedException();
        }

        public void removeFlightFromGate(Entity.Flight flight)
        {
            throw new NotImplementedException();
        }

        public Entity.Flight getFlightById(int flightId)
        {
            throw new NotImplementedException();
        }

        public Entity.Gate getGateById(int gateId)
        {
            throw new NotImplementedException();
        }
    }
}
