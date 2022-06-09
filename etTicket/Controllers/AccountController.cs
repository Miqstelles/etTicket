using ADO.Net.Client.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pinegas.Data;
using Pinegas.Data.Static;
using Pinegas.Data.ViewModels;
using Pinegas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.ExternalLoginModel;

namespace Pinegas.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DataContext _context;
        private IPasswordHasher<IdentityUser> _passwordHasher;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string returnUrl)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Produtos");
                    }
                }
                TempData["Error"] = "Email ou senha incorreto!";
                return View(loginVM);
            }

            TempData["Error"] = "Email ou senha incorreto!";
            return View(loginVM);
        }

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }
            if (ModelState.IsValid)
            {
                var newUser = new IdentityUser()
                {
                    UserName = registerVM.Email,
                    Email = registerVM.Email
                };
                var result = await _userManager.CreateAsync(newUser, registerVM.Password);
                if (result.Succeeded)
                {
                    //add role here
                    await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                    return View("RegisterCompleted");
                }
            }
            ModelState.AddModelError("", "Invalid Register.");
            return View(registerVM);
        }

        public async Task<IActionResult> Edit()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userdetails = await _userManager.FindByIdAsync(userid);
            var response = new RegisterVM()
            {
                Email = userdetails.Email
            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegisterVM registerVM)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(registerVM.Email))
                    user.Email = registerVM.Email;
                else
                    ModelState.AddModelError("", "O E-mail não pode ser vazio");

                if (!string.IsNullOrEmpty(registerVM.Email))
                    user.UserName = registerVM.Email;

                if (!string.IsNullOrEmpty(registerVM.Email))
                    user.NormalizedUserName = registerVM.Email;

                if (!string.IsNullOrEmpty(registerVM.Password))
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, registerVM.Password);
                else
                    ModelState.AddModelError("", "A senha não pode ser vazia");

                if (!string.IsNullOrEmpty(registerVM.Email) && !string.IsNullOrEmpty(registerVM.Password))
                {
                    await _userManager.UpdateAsync(user);
                }
            }

            return RedirectToAction("Index", "Produtos");
        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Produtos");
        }

    }
}
