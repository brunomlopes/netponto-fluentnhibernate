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

        public ActionResult Index(int? highlight)
        {
            var casas = _session.CreateCriteria<Casa>().List<Casa>();

            return View(new Index(casas, highlight));
        }
        
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Adicionar()
        {
            var tipologias = _session.CreateCriteria<Tipologia>().List<Tipologia>();

            return View(new Adicionar(){Tipologias = tipologias});
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Adicionar(string descricao, int tipologia, decimal  preco)
        {
            var t = _session.Get<Tipologia>(tipologia);
            var casa = new Casa(descricao, t, preco);
            _session.Save(casa);

            return Redirect(Url.Action("Index", new{highlight = casa.Id})+"#"+casa.Id);
        }
    }
}
