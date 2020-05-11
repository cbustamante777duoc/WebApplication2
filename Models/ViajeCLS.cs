using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ViajeCLS
    {
        [Display(Name ="Id de viaje")]
        public int iidViaje { get; set; }
        [Display(Name = "Id lugar de origen")]
        [Required]
        public int iidLugarOrigen { get; set; }
        [Display(Name = "Id lugar destino")]
        [Required]
        public int iidLugarDestino { get; set; }
        [Display(Name = "Precio")]
        [Required]
        public double precio { get; set; }
        [Display(Name = "fecha de viaje")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaViaje { get; set; }
        [Display(Name = "Id bus")]
        [Required]
        public int iidBus { get; set; }
        [Display(Name = "numero de asientos disponibles")]
        [Required]
        public int numeroAsientosDisponibles { get; set; }

        //propiedades adicionales 
        [Display(Name = "nombre del lugar de origen")]
        public string nombreLugarDeOrigen { get; set; }
        [Display(Name = "nombre del lugar de destino")]
        public string nombreLugarDeDestino { get; set; }
        [Display(Name = "nombre del lugar del bus")]
        public string nombreBus { get; set; }

    }
}