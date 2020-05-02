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

        //vista agregar
        public ActionResult Agregar() 
        {

            return View();
        }

    }
}