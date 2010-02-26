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

            return View(new Adicionar("Nova casa"){Tipologias = tipologias});
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Adicionar(string descricao, int tipologia, decimal  preco)
        {
            _session.BeginTransaction();
            var t = _session.Get<Tipologia>(tipologia);

            var casa = new Casa(descricao, t, preco);

            _session.Save(casa);
            _session.Transaction.Commit();
            return Redirect(Url.Action("Index", new{highlight = casa.Id})+"#"+casa.Id);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdicionarOferta(int idCasa, string comprador, decimal valor)
        {
            _session.BeginTransaction();

            var casa = _session.Get<Casa>(idCasa);
            casa.AdicionarOferta(new Oferta(comprador, valor));

            _session.Update(casa);
            _session.Transaction.Commit();
            return Redirect(Url.Action("Index", new{highlight = casa.Id})+"#"+casa.Id);
        }
        
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Editar(int id)
        {
            var tipologias = _session.CreateCriteria<Tipologia>().List<Tipologia>();
            var casa = _session.Get<Casa>(id);

            return View("Adicionar", new Adicionar("Editar casa",casa) {Tipologias = tipologias});
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Editar(int id, string descricao, int tipologia, decimal preco)
        {
            _session.BeginTransaction();
            var t = _session.Get<Tipologia>(tipologia);
            var casa = _session.Get<Casa>(id);

            casa.Descricao = descricao;
            casa.Tipologia = t;
            casa.Preco = preco;

            _session.Update(casa);
            _session.Transaction.Commit();
            return Redirect(Url.Action("Index", new {highlight = casa.Id}) + "#" + casa.Id);

        }
    }
}
