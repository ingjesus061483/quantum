using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Factory;
using System.Configuration;
using System.Threading.Tasks;
using Helper;
namespace PruebaQuantum.Controllers
{
    public class InventariosController : Controller
    {
        string modunlo = "Inventarios";
        Usuario usuario;
        string url;
        List<Producto> productos;
        public InventariosController()
        {
           url = ConfigurationManager.AppSettings["urlapi"];
        }
        // GET: Proctutos
        public async Task<ActionResult> Index()
        {
            ViewBag.sum = 0;
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modunlo, "List");
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
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modunlo, "Details");
                Utilities.url = url + $"/Productos";
                productos = await Utilities.GetListDataAPIAsync<Producto>();
                Producto producto = Logica.BuscarProducto(productos, id);
                return View(producto);
            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        // GET: Proctutos/Create
        public ActionResult Create()
        {
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modunlo, "Create");
                Producto producto = new Producto { PorcentajeIVAAplicado = 0.16M };
                return View(producto);
            }
            catch (Exception ex )
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        // POST: Proctutos/Create
        [HttpPost]
        public async Task< ActionResult >Create(Producto producto)
        {
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modunlo, "Create");
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
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modunlo, "Edit");
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
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modunlo, "Edit");
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
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modunlo, "Edit");
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
