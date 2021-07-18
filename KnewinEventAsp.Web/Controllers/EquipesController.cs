﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnewinEventAsp.Web.Models;

namespace KnewinEventAsp.Web.Controllers
{
    public class EquipesController : Controller
    {
        private KNEWIN_EVENTEntities db = new KNEWIN_EVENTEntities();

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
        public ActionResult Create([Bind(Include = "COD_EQUIPE,NOME,ATIVO")] EQUIPE eQUIPE)
        {
            if (ModelState.IsValid)
            {
                db.EQUIPE.Add(eQUIPE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eQUIPE);
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
