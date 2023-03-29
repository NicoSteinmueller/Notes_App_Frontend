namespace Notes_App_Frontend.Models;

public class UserApi
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public Settings Settings { get; init; }
    public List<string> Labels { get; init; }
}