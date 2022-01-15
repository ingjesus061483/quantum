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
        string url;
        public FacturasController()
        {
            url= ConfigurationManager.AppSettings["urlapi"];

        }
        // GET: Facturas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Facturas/Create
        public ActionResult Create()
        {
            if (Session["detalle"] == null)
                return RedirectToAction("Index", "Productos", null);
            ViewBag.url = url;            
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
                if (cadena == "")
                    throw new Exception("No hay clientes disponibles");
                if (Session["detalle"] == null)
                    return RedirectToAction("Index","Productos",null);
                Usuario cliente = JsonConvert.DeserializeObject<Usuario>(cadena);
                detalles = (List<FacturaDetalle>)Session["detalle"];
                encabezado.Cliente = cliente;
                encabezado.Detalles = detalles;              
                Utilities.url = url + $"/Facturas";            
                string resp = await Utilities.PostDataAPIAsync<FacturaEncabezado >(encabezado );        
                TempData["msg"] = "gracias por utilizar nuestros servicios, vuelve pronto!";
                Session["detalle"] = null;
                return RedirectToAction("Index", "Productos", null);
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
