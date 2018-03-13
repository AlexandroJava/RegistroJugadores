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
    public class JugadoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jugadores
        public ActionResult Index()
        {
            var jugadors = db.Jugadors.Include(j => j.Equipo).Include(j => j.Nacionalidad).Include(j => j.Posicion);
            return View(jugadors.ToList());
        }

        // GET: Entradas/DetalleJugador/5
        public ActionResult DetalleJugador(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugadors.Find(id);
            //Query para mostrar la tabla de comentarios en la pagina de DetalleEntrada
            //var InfoJugador = db.Database.SqlQuery<Jugador>(@"Select EquipoID,EntradaID,NomEquipo,EstadoEquipo,FechaEquipo,
                                                                    //From Equipos Where JugadorID = " + id).ToList();
            if (jugador == null)
            {
                return HttpNotFound();
            }
            //ViewBag.comentarios = InfoJugador;
            return View(jugador);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Jugadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugadors.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Jugadores/Create
        public ActionResult Create()
        {
            ViewBag.EquipoID = new SelectList(db.Equipoes, "EquipoID", "NomEquipo");
            ViewBag.NacionalidadID = new SelectList(db.Nacionalidads, "NacionalidadID", "NomNacionalidad");
            ViewBag.PosicionID = new SelectList(db.Posicions, "PosicionID", "NomPosicion");
            return View();
        }
        [Authorize(Roles = "Administrador")]
        // POST: Jugadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JugadorID,NomJugador,Sexo,Edad,Foto,NacionalidadID,PosicionID,EquipoID")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                db.Jugadors.Add(jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipoID = new SelectList(db.Equipoes, "EquipoID", "NomEquipo", jugador.EquipoID);
            ViewBag.NacionalidadID = new SelectList(db.Nacionalidads, "NacionalidadID", "NomNacionalidad", jugador.NacionalidadID);
            ViewBag.PosicionID = new SelectList(db.Posicions, "PosicionID", "NomPosicion", jugador.PosicionID);
            return View(jugador);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Jugadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugadors.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipoID = new SelectList(db.Equipoes, "EquipoID", "NomEquipo", jugador.EquipoID);
            ViewBag.NacionalidadID = new SelectList(db.Nacionalidads, "NacionalidadID", "NomNacionalidad", jugador.NacionalidadID);
            ViewBag.PosicionID = new SelectList(db.Posicions, "PosicionID", "NomPosicion", jugador.PosicionID);
            return View(jugador);
        }
        [Authorize(Roles = "Administrador")]
        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JugadorID,NomJugador,Sexo,Edad,Foto,NacionalidadID,PosicionID,EquipoID")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipoID = new SelectList(db.Equipoes, "EquipoID", "NomEquipo", jugador.EquipoID);
            ViewBag.NacionalidadID = new SelectList(db.Nacionalidads, "NacionalidadID", "NomNacionalidad", jugador.NacionalidadID);
            ViewBag.PosicionID = new SelectList(db.Posicions, "PosicionID", "NomPosicion", jugador.PosicionID);
            return View(jugador);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Jugadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugadors.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }
        [Authorize(Roles = "Administrador")]
        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jugador jugador = db.Jugadors.Find(id);
            db.Jugadors.Remove(jugador);
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
