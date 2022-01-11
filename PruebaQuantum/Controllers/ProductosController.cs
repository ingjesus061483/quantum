using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory;
using System.Configuration;
using System.Threading.Tasks;

namespace PruebaQuantum.Controllers
{
    public class ProductosController : Controller
    {
        List<FacturaDetalle> detalles;
        string url;
        List<Producto> productos;
        public ProductosController()
        {
           url = ConfigurationManager.AppSettings["urlapi"];
        }
        // GET: Proctutos
        public async Task<ActionResult> Index()
        {
            ViewBag.sum = 0;
            try
            {
                Utilities.url = url + $"/Productos";
                productos = await Utilities.GetListDataAPIAsync<Producto>();
                detalles = new List<FacturaDetalle>();
                if (Session["detalle"] != null)
                    detalles = (List<FacturaDetalle>)Session["detalle"];
                ViewBag.detalles = detalles;
                ViewBag.sum = totalPagar(detalles);              
                return View(productos);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();             
            }
        }
        [HttpPost]
        public async Task<ActionResult> Details(int cantidad, int id)
        {
            detalles = new List<FacturaDetalle>();
            if (Session["detalle"] != null)
                detalles =( List < FacturaDetalle > )Session["detalle"];
            Utilities.url = url + $"/Productos";
            productos = await Utilities.GetListDataAPIAsync<Producto>();
            Producto producto = productos.Find(x => x.Id == id);
            FacturaDetalle facturaDetalle = detalles.Find(x => x.producto.Id == id);
            detalles.Remove(facturaDetalle);
            FacturaDetalle detalle = new FacturaDetalle
            {
                cantidad = cantidad,
                producto = producto,
                ValorUnitario = producto.ValorentaSinIVA,
                ValorUnitarioIva = producto.ValorVentaConIva

            };
            detalles.Add(detalle);
            Session["detalle"] = detalles;
            return RedirectToAction("Index");
        }

        // GET: Proctutos/Details/5
        public async Task< ActionResult >Details(int id)
        {
            Utilities.url = url + $"/Productos";
            productos = await Utilities.GetListDataAPIAsync<Producto>();

            Producto producto = productos.Find(x => x.Id == id);
            List<FacturaDetalle> detalles = new List<FacturaDetalle>();
            int cantidad=1;
            if (Session["Detalle"] != null)
            {
                detalles = (List<FacturaDetalle>)Session["Detalle"];
                FacturaDetalle detalle = detalles.Find(x => x.producto.Id == id);
                if (detalle != null)
                {
                    cantidad = detalle.cantidad;
                }
                
            }
            
            ViewBag.sum = totalPagar (detalles );
            ViewBag.detalles = detalles;
            ViewBag.cantidad = cantidad;
            return View( producto );
        }

        // GET: Proctutos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proctutos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        decimal totalPagar(List <FacturaDetalle> detalles)
        {
            decimal sum = 0;
            foreach (var item in detalles)
            {
                sum = item.totalIva + sum;
            }
            return sum;
        }
        // GET: Proctutos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Proctutos/Edit/5
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

        // GET: Proctutos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proctutos/Delete/5
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
