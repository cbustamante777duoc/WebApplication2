using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult Index()
        {
            List<BusCLS> listaBus = null;
            using (var bd = new BDPasajeEntities()) 
            {
                listaBus = (from bus in bd.Bus
                            join sucursal in bd.Sucursal
                            on bus.IIDSUCURSAL equals sucursal.IIDSUCURSAL
                            join tipobus in bd.TipoBus
                            on bus.IIDTIPOBUS equals tipobus.IIDTIPOBUS
                            join tipoModelo in bd.Modelo
                            on bus.IIDMODELO equals tipoModelo.IIDMODELO
                            where bus.BHABILITADO==1
                            select new BusCLS
                            {
                                iidBus = bus.IIDBUS,
                                placa = bus.PLACA,
                                nombreModelo = tipoModelo.NOMBRE,
                                nombreSurcursal = sucursal.NOMBRE,
                                nombreTipoBus = tipobus.NOMBRE,
                            }).ToList();            
            }

                return View(listaBus);
        }

        public void ListarComboTipoModelo()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoBus
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOBUS.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--selecione--", Value = "" });
                ViewBag.listaTipoBus = lista;

            }
        }
        public void ListarComboMarca()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Marca
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMARCA.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--selecione--", Value = "" });
                ViewBag.listaMarca = lista;

            }
        }
        public void ListarComboModelo()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Modelo
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMODELO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--selecione--", Value = "" });
                ViewBag.listaModelos = lista;

            }
        }
        public void ListarSucursal()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Sucursal
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDSUCURSAL.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--selecione--", Value = "" });
                ViewBag.listaSucursal = lista;

            }
        }

        public void ListarComboxes() 
        {
            ListarComboTipoModelo();
            ListarComboMarca();
            ListarComboModelo();
            ListarSucursal();

        }
        public ActionResult Agregar() 
        {
            ListarComboxes();
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(BusCLS ObusCLS) 
        {
            if (!ModelState.IsValid)
            {
                return View(ObusCLS);
            }

            using (var bd = new BDPasajeEntities()) 
            {
                Bus bus = new Bus();
                bus.IIDSUCURSAL = ObusCLS.iidSucursal;
                bus.IIDTIPOBUS = ObusCLS.iidTipoBus;
                bus.PLACA = ObusCLS.placa;
                bus.FECHACOMPRA = ObusCLS.fechaCompra;
                bus.IIDMODELO = ObusCLS.iidModelo;
                bus.NUMEROFILAS = ObusCLS.numeroFilas;
                bus.NUMEROCOLUMNAS = ObusCLS.numeroColumnas;
                bus.DESCRIPCION = ObusCLS.descripcion;
                bus.OBSERVACION = ObusCLS.observacion;
                bus.IIDMARCA = ObusCLS.iidMarca;
                bus.BHABILITADO = 1;
                //guardando el objeto bus en la base de datos
                bd.Bus.Add(bus);
                //guardando los cambios
                bd.SaveChanges();

            
            }
            return RedirectToAction("index");

        }
    }
}