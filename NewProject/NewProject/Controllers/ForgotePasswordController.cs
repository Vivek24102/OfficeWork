using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using NewProject.Services;
using NewProject.Models;
using NuGet.Common;

namespace NewProject.Controllers
{
    public class ForgotePasswordController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailServices _emailSender;

        public ForgotePasswordController(UserManager<IdentityUser> userManager, IEmailServices IEmailServices)
        {
            _userManager = userManager;
            _emailSender = IEmailServices;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.


        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction("ConfirmPassword", "ConfirmForgotPassword");
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                     "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);



                var lnkHref = "<a href='" + Url.Action("ResetPassword", "ResetPassword", new { code = code}, "http") + "'>Reset Password</a>";
                _emailSender.sendEmail(
                    input.Email,
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.",
                    "Reset Password"); 
                //_emailSender.sendEmail(
                //    input.Email,
                //    $"Please reset your password by <a href='{Url.Action("ResetPassword", "ResetPassword", code)}'>clicking here</a>.",
                //    "Reset Password");

                return RedirectToAction("ConfirmPassword", "ConfirmForgotPassword");
            }

            return View();
        }
    }
}
