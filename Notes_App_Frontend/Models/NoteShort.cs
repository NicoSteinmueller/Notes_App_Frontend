namespace Notes_App_Frontend.Models;

public class NoteShort
{
    public string Id { get; set; }
    public string Title { get; set; }
    public DateTime Modified { get; set; }
    public bool Favorite { get; set; }
}