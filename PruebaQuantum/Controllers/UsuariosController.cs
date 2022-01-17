using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Factory;
using System.Threading.Tasks;
using Helper;
namespace PruebaQuantum.Controllers
{
    public class UsuariosController : Controller
    {
        string url;
        Usuario usuario;
        string modulo = "Usuarios";
        List<Usuario> usuarios;
        public UsuariosController()
        {
            url = ConfigurationManager.AppSettings["urlapi"];
        }
        
        public async Task<JsonResult >Login(string user ,string contraseña)
        {
            try
            {
                Utilities.url = $"{url}/Usuarios?user={user}&contraseña={contraseña}";
                Usuario usuario = await Utilities.GetDataAPIAsync<Usuario>();
                Session["usuario"] = usuario;
                return Json(usuario , JsonRequestBehavior.AllowGet);

            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }
       [HttpPost ]
        public ActionResult logout()
        {
            Session["usuario"] = null;
            return RedirectToAction("index","home",null );
        }

        // GET: Usuarios
        public async Task <ActionResult >Index()
        {
            try
            {

                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modulo, "List");
                Utilities.url = $"{url}/Usuarios";
                usuarios = await Utilities.GetListDataAPIAsync<Usuario>();
                return View(usuarios);
            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        // GET: Usuarios/Details/5
        public async Task < ActionResult >Details(int id)
        {
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modulo, "Details");
                Utilities.url = $"{url}/Usuarios/{id}";
                usuario = await Utilities.GetDataAPIAsync<Usuario>();
                return View(usuario);
            }
            catch(Exception ex)
            {
                TempData["error"]=ex.Message ;
                return RedirectToAction("index", "home", null);

            }
        }

        // GET: Usuarios/Create
        public async  Task  <ActionResult >Create()
        {
            List<Perfil> perfiles = new List<Perfil>();
            List<TipoIdentificacion> TiposIdentificacion =new List<TipoIdentificacion>();
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modulo, "Create");
                Utilities.url = $"{url}/Perfiles";
                perfiles = await Utilities.GetListDataAPIAsync<Perfil>();
                Utilities.url = $"{url}/TipoIdentificacion";
                TiposIdentificacion = await Utilities.GetListDataAPIAsync<TipoIdentificacion>();
                ViewBag.perfiles = perfiles;
                ViewBag.TiposIdentificacion = TiposIdentificacion;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.perfiles = perfiles;
                ViewBag.TiposIdentificacion = TiposIdentificacion;
                TempData["error"] = ex.Message;
                return RedirectToAction("index","home",null);
            }
        }

        // POST: Usuarios/Create
        [HttpPost]
        public async Task < ActionResult> Create(FormCollection collection)
        {
            List<Perfil> perfiles = new List<Perfil>();
            List<TipoIdentificacion> TiposIdentificacion = new List<TipoIdentificacion>();
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modulo, "Create");
                // TODO: Add insert logic here
                Utilities.url = $"{url}/TipoIdentificacion/{collection["tiposidentificacion"]}";
                TipoIdentificacion tipoIdentificacion =await  Utilities.GetDataAPIAsync<TipoIdentificacion>();                
                Utilities.url = $"{url}/perfiles/{collection["perfiles"]}";
                Perfil perfil = await Utilities.GetDataAPIAsync<Perfil>();
                usuario = new Usuario
                {
                    Perfil =perfil ,
                    TipoIdentificacion =tipoIdentificacion ,
                    Identificacion = collection["identificacion"],
                    Nombre = collection["nombre"],
                    Apellido = collection["apellido"],
                    Direccion = collection["direccion"],
                    Telefono = collection["telefono"],
                    Email = collection["email"],
                    NombreUsuario = collection["nombreUsuario"],
                    Contraseña =Utilities .Encriptar ( collection["contraseña"])
                };
                Utilities.url = $"{url }/Usuarios";
                string resp =await  Utilities.PostDataAPIAsync<Usuario>(usuario);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.perfiles = perfiles;
                ViewBag.TiposIdentificacion = TiposIdentificacion;
                TempData["error"] = ex.Message;
                return RedirectToAction("index", "home", null);
            }
        }

        // GET: Usuarios/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            List<Perfil> perfiles = new List<Perfil>();
            List<TipoIdentificacion> TiposIdentificacion = new List<TipoIdentificacion>();
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modulo, "Edit");
                Utilities.url = $"{url}/Perfiles";
                perfiles = await Utilities.GetListDataAPIAsync<Perfil>();
                Utilities.url = $"{url}/TipoIdentificacion";
                TiposIdentificacion = await Utilities.GetListDataAPIAsync<TipoIdentificacion>();
                ViewBag.perfiles = perfiles;
                ViewBag.TiposIdentificacion = TiposIdentificacion;
                Utilities.url = $"{url}/Usuarios/{id}";
                 usuario = await Utilities.GetDataAPIAsync<Usuario>();
                return View(usuario );
            }
            catch (Exception ex)
            {
                ViewBag.perfiles = perfiles;
                ViewBag.TiposIdentificacion = TiposIdentificacion;
                TempData["error"] = ex.Message;
                return RedirectToAction("index", "home", null);
            }
            
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public async Task <ActionResult> Edit(int id, FormCollection collection)
        {
            List<Perfil> perfiles = new List<Perfil>();
            List<TipoIdentificacion> TiposIdentificacion = new List<TipoIdentificacion>();
            try
            {
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modulo, "Edit");
                // TODO: Add insert logic here
                Utilities.url = $"{url}/TipoIdentificacion/{collection["tiposidentificacion"]}";
                TipoIdentificacion tipoIdentificacion = await Utilities.GetDataAPIAsync<TipoIdentificacion>();
                Utilities.url = $"{url}/perfiles/{collection["perfiles"]}";
                Perfil perfil = await Utilities.GetDataAPIAsync<Perfil>();
                usuario = new Usuario
                {
                    Perfil = perfil,
                    Id = id,
                    TipoIdentificacion = tipoIdentificacion,
                    Identificacion = collection["identificacion"],
                    Nombre = collection["nombre"],
                    Apellido = collection["apellido"],
                    Direccion = collection["direccion"],
                    Telefono = collection["telefono"],
                    Email = collection["email"],
                    NombreUsuario = collection["nombreUsuario"],
                    Contraseña = Utilities.Encriptar(collection["contraseña"])
                };
                Utilities.url = $"{url }/Usuarios";
                string resp = await Utilities.PUTDataAPIAsync<Usuario>(usuario);
                return RedirectToAction("index", "home", null);
            }
            catch (Exception ex)
            {
                ViewBag.perfiles = perfiles;
                ViewBag.TiposIdentificacion = TiposIdentificacion;
                TempData["error"] = ex.Message;
                return RedirectToAction("index", "home", null);
            }   // TODO: Add update logic here

          
        }

       // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                usuario = (Usuario)Session["usuario"];
                Logica.verificarPermisos(usuario, modulo, "Delete");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("index", "home", null);
            }
        }
    }
}
