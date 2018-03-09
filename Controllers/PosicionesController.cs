using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistroJugadores.Models;

namespace RegistroJugadores.Controllers
{
    public class PosicionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posiciones
        public ActionResult Index()
        {
            return View(db.Posicions.ToList());
        }

        // GET: Posiciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicion posicion = db.Posicions.Find(id);
            if (posicion == null)
            {
                return HttpNotFound();
            }
            return View(posicion);
        }

        // GET: Posiciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posiciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PosicionID,NomPosicion,EstadoPosicion")] Posicion posicion)
        {
            if (ModelState.IsValid)
            {
                db.Posicions.Add(posicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posicion);
        }

        // GET: Posiciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicion posicion = db.Posicions.Find(id);
            if (posicion == null)
            {
                return HttpNotFound();
            }
            return View(posicion);
        }

        // POST: Posiciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PosicionID,NomPosicion,EstadoPosicion")] Posicion posicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posicion);
        }

        // GET: Posiciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicion posicion = db.Posicions.Find(id);
            if (posicion == null)
            {
                return HttpNotFound();
            }
            return View(posicion);
        }

        // POST: Posiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posicion posicion = db.Posicions.Find(id);
            db.Posicions.Remove(posicion);
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
