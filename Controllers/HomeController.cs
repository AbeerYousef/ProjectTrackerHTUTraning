using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ITeamLeaderRep TeamLeaderRep;
        private IDeveloperRep DeveloperRep;
        private IProjectManagerRep ProjectManagerRep;

        public HomeController(ILogger<HomeController> logger, ITeamLeaderRep TeamLeaderRep, IDeveloperRep DeveloperRep, IProjectManagerRep ProjectManagerRep)
        {
            _logger = logger;
            this.TeamLeaderRep = TeamLeaderRep;
            this.DeveloperRep = DeveloperRep;
            this.ProjectManagerRep = ProjectManagerRep;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("DEVELOPER") || User.IsInRole("ADMIN") || User.IsInRole("TEAMLEADER") || User.IsInRole("PROJECTMANAGER"))
            {
                string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (User.IsInRole("TEAMLEADER"))
                {
                    var TeamLeader = TeamLeaderRep.GetTeamLeader(UserId);
                    ViewBag.User = TeamLeader.FirstName + " " + TeamLeader.LastName;
                }
                if (User.IsInRole("PROJECTMANAGER"))
                {
                    var DEVELOPER =ProjectManagerRep.GetProjectManager(UserId);
                    ViewBag.User = DEVELOPER.FirstName + " " + DEVELOPER.LastName;
                }
                if (User.IsInRole("DEVELOPER"))
                {
                    var PROJECTMANAGER = DeveloperRep.GetDeveloper(UserId);
                    ViewBag.User = PROJECTMANAGER.FirstName + " " + PROJECTMANAGER.LastName;
                }
            }



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
