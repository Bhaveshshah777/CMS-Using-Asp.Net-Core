using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModel
{
    public class RegisterViewModel
    {
        [Required][EmailAddress]
        public string Email { get; set; }
        [Required][DataType(DataType.Password)]
        public string Password { get; set; }
        [Required][Compare("Password", ErrorMessage ="Password doesn't matched")][DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
