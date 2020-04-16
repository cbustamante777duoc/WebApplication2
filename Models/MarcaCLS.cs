using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class MarcaCLS
    {
        [Display(Name = "Id marca")]

        public int iidmarca { get; set; }
        [Display(Name = "nombre marca")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud maxima es 100")]
        public string nombre { get; set; }
        [Display(Name = "descripcion marca")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima es 200")]
        public string descripcion { get; set; }

        public int bhabilitado { get; set; }
    }
}