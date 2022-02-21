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


        [HttpGet]
        public IActionResult Article(int? id)
        {
            if(id == null)
                return NotFound();

            var article = context.Blogs.FirstOrDefault(b => b.Id == id);

            if (article == null)
                return NotFound();

            ViewData["Title"] = article.Title;
            return View(article);
        }


    }
}
