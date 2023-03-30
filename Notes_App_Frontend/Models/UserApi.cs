namespace Notes_App_Frontend.Models;

public class UserApi
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public Settings Settings { get; init; }
    
    public UserApi(string firstName, string lastName, string email, Settings settings)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Settings = settings;
    }

}