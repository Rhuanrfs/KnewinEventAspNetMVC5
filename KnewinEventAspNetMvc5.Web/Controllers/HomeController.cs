using KnewinEventAspNetMvc5.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnewinEventAspNetMvc5.Web.Controllers
{
    public class HomeController : Controller
    {
        private KnewinEvent db = new KnewinEvent();

        //PesquisarUsuario
        //public ActionResult Index(string nome)
        //{
        //    var usuario = db.USUARIO.Include(u => u.EQUIPE).Where(x => x.NOME.Contains(nome) || x.APELIDO.Contains(nome));
        //    return View(usuario.ToList());
        //}

        ////PesquisarEventos
        //public ActionResult Index(int codEquipe)
        //{
        //    var usuario = db.EVENTO.Include(x => x.CALENDARIO).Where(x => x.CALENDARIO.COD_EQUIPE == codEquipe);
        //    return View(usuario.ToList());
        //}

        ////ConfirmarPresenca
        //public ActionResult Index(PRESENCA presenca)
        //{
        //    if (db.PRESENCA.Any(x => x.COD_USUARIO == presenca.COD_USUARIO && x.COD_EVENTO == presenca.COD_EVENTO))
        //        return View("Você já está confirmado.");
        //    else
        //    {
        //        var usuario = db.PRESENCA.Add(presenca);
        //        return View("Ok! Te vejo lá.");
        //    }
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}