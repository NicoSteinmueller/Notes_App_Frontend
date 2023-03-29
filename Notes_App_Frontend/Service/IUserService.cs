using Notes_App_Frontend.Models;

namespace Notes_App_Frontend.Service;

public interface IUserService
{
    Task<bool> getUser();
    Task<bool> saveUser();
    Task<bool> changePassword(ChangePasswordApi changePasswordApi);
}