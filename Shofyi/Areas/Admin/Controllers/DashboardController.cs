using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shofyi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin , SuperAdmin")]
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}

