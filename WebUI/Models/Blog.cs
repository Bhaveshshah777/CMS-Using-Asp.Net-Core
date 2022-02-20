using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required][MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
