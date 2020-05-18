using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Id cliente")]
        public int iidcliente { get; set; }
        [Display(Name = "nombre cliente")]
        [Required]
        [StringLength(100, ErrorMessage = "el nombre tiene que tener solo 100 caracteres")]
        public string nombre { get; set; }
        [Display(Name = "apellido paterno")]
        [Required]
        [StringLength(150, ErrorMessage = "el apellido paterno tiene que tener solo 150 caracteres")]
        public string apPaterno { get; set; }
        [Display(Name = "apellido materno")]
        [Required]
        [StringLength(150, ErrorMessage = "el apellido materno tiene que tener solo 150 caracteres")]
        public string apMaterno { get; set; }
        [Required]
        [Display(Name = "email")]
        [StringLength(200, ErrorMessage = "el email tiene que tener solo 200 caracteres")]
        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        public string email { get; set; }
        [Display(Name = "Direccion")]
        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(200, ErrorMessage = "La direccion tiene que tener solo 200 caracteres")]
        public string direccion { get; set; }
        [Display(Name = "Sexo")]
        [Required]
        public int iidsexo { get; set; }
        [Display(Name = "telefono fijo")]
        [StringLength(10, ErrorMessage = "el telefono tiene que tener solo 10 caracteres")]
        public string telefonoFijo { get; set; }
        [Display(Name = "Telefono Celular")]
        [Required]
        [StringLength(10, ErrorMessage = "el telefono celular tiene que tener solo 10 caracteres")]
        public string telefonoCelular { get; set; }
        public int bhabilitado { get; set; }
    }
}