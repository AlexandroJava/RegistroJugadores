using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroJugadores.Models
{
    public class Jugador
    {
        public int JugadorID { get; set; }

        [Required]
        [Display(Name = "Nombre del Jugador")]
        [StringLength(100)]
        public string NomJugador { get; set; }

        [Required]
        [Display(Name = "Sexo del Jugador")]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Edad del Jugador")]
        public int Edad { get; set; }

        [Required]
        [Display(Name = "Foto del Jugador")]
        public string Foto { get; set; }

        [Required]
        [Display(Name = "Fecha de Registro del Jugador")]
        public DateTime FechaJugador { get; set; }

        [Required]
        [Display(Name = "Nacionalidad del Jugador")]
        public int NacionalidadID { get; set; }

        [Required]
        [Display(Name = "Posicion del Jugador")]
        public int PosicionID { get; set; }

        [Required]
        [Display(Name = "Equipo del Jugador")]
        public int EquipoID { get; set; }

        public virtual Nacionalidad Nacionalidad { get; set; }
        public virtual Posicion Posicion { get; set; }
        public virtual Equipo Equipo { get; set; }

        public Jugador()
        {
            FechaJugador = DateTime.Now;
        }
    }
}