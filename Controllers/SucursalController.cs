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

    
        public ActionResult Editar(int id) 
        {
            SucursalCLS OsucursalCLS = new SucursalCLS();
            using (var bd = new BDPasajeEntities()) 
            {
                //si hay error por orden ir 23 min 4.00
                Sucursal sucursal = bd.Sucursal.Where(s => s.IIDSUCURSAL.Equals(id)).First();
                OsucursalCLS.iidsucursal = sucursal.IIDSUCURSAL;
                OsucursalCLS.nombre = sucursal.NOMBRE;
                OsucursalCLS.telefono = sucursal.TELEFONO;
                OsucursalCLS.direccion = sucursal.DIRECCION;
                OsucursalCLS.email = sucursal.EMAIL;
                OsucursalCLS.fechaApertura = (DateTime)sucursal.FECHAAPERTURA;
            
            }
                return View(OsucursalCLS);
        
        }

        //retorna vista 
        public ActionResult Agregar()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Agregar(SucursalCLS oSucursalCLS)
        {
            //si el modelo no es valido
            if (!ModelState.IsValid)
            {
                // esto es para que lo valores se queden donde mismo
                return View(oSucursalCLS);
            }
            using (var bd = new BDPasajeEntities()) 
            {
                //entidad llamada de entityframework
                Sucursal oSucursal = new Sucursal();
                oSucursal.NOMBRE = oSucursalCLS.nombre;
                oSucursal.DIRECCION = oSucursalCLS.direccion;
                oSucursal.TELEFONO = oSucursalCLS.telefono;
                oSucursal.EMAIL = oSucursalCLS.email;
                oSucursal.FECHAAPERTURA = oSucursalCLS.fechaApertura;
                oSucursal.BHABILITADO = 1;
                bd.Sucursal.Add(oSucursal);
                bd.SaveChanges();
            
            }
                return RedirectToAction("Index");

        }


    }
}