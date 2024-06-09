using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shofyi.Helpers.Enum;
using Shofyi.Models;
using Shofyi.ViewModels.Accounts;

namespace Shofyi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController( UserManager<AppUser> userManager,
                                  SignInManager<AppUser> signInManager,
                                  RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(ResgisterVM request)
        {
            if(ModelState.IsValid is false)
            {
                return View(request);
            }

            AppUser user = new()
            {
                UserName = request.Username,
                Email=request.Email,
                FullName=request.Email
            };

            var result = await _userManager.CreateAsync(user , request.Password);

            if(result.Succeeded is false)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                    return View(request);
            }


            await _userManager.AddToRoleAsync(user, nameof(Roles.SuperAdmin));

            //await _userManager.AddToRoleAsync(user, nameof(Roles.Admin));

            //await _userManager.AddToRoleAsync(user, nameof(Roles.Member));




            return RedirectToAction("Index","Home") ;
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }




        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public  async Task<IActionResult> SignIn(LoginVM request)
        {
            if(ModelState.IsValid is false)
            {
                return View();
            }

            var existUser = await _userManager.FindByEmailAsync(request.EmailOrUsername);

            if(existUser is null)
            {
                existUser = await _userManager.FindByNameAsync(request.EmailOrUsername);
            }

            if(existUser is null)
            {
                ModelState.AddModelError(string.Empty, "Login failed");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(existUser,request.Password,false,false);

            if(result.Succeeded is false)
            {
                ModelState.AddModelError(string.Empty, "Login failed");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(nameof(role)))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }

            return Ok();
        }
    }
}

