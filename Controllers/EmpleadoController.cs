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

        public void ListarComboTipoContrato() 
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities()) 
            {
                lista = (from item in bd.TipoContrato
                             where item.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = item.NOMBRE,
                                 Value = item.IIDTIPOCONTRATO.ToString()
                             }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--selecione--", Value = "" });
                ViewBag.listaTipoContrato = lista;

            }
        }

        public void ListarComboSexo()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Sexo
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDSEXO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--selecione--", Value = "" });
                ViewBag.listaSexo = lista;

            }
        }

        public void ListarComboTipoUsuario()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoUsuario
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOUSUARIO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--selecione--", Value = "" });
                ViewBag.listaTipoUsuario = lista;

            }
        }

        //funcion que lista todos los comboboxes
        public void ListarComboBoxes() 
        {
            ListarComboTipoUsuario();
            ListarComboSexo();
            ListarComboTipoContrato();
        }


        public ActionResult Agregar() 
        {
            ListarComboBoxes();
            return View();
        }
    }
}