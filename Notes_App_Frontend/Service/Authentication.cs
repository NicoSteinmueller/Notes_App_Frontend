using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Notes_App_Frontend.Models;



namespace Notes_App_Frontend.Service;
public class Authentication : IAuthentication
{
    private readonly HttpClient _httpClient;
    
    //private ProtectedBrowserStorage BrowserStorage ; nur in Pages /Layout möglich
    private readonly IUser _user;
    private readonly string adress = "http://localhost:8080/api/v0/auth";

    public Authentication(HttpClient httpClient, IUser user)
    {
        _httpClient = httpClient;
        _user = user;
    }
    
    public async Task<bool> login(string inEmail, string inPassword)
    {
        var requestModel = new AuthenticationRequestModel { email = inEmail, password = inPassword };
        var responseMessage = await _httpClient.PostAsJsonAsync("http://localhost:8080/api/v0/auth/authenticate", requestModel);
        if (responseMessage.IsSuccessStatusCode)
        {
            var responseToken = await responseMessage.Content.ReadFromJsonAsync<AuthenticationResponseModel>();
            _user.Token = responseToken.token;
            return true;
        }
        
        return false;
    }
}