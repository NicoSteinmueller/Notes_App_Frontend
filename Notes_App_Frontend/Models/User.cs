namespace Notes_App_Frontend.Models;

public class User : IUser
{
    public string Token { get; set; }
    public bool IsAuthenticated { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Settings Settings { get; set; } = new Settings { DarkModeOn = false, Language = Language.ENGLISH };
    public List<NoteShort> NotesShort { get; set; } = new List<NoteShort>();

    public void UpdateWithUserApi(UserApi userApi)
    {
        FirstName = userApi.FirstName;
        LastName = userApi.LastName;
        Email = userApi.Email;
        Settings = userApi.Settings;
    }
}