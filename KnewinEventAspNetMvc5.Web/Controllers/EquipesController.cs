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
    public class EquipesController : Controller
    {
        private KnewinEvent db = new KnewinEvent();

        // GET: Equipes
        public ActionResult Index()
        {
            return View(db.EQUIPE.ToList());
        }

        // GET: Equipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPE eQUIPE = db.EQUIPE.Find(id);
            if (eQUIPE == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPE);
        }

        // GET: Equipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EQUIPE equipe)
        {
            if (ModelState.IsValid)
            {
                equipe.COD_EQUIPE = db.EQUIPE.Max(x => x.COD_EQUIPE) + 1;
                db.EQUIPE.Add(equipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipe);
        }

        // GET: Equipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPE eQUIPE = db.EQUIPE.Find(id);
            if (eQUIPE == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPE);
        }

        // POST: Equipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_EQUIPE,NOME,ATIVO")] EQUIPE eQUIPE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eQUIPE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eQUIPE);
        }

        // GET: Equipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPE eQUIPE = db.EQUIPE.Find(id);
            if (eQUIPE == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPE);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EQUIPE eQUIPE = db.EQUIPE.Find(id);
            db.EQUIPE.Remove(eQUIPE);
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
