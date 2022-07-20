using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.Services.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CBA.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly AppDbContext context;
        private readonly IMailService mailService;

        public AccountController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, IMailService mailService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.context = context;
            this.mailService = mailService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Status = model.Status
                };
                var result = await userManager.CreateAsync(user, model.Password);

                var mail = new MailRequest
                {
                    ToEmail = model.Email,
                    Subject = model.FirstName,
                    Body = model.Password,
                };

                if (result.Succeeded)
                {
                    //var token = await userManager.CreateAsync(user, model.Password);
                    //var confirmedLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);
                    //logger.Log(LogLevel.Warning, confirmedLink);
                    //if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    //{
                    //   return RedirectToAction("ListUsers", "Administration");
                    // }
                    //ViewBag.ErrorTitle = "Registration successful";
                    //ViewBag.ErrorMessage = "Before you can Login, please confirm your " +
                    //      "email, by clicking on the confirmation link we have emailed you";
                    //return View("Error");
                    await signInManager.SignInAsync(user, isPersistent: false);
                   // await mailService.SendEmailAsync(mail);
                    return RedirectToAction("listusers", "administration");
                }

                foreach (var error in result.Errors)
                {
                    // ModelState.AddModelError("", error.Description);
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> EditUserPassword(EditUser model)
        //{
        //    var user = await userManager.FindByIdAsync(model.Id);

        //   // var password = IMailService.GeneratePassword();
        //    var passHasher = new PasswordHasher<ApplicationUser>();
        //    var hashed = passHasher.HashPassword(user, password);

        //    await userManager.RemovePasswordAsync(user);
        //    var result = await userManager.AddPasswordAsync(user, password);

        //    var mail = new MailRequest
        //    {
        //        ToEmail = model.Email,
        //        Subject = model.LastName,
        //        Body = password,
        //    };

        //    if (result.Succeeded)
        //    {
        //        //await IMailService.SendEmailAsync(mail);
        //        return RedirectToAction("listusers", "administration");
        //    }
        //    return View();
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //        [HttpPost]
        //      [AllowAnonymous]
        //    public async Task<IActionResult> Login(Login model, string returnUrl)
        //  {
        //    if (ModelState.IsValid)
        //  {
        //    var user = await userManager.FindByEmailAsync(model.Email);
        //
        //  if (user != null && !user.EmailConfirmed &&
        //            (await userManager.CheckPasswordAsync(user, model.Password)))
        //{
        //  ModelState.AddModelError(string.Empty, "Email not confirmed yet");
        //return View(model);
        // }

        //var result = await signInManager.PasswordSignInAsync(model.Email,
        //  model.Password, model.RememberMe, false);
        //
        //if (result.Succeeded)
        // {
        //   if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        // {
        //   return Redirect(returnUrl);
        //}
        //else
        //{
        //  return RedirectToAction("Index", "Home");

        // }
        //}

        //  ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        // }
        //  return View(model);
        //  }

        [HttpPost]
        public async Task<IActionResult> Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && user.Status != Core.Enums.Status.Enabled)
                {
                    ModelState.AddModelError(string.Empty, "User is inactive");
                    return View(model);
                }
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false );

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }
                
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt, check details");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                var result = await userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                await signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }

            return View(model);
        }


       // [Authorize(Roles = "Admin")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }


        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                            new { email = model.Email, token = token }, Request.Scheme);

                    logger.Log(LogLevel.Warning, passwordResetLink);

                    return View("ForgotPasswordConfirmation");
                }
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }
            return View(model);
        }

        

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
