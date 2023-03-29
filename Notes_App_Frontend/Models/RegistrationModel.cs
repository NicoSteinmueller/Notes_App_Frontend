using System.ComponentModel.DataAnnotations;

namespace Notes_App_Frontend.Models;

public class RegistrationModel
{
    public string FirstName  { get; set; }
    public string LastName  { get; set; }
    public string Email  { get; set; }
    public string Password  { get; set; }
}