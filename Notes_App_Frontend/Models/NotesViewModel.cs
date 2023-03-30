namespace Notes_App_Frontend.Models;

public class NotesViewModel
{
    public int Id { get; init; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime Edited { get; set; }
    
    public bool Favorite { get; set; }
}