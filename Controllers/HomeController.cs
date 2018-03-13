using RegistroJugadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroJugadores.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var InfoJugador = db.Database.SqlQuery<JugadorXEquipo>(@"Select B.JugadorID, B.EquipoID, B.NomJugador, B.Sexo, B.Edad, B.Foto, B.FechaJugador, A.NomEquipo
                                                                    From Equipoes A Inner Join Jugadors B On (A.EquipoID = B.EquipoID) order by FechaJugador Desc").Take(15).ToList();

            return View(InfoJugador);
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