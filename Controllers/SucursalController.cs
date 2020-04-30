using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            //lista de modelo
            List<SucursalCLS> listaSucursal = null;
            using (var db = new BDPasajeEntities())
            {
                //aqui se trae los datos del modelo vs bd
                //traer el id,nombre,telefono,email de sucursal que sean iguales a 1
                listaSucursal = (from sucursal in db.Sucursal
                                 where sucursal.BHABILITADO == 1
                                 select new SucursalCLS
                                 {
                                     iidsucursal = sucursal.IIDSUCURSAL,
                                     nombre = sucursal.NOMBRE,
                                     telefono = sucursal.TELEFONO,
                                     email = sucursal.EMAIL

                                 }).ToList();
            }
            return View(listaSucursal);
        }

        //retorna vista 
        public ActionResult Agregar() 
        {
            return View();
        
        }

    }
}