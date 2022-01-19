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
    public class PermisosController : Controller
    {
        string url;
       
        public PermisosController()
        {
            url = ConfigurationManager.AppSettings["urlapi"];

        }
        // GET: Permisos
        public ActionResult Index()
        {
         
            return View();
        }

        // GET: Permisos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Permisos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permisos/Create
        [HttpPost]
        public async Task  <JsonResult> Create(int idperfil,int idmodulo,string valorPermiso)
        {
            try
            {
                // TODO: Add insert logic here
                Utilities.url = $"{url}/Perfiles/{idperfil}";
                Perfil perfil = await Utilities.GetDataAPIAsync<Perfil>();
                Utilities.url = $"{url}/Modulos/{idmodulo}";
                Modulo modulo = await Utilities.GetDataAPIAsync<Modulo>();
                Permiso permiso = new Permiso
                {
                    Modulo = modulo,
                    Perfil = perfil,
                    ValorPermiso = valorPermiso

                };
                Utilities.url = $"{url}/Permisos";
               await  Utilities.PostDataAPIAsync(permiso);
                return Json("",JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex , JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Permisos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Permisos/Edit/5
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

        // GET: Permisos/Delete/5
        public async Task <ActionResult> Delete(int id)
        {
            try
            {
                Utilities.url = $"{url}/Permisos/{id}";
                await Utilities.DeleteDataAPIAsync();
                return RedirectToAction("index", "perfiles", null);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("index", "perfiles", null);
            }
           
        }

        // POST: Permisos/Delete/5
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
