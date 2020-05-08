using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class EmpleadoCLS
    {
        [Display(Name ="id empleado")]
        
        public int iidEmpleado { get; set; }
        [Display(Name = "Nombre Empleado")]
        [Required]
        [StringLength(100,ErrorMessage ="longuitud maxima es de 100")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(200, ErrorMessage = "longuitud maxima es de 200")]
        public string apPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(200, ErrorMessage = "longuitud maxima es de 200")]
        public string apMaterno { get; set; }
        [Display(Name = "fecha de contrato")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaContrato { get; set; }
        [Display(Name = " tipo de usuario")]
        [Required]
        public int iidtipoUsuario{ get; set; }
        [Display(Name = "tipo contrato")]
        [Required]
        public int iidtipoContrato { get; set; }
        [Display(Name = "sexo")]
        [Required]
        public int iidSexo { get; set; }
        public int bhabilitado { get; set; }


        ///PROPIPEDADES ADICIONALES

        [Display(Name = "nombre tipo contrato")]
        public string nombreTipoContrato { get; set; }
        [Display(Name = "nombre tipo usuario")]
        public string nombreTipoUsuario { get; set; }



    }
}