using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnewinEventAspNetMvc5.Web.Models;

namespace KnewinEventAspNetMvc5.Web.Controllers
{
    public class EventosController : Controller
    {
        private KnewinEvent db = new KnewinEvent();

        // GET: Eventos
        public ActionResult Index()
        {
            var eVENTO = db.EVENTO.Include(e => e.CALENDARIO);
            return View(eVENTO.ToList());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTO.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            ViewBag.COD_CALENDARIO = new SelectList(db.CALENDARIO, "COD_CALENDARIO", "NOME");
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EVENTO evento)
        {
            if (ModelState.IsValid)
            {
                evento.COD_EVENTO = db.EVENTO.Max(x => x.COD_EVENTO) + 1;
                db.EVENTO.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CALENDARIO = new SelectList(db.CALENDARIO, "COD_CALENDARIO", "NOME", evento.COD_CALENDARIO);
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTO.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CALENDARIO = new SelectList(db.CALENDARIO, "COD_CALENDARIO", "NOME", eVENTO.COD_CALENDARIO);
            return View(eVENTO);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_EVENTO,NOME,ATIVO,COD_CALENDARIO")] EVENTO eVENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CALENDARIO = new SelectList(db.CALENDARIO, "COD_CALENDARIO", "NOME", eVENTO.COD_CALENDARIO);
            return View(eVENTO);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTO.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVENTO eVENTO = db.EVENTO.Find(id);
            db.EVENTO.Remove(eVENTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
