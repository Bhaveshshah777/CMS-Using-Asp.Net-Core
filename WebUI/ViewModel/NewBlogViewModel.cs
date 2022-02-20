using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModel
{
    public class NewBlogViewModel
    {
        [MaxLength(100)][Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
