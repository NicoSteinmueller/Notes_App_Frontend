using System.ComponentModel.DataAnnotations;

namespace Notes_App_Frontend.Models;

public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}