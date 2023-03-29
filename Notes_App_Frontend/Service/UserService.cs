using System.Net.Http.Headers;
using Notes_App_Frontend.Models;

namespace Notes_App_Frontend.Service;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly IUser _user;
    private readonly string adress = "http://localhost:8080/api/v0/user"; //TODO auslagern

    public UserService(HttpClient httpClient, IUser user)
    {
        _httpClient = httpClient;
        _user = user;

    }
    public async Task<bool> getUser()
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);
        
        var responseMessage = await _httpClient.GetAsync(adress+"/get");
        if (responseMessage.IsSuccessStatusCode)
        {
            var responseUser = await responseMessage.Content.ReadFromJsonAsync<UserApi>();
            if (responseUser == null)
            {
                return false;
            }
            _user.updateWithUserApi(responseUser);
            
            return true;
        }
        return false;
    }

    public async Task<bool> saveUser()
    {
        UserApi userApi = new UserApi(_user.FirstName, _user.LastName, _user.email, _user.Settings, _user.Labels);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);

        var response = await _httpClient.PutAsJsonAsync(adress + "/update", userApi);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> changePassword(ChangePasswordApi changePasswordApi)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _user.Token);

        var response = await _httpClient.PutAsJsonAsync(adress + "/changePassword", changePasswordApi);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

}