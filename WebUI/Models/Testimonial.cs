using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }
        [Required][MinLength(2)][MaxLength(100)]
        public string ClientName { get; set; }
        [Required][MinLength(5)]
        public string Say { get; set; }
        public string? ImageUrl { get; set; }
    }
}
