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
    public class UsuariosController : Controller
    {
        private KnewinEvent db = new KnewinEvent();

        // GET: Usuarios
        public ActionResult Index()
        {
            var uSUARIO = db.USUARIO.Include(u => u.EQUIPE);
            return View(uSUARIO.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.COD_EQUIPE = new SelectList(db.EQUIPE, "COD_EQUIPE", "NOME");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.COD_USUARIO = db.USUARIO.Max(x => x.COD_USUARIO) + 1;
                db.USUARIO.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_EQUIPE = new SelectList(db.EQUIPE, "COD_EQUIPE", "NOME", usuario.COD_EQUIPE);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_EQUIPE = new SelectList(db.EQUIPE, "COD_EQUIPE", "NOME", uSUARIO.COD_EQUIPE);
            return View(uSUARIO);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_USUARIO,NOME,APELIDO,SETOR,DDD,TELEFONE,COD_EQUIPE")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_EQUIPE = new SelectList(db.EQUIPE, "COD_EQUIPE", "NOME", uSUARIO.COD_EQUIPE);
            return View(uSUARIO);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
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
