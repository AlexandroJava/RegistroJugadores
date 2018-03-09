using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroJugadores.Models
{
    public class Posicion
    {
        public int PosicionID { get; set; }

        [Required]
        [Display(Name = "Nombre de la Posicion")]
        [StringLength(50)]
        public string NomPosicion { get; set; }

        [Required]
        public int EstadoPosicion { get; set; }

        [Required]
        [Display(Name = "Fecha de la Posicion")]
        public DateTime FechaPosicion { get; set; }


        public ICollection<Posicion> Posiciones { get; set; }


        public Posicion()
        {
            FechaPosicion = DateTime.Now;
        }

    }
}