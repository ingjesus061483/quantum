using Factory;
using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaQuantum.Controllers
{
    public class PerfilesController : Controller
    {
        Usuario usuario;
        string modulo = "Perfiles";
        string url;
        public PerfilesController()
        {
            url = ConfigurationManager.AppSettings["urlapi"];
        }
        // GET: Perfiles
        public async Task < ActionResult> Index()
        {
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modulo, "List");
                Utilities.url = $"{url}/Perfiles";
                List<Perfil> perfiles = await Utilities.GetListDataAPIAsync<Perfil>();
                return View(perfiles);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        // GET: Perfiles/Details/5
        public async Task < ActionResult> Details(int id)
        {
            ViewBag.nodulos = new List<Modulo>();        
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modulo, "List");
                Utilities.url = $"{url}/Perfiles";
                List<Perfil> perfiles = await Utilities.GetListDataAPIAsync<Perfil>();
                Utilities.url = $"{url}/Modulos";
                List<Modulo> modulos = await Utilities.GetListDataAPIAsync<Modulo>();
                ViewBag.modulos = modulos;
                ViewBag.urlapi = url;
                Perfil perfil = perfiles.Find(x => x.Id == id);
                return View(perfil);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        // GET: Perfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfiles/Create
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

        // GET: Perfiles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Perfiles/Edit/5
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

        // GET: Perfiles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Perfiles/Delete/5
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
