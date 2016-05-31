using System.Web.Mvc;
using DomainServices;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //public ITestService Service { get; set; }
        ITestService _service;
        public HomeController(ITestService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Show = _service.GetMainData();
            return View();
        }
    }
}