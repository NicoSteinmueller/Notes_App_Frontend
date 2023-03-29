namespace Notes_App_Frontend.Models;

public interface IUser
{
    string Token { get; set; }
    bool IsAuthenticated { get; set; }
    string email { get; set; }
}