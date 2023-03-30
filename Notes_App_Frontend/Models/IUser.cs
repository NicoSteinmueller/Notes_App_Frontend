namespace Notes_App_Frontend.Models;

public interface IUser
{
    string Token { get; set; }
    bool IsAuthenticated { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    Settings Settings { get; set; }
    List<NoteShort> NotesShort { get; set; }

    public void UpdateWithUserApi(UserApi userApi);
}