using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using Factory;
using Helper;
using Newtonsoft.Json;

namespace PruebaQuantum.Controllers
{
    
    public class FacturasController : Controller
    {
        List<FacturaDetalle> detalles; 
        List<Producto> productos;
        string url;
        public FacturasController()
        {
            url= ConfigurationManager.AppSettings["urlapi"];

        }
        // GET: Facturas
        public async Task < ActionResult> Index()
        {
            ViewBag.sum = 0;
            try
            {
                Utilities.url = url + $"/Productos";
                productos = await Utilities.GetListDataAPIAsync<Producto>();
                detalles = (List<FacturaDetalle>)Session["detalle"];
                ViewBag.detalles = detalles;
                ViewBag.sum = Logica.TotalPagar(detalles);
                return View(productos);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        // GET: Facturas/Details/5
        [HttpPost]
        public async Task<ActionResult> Details(int cantidad, int id)
        {
            detalles = new List<FacturaDetalle>();
            try
            {
                if (Session["detalle"] != null)
                    detalles = (List<FacturaDetalle>)Session["detalle"];
                Utilities.url = url + $"/Productos";
                productos = await Utilities.GetListDataAPIAsync<Producto>();
                Producto producto = Logica.BuscarProducto(productos, id);
                Logica.AñadirDetalles(detalles, producto, cantidad, id);
                Session["detalle"] = detalles;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        // GET: Proctutos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Utilities.url = url + $"/Productos";
            productos = await Utilities.GetListDataAPIAsync<Producto>();
            List<FacturaDetalle> detalles = (List<FacturaDetalle>)Session["detalle"];
            int cantidad = Logica.DevolverCantidad(detalles, id);
            ViewBag.sum = Logica.TotalPagar(detalles);
            ViewBag.detalles = detalles;
            ViewBag.cantidad = cantidad;
            Producto producto = Logica.BuscarProducto(productos, id);
            return View(producto);
        }
        // GET: Facturas/Create
        public ActionResult Create()        
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Productos", null);
            if (Session["detalle"] == null)
                return RedirectToAction("Index", "Productos", null);
            ViewBag.url = url;
            ViewBag.usuario = (Usuario)Session["usuario"];
            List<FacturaDetalle>detalles=(List <FacturaDetalle>)Session["detalle"];
            ViewBag.totalPagar =Logica .TotalPagar(detalles);
            ViewBag.detalles = detalles;
            return View();
        }
        

        // POST: Facturas/Create
        [HttpPost]
        public async Task <ActionResult> Create(string cadena,FacturaEncabezado encabezado)
        {
            try
            {
                List<FacturaDetalle> detalles;
                if (Session["usuario"] == null)
                    throw new Exception("No hay clientes disponibles");
                if (Session["detalle"] == null)
                    return RedirectToAction("Index","Productos",null);
                Usuario usuario = (Usuario)Session["usuario"];
                detalles = (List<FacturaDetalle>)Session["detalle"];
                encabezado.Cliente = usuario ;
                encabezado.Detalles = detalles;              
                Utilities.url = url + $"/Facturas";            
                string resp = await Utilities.PostDataAPIAsync<FacturaEncabezado >(encabezado );        
                TempData["msg"] = "gracias por utilizar nuestros servicios, vuelve pronto!";
                Session["detalle"] = null;
                Session["usuario"] = null;
                return RedirectToAction("Index", "home", null);
            }
            catch(Exception ex)
            {              
                TempData["error"] = ex.Message;
                return RedirectToAction("Index", "Productos", null);
            }
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Facturas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Facturas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
