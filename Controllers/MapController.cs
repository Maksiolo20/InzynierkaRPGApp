using Microsoft.AspNetCore.Mvc;

namespace RPGApp.Controllers
{
    public class MapController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public MapController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SelectedMap()
        {
            return View();
        }
    }
}
