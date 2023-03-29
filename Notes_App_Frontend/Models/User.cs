namespace Notes_App_Frontend.Models;

public class User : IUser
{
    public string Token { get; set; }
    public bool IsAuthenticated { get; set; }
    public string email { get; set; }
}