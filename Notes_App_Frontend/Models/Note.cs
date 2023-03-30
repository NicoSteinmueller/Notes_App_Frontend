namespace Notes_App_Frontend.Models;

public class Note
{
    public string ID { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public bool Favorite { get; set; }
}