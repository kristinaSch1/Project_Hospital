using System.ComponentModel.DataAnnotations;

namespace Hospital_Manager.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter username!")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
