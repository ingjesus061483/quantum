using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Factory;
using System.Configuration;
using System.Threading.Tasks;
using Helper;
namespace PruebaQuantum.Controllers
{
    public class ProductosController : Controller
    {
 
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
                return View(productos);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();             
            }
        }
    
        // GET: Proctutos/Details/5
        public async Task< ActionResult >Details(int id)
        {
            Utilities.url = url + $"/Productos";
            productos = await Utilities.GetListDataAPIAsync<Producto>(); 
            Producto producto = Logica.BuscarProducto(productos, id);
            return View( producto );
        }

        // GET: Proctutos/Create
        public ActionResult Create()
        {
            Producto producto = new Producto { PorcentajeIVAAplicado = 0.16M };               
            return View(producto);
        }

        // POST: Proctutos/Create
        [HttpPost]
        public async Task< ActionResult >Create(Producto producto)
        {
            try
            {
                Utilities.url = url + "/Productos";
                await Utilities.PostDataAPIAsync(producto);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        
        // GET: Proctutos/Edit/5
        public async Task < ActionResult> Edit(int id=0)
        {
            try
            {
                Utilities.url = url + $"/Productos";
                productos = await Utilities.GetListDataAPIAsync<Producto>();
                Producto producto = Logica.BuscarProducto(productos, id);
                return View(producto );
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Proctutos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producto producto )
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
