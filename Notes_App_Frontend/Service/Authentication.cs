using System.Net.Http.Headers;
using Notes_App_Frontend.Models;

namespace Notes_App_Frontend.Service;
public class Authentication : IAuthentication
{
    private readonly HttpClient _httpClient;
    private readonly IUser _user;
    private readonly string adress = "http://localhost:8080/api/v0/auth"; //TODO in appsetings auslagern

    public Authentication(HttpClient httpClient, IUser user)
    {
        _httpClient = httpClient;
        _user = user;
    }
    
    public async Task<bool> login(string inEmail, string inPassword)
    {
        var requestModel = new AuthenticationRequestModel { email = inEmail, password = inPassword };
        _httpClient.DefaultRequestHeaders.Authorization = null;
        var responseMessage = await _httpClient.PostAsJsonAsync(adress+"/authenticate", requestModel);
        if (responseMessage.IsSuccessStatusCode)
        {
            var responseToken = await responseMessage.Content.ReadFromJsonAsync<AuthenticationResponseModel>();
            _user.Token = responseToken.token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);
            return true;
        }
        
        return false;
    }

    public async Task<bool> register(RegistrationModel registrationModel)
    {
        _httpClient.DefaultRequestHeaders.Authorization = null;
        var responseMessage = await _httpClient.PostAsJsonAsync(adress + "/register", registrationModel);
        if (responseMessage.IsSuccessStatusCode)
        {
            var responseToken = await responseMessage.Content.ReadFromJsonAsync<AuthenticationResponseModel>();
            _user.Token = responseToken.token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);
            return true;
        }
        return false;
    }

    public async Task<bool> checkToken(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.GetAsync("http://localhost:8080/test/hello");
        if (response.IsSuccessStatusCode)
        {
            _user.Token = token;
            return true;
        }

        return false;
    }
}