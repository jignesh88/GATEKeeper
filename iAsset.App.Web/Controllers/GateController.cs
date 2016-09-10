using iAsset.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iAsset.App.Web.Controllers
{
    public class GateController : ApiController
    {
        GateViewModel[] gates = new GateViewModel[]{
            new GateViewModel{
                GateId = 1,
                Flights = new FlightViewModel[]{
                    new FlightViewModel{ FlightId = 1, FlightName = "Flight 1", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 2, FlightName = "Flight 2", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 3, FlightName = "Flight 3", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 4, FlightName = "Flight 4", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 5, FlightName = "Flight 5", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 6, FlightName = "Flight 6", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 7, FlightName = "Flight 7", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 8, FlightName = "Flight 8", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 9, FlightName = "Flight 9", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 10, FlightName = "Flight 10", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                }
            },
            new GateViewModel{
                GateId = 2,
                Flights = new FlightViewModel[]{
                    new FlightViewModel{ FlightId = 11, FlightName = "Flight 11", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 12, FlightName = "Flight 12", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 13, FlightName = "Flight 13", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 14, FlightName = "Flight 14", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 15, FlightName = "Flight 15", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 16, FlightName = "Flight 16", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 17, FlightName = "Flight 17", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 18, FlightName = "Flight 18", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 19, FlightName = "Flight 19", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                    new FlightViewModel{ FlightId = 20, FlightName = "Flight 20", ArrivalTime = DateTime.Now, DepartureTime = DateTime.Now.AddMinutes(30) },
                }
            }
        };


        public IEnumerable<GateViewModel> GetGates()
        {
            return gates;
        }

        public IHttpActionResult GetGate(int id)
        {
            var gate = gates.Where(g => g.GateId == id).FirstOrDefault();
            if (gate != null)
            {
                return Ok(gate);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult GetGate(int id, DateTime date)
        {
            var gate = gates.Where(g => g.GateId == id).FirstOrDefault();
            if (gate != null)
            {
                return Ok(gate);
            }
            else
            {
                return NotFound();
            }
        }

        [ActionName("deleteFlight")]
        [HttpDelete]
        public IHttpActionResult deleteFlight(FlightViewModel flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gate = gates.Where(g => g.GateId == flight.GateId).FirstOrDefault();
            gate.Flights.ToList().Remove(flight);

            return Ok();
        }

        [ActionName("editFlight")]
        [HttpPost]
        public IHttpActionResult EditFlight(FlightViewModel flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = gates.Where(g => g.GateId == flight.GateId).FirstOrDefault().Flights.Where(f => f.FlightId == flight.FlightId).FirstOrDefault();

            if (dto == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [ActionName("addFlight")]
        [HttpPost]
        public IHttpActionResult AddFlight(FlightViewModel flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gate = gates.Where(g => g.GateId == flight.GateId).FirstOrDefault();
            gate.Flights.ToList().Add(flight);
            return Ok(flight);    
        }
    }
}
