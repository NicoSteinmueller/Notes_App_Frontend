namespace Notes_App_Frontend.Models;

public class User : IUser
{
    public string Token { get; set; }
    public bool IsAuthenticated { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string email { get; set; }
    public Settings Settings { get; set; }
    public List<string> Labels { get; set; }

    public void updateWithUserApi(UserApi userApi)
    {
        FirstName = userApi.FirstName;
        LastName = userApi.LastName;
        email = userApi.Email;
        Settings = userApi.Settings;
        Labels = userApi.Labels;
    }
}