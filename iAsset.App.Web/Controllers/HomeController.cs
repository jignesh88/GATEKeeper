using AutoMapper;
using iAsset.App.Domain.Entity;
using iAsset.App.Domain.Repository;
using iAsset.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iAsset.App.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController()
        {

        }

        public HomeController(IGateManagerRepository repository)
            :base(repository)
        {

        }
        public ActionResult Index(DateTime? today)
        {
            ViewBag.CurrentDate = today.HasValue ? today.Value : DateTime.Now;
            var gates = _repository.getGates(today);
            var viewModel = Mapper.Map<List<GateViewModel>>(gates);
            return View(viewModel);
        }

        public PartialViewResult editFlight(int id)
        {
            return PartialView("_editFlight");
        }

        [HttpPost]
        public JsonResult AddFlight(FlightViewModel model)
        {
            var dto = Mapper.Map<Flight>(model);
            _repository.addFlight(dto);
            return Json(model);
        }

        [HttpPost]
        public JsonResult EditFlight(FlightViewModel model)
        {
            var dto = Mapper.Map<Flight>(model);
            _repository.updateFlight(dto);
            return Json(model);
        }

        [HttpPost]
        public JsonResult removeFlight(int id)
        {
            var flight = _repository.getFlight(id);
            _repository.removeFlight(flight);
            return Json(flight);
        }
        
        [HttpPost]
        public JsonResult changeGate(int flightId, int newGateId)
        {
            var flight = _repository.getFlight(flightId);
            _repository.ChangeFlightGates(newGateId, flight);
            return Json("success");
        }
    }
}
