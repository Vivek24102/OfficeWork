// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using WebApiIdentityDemo.Model;
using WebApiIdentityDemo.Services.AccountRepository;
using WebApiIdentityDemo.Services.EmailRepository;
using WebApiIdentityDemo.Services.OtpGenrator;
using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.RegisterModel;

namespace WebApiIdentityDemo.Areas.Identity.Pages.Account
{
    public class SignUpRepository : PageModel, ISignUpRepository
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailRepository _emailSender;
        private readonly IOtpRepository _otp;

        public SignUpRepository(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailRepository emailSender,
            IOtpRepository otp)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            this._otp = otp;
        }





        public async Task<string> Register(InputModel Input)
        {


            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var data = _otp.randomNumber().ToString();
                    _emailSender.sendEmail(Input.Email, data, "Your otp  is");


                    //var userdetails = await _userManager.FindByEmailAsync(Input.Email);

                    //if(userdetails.Email ==  Input.Email)
                    //{
                    //    //match condition of the OTP
                    //    //true or false
                    //    if(OTP == OTP)
                    //    {
                    //        userdetails.EmailConfirmed = true;
                    //        await _userManager.UpdateAsync(userdetails);
                    //    }
                    //}

                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = userId, code = code},
                    //    protocol: Request.Scheme);

                    //await _emailSender.sendEmail(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    return data;

                }

            }

            // If we got this far, something failed, redisplay form
            return "error";
        }
        public async Task<string> checkotp (string email)
        {
            var userdetail = await _userManager.FindByEmailAsync(email);
            if(userdetail.Email == email)
            {
                userdetail.EmailConfirmed = true;
                await _userManager.UpdateAsync(userdetail);
                
            }
            return "success";
        }

        

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}

