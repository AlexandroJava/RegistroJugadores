using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroJugadores.Models
{
    public class Nacionalidad
    {
        public int NacionalidadID { get; set; }

        [Required]
        [Display(Name = "Nombre de la Nacionalidad")]
        [StringLength(50)]
        public string NomNacionalidad { get; set; }

        [Required]
        public int EstadoNacionalidad { get; set; }

        [Required]
        [Display(Name = "Fecha de la Nacionalidad")]
        public DateTime FechaNacionalidad { get; set; }

        public ICollection<Nacionalidad> Nacionalidades { get; set; }


        public Nacionalidad()
        {
            FechaNacionalidad = DateTime.Now;
        }
    }
}