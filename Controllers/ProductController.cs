using Microsoft.AspNetCore.Mvc;

namespace FureaApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}

