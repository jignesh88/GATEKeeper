using iAsset.App.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAsset.App.Domain.Repository
{
    public interface IGateManagerRepository
    {
        public Flight addNewFlightToGate(int gateId, Flight flight);
        public void moveFlightFromGate(int newGateId, Flight flight);
        public void removeFlightFromGate(Flight flight);

        public Flight getFlightById(int flightId);
        
        public Gate getGateById(int gateId);

    }
}
