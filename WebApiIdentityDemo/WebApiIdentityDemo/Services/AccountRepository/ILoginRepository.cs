using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.LoginModel;

namespace WebApiIdentityDemo.Services.AccountRepository
{
    public interface ILoginRepository
    {
        Task<string> login(InputModel Input);
    }
}
