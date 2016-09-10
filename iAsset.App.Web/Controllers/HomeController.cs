using iAsset.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iAsset.App.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<FlightViewModel> flights = new List<FlightViewModel>();

            for (int i = 0; i < 20; i++)
            {
                var arrivalTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0).AddMinutes(i * 30);
                var departureTime = arrivalTime.AddMinutes(29);
                flights.Add(new FlightViewModel { GateId = i % 2, FlightName = string.Format("Flight {0}", i), ArrivalTime = arrivalTime, DepartureTime = departureTime, FlightId = i });
            }
            GateViewModel[] gates = new GateViewModel[]{
            new GateViewModel{
                GateId = 1,
                Name = "Gate 1",
                Flights =  flights.Where(f=>f.GateId==0).ToArray()
            },
            new GateViewModel{
                GateId = 2,
                Name = "Gate 2",
                Flights = flights.Where(f=>f.GateId==1).ToArray()
            }
        };
            return View(gates);
        }
    }
}
