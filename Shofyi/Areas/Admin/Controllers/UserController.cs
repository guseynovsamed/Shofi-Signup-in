using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shofyi.Models;
using Shofyi.ViewModels.Users;

namespace Shofyi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<UserRolesVM> userRoles = new();
                
            var users = await _userManager.Users.ToListAsync();

            foreach(var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                string rolesStr = string.Join(",", roles.ToArray());

                userRoles.Add(new UserRolesVM
                {
                    FullName = user.FullName,
                    Roles = rolesStr,
                    Email = user.Email,
                    Username = user.UserName
                });
            }

            return View(userRoles);
        }
    }
}