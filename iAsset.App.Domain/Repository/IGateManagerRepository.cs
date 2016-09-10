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
        Flight addFlight(Flight flight);
        void updateFlight(Flight flight);
        void removeFlight(Flight flight);
        void ChangeFlightGates(int newGateId, Flight flight);
        List<Gate> getGates();

    }
}
