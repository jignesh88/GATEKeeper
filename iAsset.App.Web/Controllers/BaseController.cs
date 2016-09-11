using AutoMapper;
using iAsset.App.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iAsset.App.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IGateManagerRepository _repository;

        public BaseController()
        {

        }

        public BaseController(IGateManagerRepository repository)
        {
            _repository = repository;
        }
    }
}