namespace Notes_App_Frontend.Models;

public class ChangePasswordApi
{
    public string oldPassword { get; init; }
    public string newPassword { get; init; }
    
    public ChangePasswordApi(string oldPassword, string newPassword)
    {
        this.oldPassword = oldPassword;
        this.newPassword = newPassword;
    }
}