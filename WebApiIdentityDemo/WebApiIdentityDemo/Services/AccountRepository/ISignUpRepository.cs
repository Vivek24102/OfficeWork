using Microsoft.AspNetCore.Mvc;
using WebApiIdentityDemo.Model;
using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.RegisterModel;

namespace WebApiIdentityDemo.Services.AccountRepository
{
    public interface ISignUpRepository
    {
        Task<string> Register(InputModel Input);

        Task<string> checkotp(string email);
    }
}
