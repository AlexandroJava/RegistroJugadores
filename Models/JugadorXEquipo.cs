using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistroJugadores.Models
{
    public class JugadorXEquipo
    {
        public int JugadorID { get; set; }

        public string NomJugador { get; set; }

        public string Sexo { get; set; }

        public int Edad { get; set; }

        public string Foto { get; set; }

        public DateTime FechaJugador { get; set; }

        public int EquipoID { get; set; }

        public string NomEquipo { get; set; }
    }
}