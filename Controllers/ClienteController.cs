using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteCLS> listaClientes = null;
            using (var db = new BDPasajeEntities())
            {
                listaClientes = (from cliente in db.Cliente
                                 where cliente.BHABILITADO == 1
                                 select new ClienteCLS
                                 {
                                     iidcliente = cliente.IIDCLIENTE,
                                     nombre = cliente.NOMBRE,
                                     apPaterno = cliente.APPATERNO,
                                     apMaterno = cliente.APMATERNO,
                                     telefonoFijo = cliente.TELEFONOFIJO
                                 }).ToList();
            }

            return View(listaClientes);
        }

        List<SelectListItem> listaSexo;
        private void llenarSexo() 
        {
            using (var bd = new BDPasajeEntities())
            {
                listaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 //lo que se muestra
                                 Text = sexo.NOMBRE,
                                 //lo que se guarda
                                 Value = sexo.IIDSEXO.ToString()
                             }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "--seleciones--", Value = "" });
            }
        
        }



        //vista agregar
        public ActionResult Agregar() 
        {
            llenarSexo();
            //pasa informacion de la lista ala listasexo
            ViewBag.lista = listaSexo;

            return View();
        }

        [HttpPost]
        //recibe el modelo de ClienteCLS
        public ActionResult Agregar(ClienteCLS oClienteCLS) 
        {
            if (!ModelState.IsValid)
            {
                llenarSexo();
                ViewBag.lista = listaSexo;
                return View(oClienteCLS);
            }

            using (var bd = new BDPasajeEntities()) 
            {
                //referencia a Cliente Entity
                Cliente cliente = new Cliente();
                cliente.NOMBRE = oClienteCLS.nombre;
                cliente.APPATERNO = oClienteCLS.apPaterno;
                cliente.APMATERNO = oClienteCLS.apMaterno;
                cliente.EMAIL = oClienteCLS.email;
                cliente.DIRECCION = oClienteCLS.direccion;
                cliente.IIDSEXO = oClienteCLS.iidsexo;
                cliente.TELEFONOCELULAR = oClienteCLS.telefonoCelular;
                cliente.TELEFONOFIJO = oClienteCLS.telefonoFijo;
                cliente.BHABILITADO = 1;
                bd.Cliente.Add(cliente);
                bd.SaveChanges();

            }

            return RedirectToAction("Index");
        
        }

    }
}