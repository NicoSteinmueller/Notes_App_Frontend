namespace Notes_App_Frontend.Models;

public interface IUser
{
    string Token { get; set; }
    bool IsAuthenticated { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string email { get; set; }
    Settings Settings { get; set; }
    List<string> Labels { get; set; }

    public void updateWithUserApi(UserApi userApi);
}