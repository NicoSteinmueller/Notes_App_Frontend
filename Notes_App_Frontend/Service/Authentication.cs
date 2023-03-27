using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Notes_App_Frontend.Models;



namespace Notes_App_Frontend.Service;
public class Authentication : IAuthentication
{
    private readonly HttpClient HttpClient;
    
    private ProtectedBrowserStorage BrowserStorage ;
    private readonly string adress = "http://localhost:8080/api/v0/auth";

    public Authentication(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }
    
    public async Task<bool> login(string inEmail, string inPassword)
    {
        var requestModel = new AuthenticationRequestModel { email = inEmail, password = inPassword };
        var responseMessage = await HttpClient.PostAsJsonAsync("http://localhost:8080/api/v0/auth/authenticate", requestModel);
        if (responseMessage.IsSuccessStatusCode)
        {
            var responseToken = await responseMessage.Content.ReadFromJsonAsync<AuthenticationResponseModel>();
            await BrowserStorage.SetAsync("Notes_App_Token", responseToken.token);
            return true;
        }

        return false;
    }
}