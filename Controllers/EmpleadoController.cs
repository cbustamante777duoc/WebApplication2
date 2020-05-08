using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleados = null;

            using (var db = new BDPasajeEntities()) 
            {
                listaEmpleados = (from empleado in db.Empleado
                                  join tipoUsuario in db.TipoUsuario
                                  on empleado.IIDTIPOUSUARIO equals tipoUsuario.IIDTIPOUSUARIO
                                  join tipoContrato in db.TipoContrato
                                  on empleado.IIDTIPOCONTRATO equals tipoContrato.IIDTIPOCONTRATO
                                  where empleado.BHABILITADO==1
                                  select new EmpleadoCLS
                                  {
                                      iidEmpleado = empleado.IIDEMPLEADO,
                                      nombre = empleado.NOMBRE,
                                      apPaterno = empleado.APPATERNO,
                                      nombreTipoUsuario = tipoUsuario.NOMBRE,
                                      nombreTipoContrato = tipoContrato.NOMBRE
                                  }).ToList();

            
            }
                return View(listaEmpleados);
        }
    }
}