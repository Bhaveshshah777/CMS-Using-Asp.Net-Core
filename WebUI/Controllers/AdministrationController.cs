using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        private readonly AppDbContext context;

        public AdministrationController(AppDbContext context)
        {
            this.context = context;
        }


        //Our main admin page
        public IActionResult Index()
        {
            var data = new AdminIndexViewModel()
            {
                Blogs = context.Blogs.ToList(),
                Clients = context.Clients.ToList(),
                Testimonials = context.Testimonials.ToList()
            };
            return View(data);
        }


        //Add New Blog Post
        [HttpGet]
        public IActionResult addPost()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult addPost(NewBlogViewModel model)
        {
            if(ModelState.IsValid)
            {
                var blog = new Blog()
                {
                    Title = model.Title,
                    Content = model.Content
                };

                context.Add(blog);
                context.SaveChanges();

                return RedirectToAction("Index", "Administration");
            }
            return View(model);
        }

    }
}
