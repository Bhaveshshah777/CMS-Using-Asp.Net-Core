using WebUI.Models;

namespace WebUI.ViewModel
{
    public class HomeIndexViewModel
    {
        public List<Blog> Blogs { get; set; } = new List<Blog>();

        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Testimonial> Testimonials { get; set; } = new List<Testimonial>();

    }
}
