using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iAsset.App.Domain.Common;
namespace iAsset.App.Web.Models
{
    public class GateViewModel
    {
        public int GateId { get; set; }
        public string Name { get; set; }
        public List<FlightViewModel> Flights { get; set; }

        public List<FlightViewModel> GetFlights(DateTime? date)
        {
            if (date.HasValue)
            {
                var filtered = Flights.Where(f => f.ArrivalTime.EqualDay((DateTime)date)).ToList();
                return filtered;
            }
            else
            {
                return Flights;
            }
        }
    }
}