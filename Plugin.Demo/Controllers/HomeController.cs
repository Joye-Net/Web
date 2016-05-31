using System.Web.Mvc;
using DomainServices;

namespace Plugin.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ITestService Service { get; set; }

        public ActionResult Index()
        {
            ViewBag.Show=Service.GetData();
            return View();
        }
    }
}