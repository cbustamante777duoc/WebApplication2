using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class BusCLS
    {
        [Display(Name ="id bus")]
        public int iidBus { get; set; }
        [Display(Name = "nombre sucursal")]
        [Required]
        public int iidSucursal { get; set; }
        [Display(Name = "Tipo bus")]
        [Required]
        public int iidTipoBus { get; set; }
        [Display(Name = "fecha de compra")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaCompra { get; set; }
        [Display(Name = "nombre modelo")]
        [Required]
        public int iidModelo { get; set; }
        [Display(Name = "numero de filas")]
        [Required]
        public int numeroFilas { get; set; }
        [Display(Name = "numero de columnas")]
        [Required]
        public int numeroColumnas { get; set; }
        public int bhabilitado { get; set; }
        [Display(Name = "Descripcion")]
        [Required]
        public string descripcion { get; set; }
        [Display(Name = "Observacion")]
       
        public string observacion { get; set; }
        [Display(Name = "Nombre marca")]
        [Required]
        public int iidMarca { get; set; }

        //propiedades adiccionales
        public string nombreSurcursal { get; set; }
        public string nombreTipoBus { get; set; }
        public string nombreModelo { get; set; }

    }
}