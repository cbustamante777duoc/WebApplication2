using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            //recuerda poner using MiPrimeraAppWeb.Models;
            List<MarcaCLS> listaMarca = null;
            using (var db = new BDPasajeEntities())
            {
                listaMarca = (from marca in db.Marca
                              where marca.BHABILITADO == 1

                              select new MarcaCLS
                              {
                                  iidmarca = marca.IIDMARCA,
                                  nombre = marca.NOMBRE,
                                  descripcion = marca.DESCRIPCION
                              }).ToList();
            }
            return View(listaMarca);
        }

        //referencia a la vista
        public ActionResult Agregar()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Agregar(MarcaCLS oMarcaCLS)
        {
            //si no es valido redirige a la vista con los datos
            if (!ModelState.IsValid)
            {
                return View(oMarcaCLS);
            }
            else
            {
                //instacia de models
                using (var bd = new BDPasajeEntities()) 
                { //instacia entity marca
                    Marca oMarca = new Marca();
                    oMarca.NOMBRE = oMarcaCLS.nombre;
                    oMarca.DESCRIPCION = oMarcaCLS.descripcion;
                    oMarca.BHABILITADO = 1;
                    //guardando la instacia en la bd
                    bd.Marca.Add(oMarca);
                    //guardando los cambios
                    bd.SaveChanges();
                } 
            }
            //regresando a la lista con los nuevos cambios
            return RedirectToAction("Index");
        }

    


    }
}