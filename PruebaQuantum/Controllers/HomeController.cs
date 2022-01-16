using Factory;
using System.Web.Mvc;
namespace PruebaQuantum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {        
            Usuario usuario = (Usuario)Session["usuario"];
            return View(usuario );
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Cerrarsesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("index");
        }
    }
}