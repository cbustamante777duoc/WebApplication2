using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class SucursalCLS
    {
        [Display(Name = "Id sucursal")]

        public int iidsucursal { get; set; }
        [Display(Name = "nombre sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "La Longitud no debe superar los 100 caracteres")]
        public string nombre { get; set; }
        [Display(Name = "Direcion sucursal")]
        [Required]
        [StringLength(200, ErrorMessage = "La Longitud no debe superar los 200 caracteres")]
        public string direccion { get; set; }
        [Display(Name = "telefono sucursal")]
        [Required]
        [StringLength(10, ErrorMessage = "La Longitud no debe superar los 10 numeros")]
        public string telefono { get; set; }

        [Display(Name = "Email sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "La Longitud no debe superar los 100 caracteres")]
        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        public string email { get; set; }
        [Display(Name = "fecha de apertura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime fechaApertura { get; set; }

        public int Bhabilitado { get; set; }

    }
}
