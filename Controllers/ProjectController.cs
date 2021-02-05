using FinalProject.Dto;
using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRep ProjectRep;
        private ITeamLeaderRep TeamLeaderRep;
        private IDeveloperRep DeveloperRep;
        private IProjectManagerRep ProjectManagerRep;
        private ISprintRep SprintRep;
        private ISprintTaskRep SprintTaskRep;
        public ProjectController(IProjectRep ProjectRep ,ITeamLeaderRep TeamLeaderRep , IDeveloperRep DeveloperRep , IProjectManagerRep ProjectManagerRep , ISprintRep SprintRep , ISprintTaskRep SprintTaskRep)
        {
            this.ProjectRep = ProjectRep;
            this.TeamLeaderRep = TeamLeaderRep;
            this.DeveloperRep = DeveloperRep;
            this.ProjectManagerRep = ProjectManagerRep;
            this.SprintRep = SprintRep;
            this.SprintTaskRep = SprintTaskRep;
        }


        [Authorize(Roles = "PROJECTMANAGER")]
        public IActionResult ShowProjects()
        {
            string ProjetManagerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.ProjectManager= ProjectManagerRep.GetProjectManager(ProjetManagerId);
         
            return View(ProjectRep.GetProjects(ProjetManagerId));
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult ShowTeamLeaderProjects()
        {
            string TeamLeaderId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.TeamLeader = TeamLeaderRep.GetTeamLeader(TeamLeaderId);
           
            return View(ProjectRep.GetTeamLeaderWithProjects(TeamLeaderId));
        }

        [Authorize(Roles = "DEVELOPER")]
        public IActionResult ShowDeveloperProjects()
        {
            string DeveloperId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Developer = DeveloperRep.GetDeveloper(DeveloperId);
            List<Project> projects = ProjectRep.GetDeveloperProjects(DeveloperId);
            return View(projects);

        }

        [Authorize(Roles = "PROJECTMANAGER")]
        public IActionResult CreatProject()
        {
            string ProjetManagerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.ProjectManager = ProjectManagerRep.GetProjectManager(ProjetManagerId);
            ViewBag.TeamLeaders = TeamLeaderRep.GetTeamLeaders();
            ViewBag.Developers = DeveloperRep.GetDevelopers();
            return View();
        }
        [Authorize(Roles = "PROJECTMANAGER")]
        public IActionResult InsertProject(ProjectDto ProjectDto)
        {
            string ProjetManagerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ProjectRep.InsertProject(ProjectDto , ProjetManagerId);
            return RedirectToAction("ShowProjects");
        }


        [Authorize(Roles = "PROJECTMANAGER")]
        public IActionResult EditProject(int ProjectId)
        {

            var Project = ProjectRep.GetProject(ProjectId);
            ViewBag.DevelobersForProject= DeveloperRep.GetProjectDevelopers(ProjectId);
            ViewBag.AtherDevelopers = DeveloperRep.DevelopersAfterDeletProjectDevelopers(ProjectId);
            ViewBag.AtherTeamLeaders = TeamLeaderRep.GetAnotherTeamLeaders(Project.TeamLeaderId);
            return View(ProjectRep.GetProject(ProjectId));
        }
        [Authorize(Roles = "PROJECTMANAGER")]
        public IActionResult UpdateProject(ProjectDto ProjectDto)
        {
            ProjectRep.UpdateProject(ProjectDto);
            
            return RedirectToAction("ShowProjects");
        }
        [Authorize(Roles = "PROJECTMANAGER")]
        public IActionResult ProjectDevelopers(int ProjectId)
        {
            
          var Developers= DeveloperRep.GetProjectDevelopers(ProjectId);

            return View(Developers);
        }

        [Authorize(Roles = "TEAMLEADER")]
        public String CompletProject(int ProjectID)
        {
            var Reselt = "No";
            
            var IsProjectComplet= SprintRep.IsAllSprintComplet(ProjectID);
            if (IsProjectComplet)
            {
                Reselt = "YES";
            }
            return JsonConvert.SerializeObject(Reselt);
        }
        
    }
}
