using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
