using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace NewProject.Controllers
{
    public class AccountController : Controller
    {
        // Licensed to the .NET Foundation under one or more agreements.



            private readonly SignInManager<IdentityUser> _signInManager;
            private readonly ILogger<LoginModel> _logger;

            public AccountController(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
            {
                _signInManager = signInManager;
                _logger = logger;
            }


               [BindProperty]
           public LoginViewModel Input { get; set; }


           public IList<AuthenticationScheme> ExternalLogins { get; set; }

        [HttpGet]
            public async Task<IActionResult> UserLogin()
            {
             

                // Clear the existing external cookie to ensure a clean login process
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                return View();

            }
                [HttpPost]
            public async Task<IActionResult> UserLogin(string returnUrl = null)
            {
                returnUrl ??= Url.Content("~/");

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                if (ModelState.IsValid)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View();
                    }
                }

                // If we got this far, something failed, redisplay form
                return View();
            }
        }
    }

