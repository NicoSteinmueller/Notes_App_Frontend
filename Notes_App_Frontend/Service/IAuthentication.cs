using Notes_App_Frontend.Models;

namespace Notes_App_Frontend.Service;

public interface IAuthentication
{
    public Task<bool> login(string inEmail, string inPassword);
    public Task<bool> checkToken(string token);
    public Task<bool> register(RegistrationModel registrationModel);
}