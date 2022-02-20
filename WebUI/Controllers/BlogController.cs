using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext context;

        public BlogController(AppDbContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            var model = context.Blogs;
            return View(model);
        }
    }
}
