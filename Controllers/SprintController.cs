using FinalProject.Dto;
using FinalProject.Models;
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
    public class SprintController : Controller
    {
        private ISprintRep SprintRep;
        private IProjectRep ProjectRep;
        private IDeveloperRep DeveloperRep;

        public SprintController(ISprintRep SprintRep,  IProjectRep ProjectRep, IDeveloperRep DeveloperRep)
        {
            this.ProjectRep = ProjectRep;
            this.SprintRep = SprintRep;
            this.DeveloperRep = DeveloperRep;
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult ShowSprints(int ProjectId)
        {
            ViewBag.ProjectID = ProjectId;
            ViewBag.Project=ProjectRep.GetProject(ProjectId);

            return View(SprintRep.GetSprints(ProjectId));
        }
        [Authorize(Roles = "DEVELOPER")]
        public IActionResult ShowDeveloperSprints(int ProjectId)
        {
            var DeveloperId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Project = ProjectRep.GetProject(ProjectId);
            ViewBag.Developer = DeveloperRep.GetDeveloper(DeveloperId);
            var ProjectDeveloperSprints = SprintRep.GetDeveloperSprints(ProjectId, DeveloperId);
            return View(ProjectDeveloperSprints);
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult CreatSprint(int ProjectId)
        {
            ViewBag.Project =ProjectRep.GetProject(ProjectId);

            return View();
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult InsertSprint(SprintDto SprintDto)
        {
            SprintRep.InsertSprint(SprintDto);
            var ProjectId = SprintDto.ProjectId;
            return RedirectToAction("ShowSprints" ,"Sprint" , new { ProjectId } );
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult EditSprint(int SprintId)
        {
            var Sprint = SprintRep.GetSprint(SprintId);
            ViewBag.Project = ProjectRep.GetProjectFromSprintId(SprintId);

            return View(Sprint);
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult UpdateSprint(SprintDto SprintDto)
        {
            SprintRep.UpdateSprint(SprintDto);

            return RedirectToAction("ShowSprints", "Sprint", new { SprintDto.ProjectId });
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult ChangeProjectStatus(int ProjectId)
        {

            return RedirectToAction("ShowTeamLeaderProjects", "Project");
        }
       
    }
}
