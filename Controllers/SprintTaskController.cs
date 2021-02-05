using FinalProject.Dto;
using FinalProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class SprintTaskController : Controller
    {
        private ISprintTaskRep SprintTaskRep;
        private ISprintRep SprintRep;
        private IProjectRep ProjectRep;
        private IDeveloperRep DeveloperRep;

        public SprintTaskController(ISprintRep SprintRep, IProjectRep ProjectRep , ISprintTaskRep SprintTaskRep , IDeveloperRep DeveloperRep)
        {
            this.ProjectRep = ProjectRep;
            this.SprintRep = SprintRep;
            this.SprintTaskRep = SprintTaskRep;
            this.DeveloperRep = DeveloperRep;
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult ShowSprintTasks(int SprintId)
        {
            ViewBag.Sprint = SprintRep.GetSprint(SprintId);
            ViewBag.SprintTasks = SprintTaskRep.GetSprintTasks(SprintId);
           return View();
        }
        [Authorize(Roles = "DEVELOPER")]
        public IActionResult ShowDeveloperSprintTasks(int SprintId)
        {
            ViewBag.Project = ProjectRep.GetProjectFromSprintId(SprintId);
            var DeveloperId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Developer = DeveloperRep.GetDeveloper(DeveloperId);
            ViewBag.Sprint = SprintRep.GetSprint(SprintId);
            var DeveloperSprintTasks = SprintTaskRep.GetDeveloperSprintTasks(SprintId, DeveloperId);
            return View(DeveloperSprintTasks);
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult CreatSprintTask(int SprintId)
        {
            var Project=ProjectRep.GetProjectFromSprintId(SprintId);
            ViewBag.SprintId = SprintId;
            ViewBag.Developers = DeveloperRep.GetProjectDevelopers(Project.Id);

            return View();

        }
        [Authorize(Roles = "TEAMLEADER")] 
        public IActionResult InsertSprintTask(SprintTaskDto SprintTaskDto)
        {
            SprintTaskRep.InsertSprintTask(SprintTaskDto);
            return RedirectToAction("ShowSprintTasks", "SprintTask", new { SprintTaskDto.SprintId });
        }


    }
}
