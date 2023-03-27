namespace Notes_App_Frontend.Service;

public interface IAuthentication
{
    public Task<bool> login(string inEmail, string inPassword);
}