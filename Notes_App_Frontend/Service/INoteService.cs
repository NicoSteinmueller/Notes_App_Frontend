using Notes_App_Frontend.Models;

namespace Notes_App_Frontend.Service;

public interface INoteService
{
    Task<List<NoteShort>> GetAllNotesShort();
    Task<Note> GetNote(string id);
    Task<Note> SaveNote(Note note);
    Task<(NoteShort, bool)> SetNoteFavorite(NoteShort noteShort);
    Task<bool> DeleteNote(string id);
}