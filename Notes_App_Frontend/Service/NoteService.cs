using System.Net.Http.Headers;
using System.Text.Json;
using Notes_App_Frontend.Models;

namespace Notes_App_Frontend.Service;

public class NoteService : INoteService
{
    private readonly HttpClient _httpClient;
    private readonly IUser _user;
    private readonly string adress = "http://localhost:8080/api/v0/notes"; //TODO auslagern

    public NoteService(HttpClient httpClient, IUser user)
    {
        _httpClient = httpClient;
        _user = user;

    }
    public async Task<List<NoteShort>> GetAllNotesShort()
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);
        var reponse = await _httpClient.GetAsync(adress + "/getAllNotesShort");
        
        if (reponse.IsSuccessStatusCode )
        {
            var stringResult = await reponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<NoteShort>>(stringResult, new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase}) ?? new List<NoteShort>();
            
        }

        return new List<NoteShort>();
    }

    public async Task<Note> GetNote(string id)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);
        var response = await _httpClient.GetAsync(adress + "/getNote?noteId=" + id);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Note>() ?? new Note();
        }

        return new Note();
    }

    public async Task<Note> SaveNote(Note note)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);
        var response = await _httpClient.PostAsJsonAsync(adress + "/saveNote", note);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Note>() ?? new Note();
        }

        return new Note();
    }
    
    public async Task<(NoteShort, bool)> SetNoteFavorite(NoteShort noteShort)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);
        var response = await _httpClient.PostAsJsonAsync(adress + "/setNoteFavorite", noteShort);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<NoteShort>() ?? new NoteShort(), true);
        }

        return (new NoteShort(), false);
    }
    
    public async Task<bool> DeleteNote(string id)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);
        var response = await _httpClient.DeleteAsync(adress + "/deleteNote?noteId=" + id);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }
}