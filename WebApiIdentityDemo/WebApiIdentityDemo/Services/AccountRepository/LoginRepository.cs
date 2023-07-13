using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.LoginModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebApiIdentityDemo.Services.AccountRepository
{
    public class LoginRepository : PageModel, ILoginRepository
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginRepository> _logger;

        public LoginRepository(SignInManager<IdentityUser> signInManager, ILogger<LoginRepository> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

       


        public async Task<string> login(InputModel Input)
        {


            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return "Success";

                }
                if (result.RequiresTwoFactor)
                {

                   


                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                   
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return "Invalid login attempt";


                }
            }

            // If we got this far, something failed, redisplay form
            return "error";
        }
    }
}
