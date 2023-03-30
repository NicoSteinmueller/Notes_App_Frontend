using Notes_App_Frontend.Models;

namespace Notes_App_Frontend.Service;

public interface INoteService
{
    Task<List<NoteShort>> GetAllNotesShort();
}