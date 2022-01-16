using Factory;
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
        string url;
        public PerfilesController()
        {
            url = ConfigurationManager.AppSettings["urlapi"];
        }
        // GET: Perfiles
        public async Task < ActionResult> Index()
        {
            Utilities.url = $"{url}/Perfiles";
            List<Perfil> perfiles = await Utilities.GetListDataAPIAsync<Perfil>();
            return View(perfiles );
        }

        // GET: Perfiles/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
