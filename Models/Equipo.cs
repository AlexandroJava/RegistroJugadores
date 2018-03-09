using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroJugadores.Models
{
    public class Equipo
    {
        public int EquipoID { get; set; }

        [Required]
        [Display(Name = "Nombre del Equipo")]
        [StringLength(50)]
        public String NomEquipo { get; set; }

        [Required]
        public int EstadoEquipo { get; set; }

        [Required]
        [Display(Name = "Fecha del Equipo")]
        public DateTime FechaEquipo { get; set; }


        public ICollection<Equipo> Equipos { get; set; }

        public Equipo()
        {
            FechaEquipo = DateTime.Now;
        }
    }

}