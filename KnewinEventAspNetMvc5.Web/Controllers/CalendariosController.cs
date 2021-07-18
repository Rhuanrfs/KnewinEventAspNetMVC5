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
    public class CalendariosController : Controller
    {
        private KnewinEvent db = new KnewinEvent();

        // GET: Calendarios
        public ActionResult Index()
        {
            var cALENDARIO = db.CALENDARIO.Include(c => c.EQUIPE);
            return View(cALENDARIO.ToList());
        }

        // GET: Calendarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CALENDARIO cALENDARIO = db.CALENDARIO.Find(id);
            if (cALENDARIO == null)
            {
                return HttpNotFound();
            }
            return View(cALENDARIO);
        }

        // GET: Calendarios/Create
        public ActionResult Create()
        {
            ViewBag.COD_EQUIPE = new SelectList(db.EQUIPE, "COD_EQUIPE", "NOME");
            return View();
        }

        // POST: Calendarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CALENDARIO,NOME,ATIVO,COD_EQUIPE")] CALENDARIO cALENDARIO)
        {
            if (ModelState.IsValid)
            {
                db.CALENDARIO.Add(cALENDARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_EQUIPE = new SelectList(db.EQUIPE, "COD_EQUIPE", "NOME", cALENDARIO.COD_EQUIPE);
            return View(cALENDARIO);
        }

        // GET: Calendarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CALENDARIO cALENDARIO = db.CALENDARIO.Find(id);
            if (cALENDARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_EQUIPE = new SelectList(db.EQUIPE, "COD_EQUIPE", "NOME", cALENDARIO.COD_EQUIPE);
            return View(cALENDARIO);
        }

        // POST: Calendarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CALENDARIO,NOME,ATIVO,COD_EQUIPE")] CALENDARIO cALENDARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cALENDARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_EQUIPE = new SelectList(db.EQUIPE, "COD_EQUIPE", "NOME", cALENDARIO.COD_EQUIPE);
            return View(cALENDARIO);
        }

        // GET: Calendarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CALENDARIO cALENDARIO = db.CALENDARIO.Find(id);
            if (cALENDARIO == null)
            {
                return HttpNotFound();
            }
            return View(cALENDARIO);
        }

        // POST: Calendarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CALENDARIO cALENDARIO = db.CALENDARIO.Find(id);
            db.CALENDARIO.Remove(cALENDARIO);
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
