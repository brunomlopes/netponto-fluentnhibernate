using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entities;
using NHibernate;
using Web.Models.Home;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession _session;

        public HomeController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            var casas = _session.CreateCriteria<Casa>().List<Casa>();
            return View(new Index(casas));
        }

    }
}
