using FinalProject.Dto;
using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class WorkController : Controller
    {
        private ISprintTaskRep SprintTaskRep;
        private ISprintRep SprintRep;
        private IProjectRep ProjectRep;
        private IWorkRep WorkRep;
        private ITeamLeaderRep TeamLeaderRep;
        private IDeveloperRep DeveloperRep;

        public WorkController(IWorkRep WorkRep , IProjectRep ProjectRep, ISprintTaskRep SprintTaskRep , ISprintRep SprintRep , ITeamLeaderRep TeamLeaderRep , IDeveloperRep DeveloperRep)
        {
            this.WorkRep = WorkRep;
            this.ProjectRep = ProjectRep;
            this.SprintTaskRep = SprintTaskRep;
            this.SprintRep = SprintRep;
            this.TeamLeaderRep = TeamLeaderRep;
            this.DeveloperRep = DeveloperRep;
        }
       
        [Authorize(Roles = "DEVELOPER")]
        public IActionResult ShowWorks(int SprintTaskId)
        {
            var DeveloperId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var SprintTask = SprintTaskRep.GetSprintTask(SprintTaskId);
            ViewBag.Developer = DeveloperRep.GetDeveloper(DeveloperId);
            ViewBag.SprintTask = SprintTask;
            ViewBag.project = ProjectRep.GetProjectFromSprintId(SprintTask.SprintId);
            ViewBag.AllWorks = WorkRep.GetWorks(SprintTaskId, DeveloperId);
            return View();
        }
        
        [Authorize(Roles = "DEVELOPER")]
        public String SubmitAllWorks(int SprintTaskId)
        {
            var Reselt = "NOT";
            var IsAllWorksApproved = WorkRep.IsAllWorksApproved(SprintTaskId);
            if (IsAllWorksApproved) 
            {
                //All works for this SprintTask is Approved....> make SprintTask Completed  
                SprintTaskRep.CompletedSprintTask(SprintTaskId);
                Reselt = "YES";
                //need to check Sprint.......> IsAllSprintTaskComplet
                
                    var SprintTask = SprintTaskRep.GetSprintTask(SprintTaskId);
                    var Sprint = SprintRep.GetSprint(SprintTask.SprintId);
                    var IsSprintComplet = SprintTaskRep.IsAllSprintTaskComplet(Sprint);//if all SprintTaskComplet...>Sprint Complet

            }

            return JsonConvert.SerializeObject(Reselt);
        }

        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult ShowTeamLeaderWorks(int SprintTaskId)
        {
            var TeamLeader = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var SprintTask = SprintTaskRep.GetSprintTask(SprintTaskId);
            ViewBag.SprintTask = SprintTask;
            ViewBag.project = ProjectRep.GetProjectFromSprintId(SprintTask.SprintId);
            return View(WorkRep.GetSprintTaskWorks(SprintTaskId));
        }

        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult ViewWork(int WorkId)
        {
            var Work = WorkRep.GetWork(WorkId);

            return View(Work);
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult RejectedWork(int WorkId , string RejectionNote , int SprintTaskId)
        {
            WorkRep.RejectedWork(WorkId , RejectionNote);
            return RedirectToAction("ShowTeamLeaderWorks" ,new { SprintTaskId });
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult TeamLeaderApprovedWork(int WorkId , int SprintTaskId)
        {
            
            WorkRep.ApprovedWork(WorkId);
            return RedirectToAction("ShowTeamLeaderWorks", new { SprintTaskId });
        }

       
        [Authorize(Roles = "PROJECTMANAGER , TEAMLEADER")]
        public FileStreamResult GetFile(int WorkId) //return file on stream
        {
            var Work = WorkRep.GetWork(WorkId); //get Teacher with byte to stream file
            Stream Stream = new MemoryStream(Work.TheFile); //open stream from memorystream......> Convert from byte to stream
            return new FileStreamResult(Stream, Work.ContentType);
        }


        [Authorize(Roles = "PROJECTMANAGER")]
        public IActionResult ShowProjectManagerWorks(int ProjectId)
        {
            var ProjectManajerId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
           var Projects= ProjectRep.GetProjectManagerWorks(ProjectId);

            ViewBag.projects = Projects;

            return View();
        }

        [Authorize(Roles = "DEVELOPER")]
        public IActionResult CreatWork(int SprintTaskId)
        {
            var DeveloperId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.DeveloperId = DeveloperId;
            ViewBag.SprintTask = SprintTaskRep.GetSprintTask(SprintTaskId);

            return View();
        }
        [Authorize(Roles = "DEVELOPER")]
        public IActionResult InsertWork(WorkDto WorkDto)
        {
            var DeveloperId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            WorkRep.InsertWork(WorkDto, DeveloperId);
            var Developer = DeveloperRep.GetDeveloper(DeveloperId);
            var SprintTask = SprintTaskRep.GetSprintTask(WorkDto.SprintTaskId);
            var Sprint = SprintRep.GetSprint(SprintTask.SprintId);
            var TeamLeader = TeamLeaderRep.GetTeamLeaderFroSprintId(Sprint.Id);
            try
            {
                WorkRep.SendMail(TeamLeader, Developer);
            }
            catch (Exception)
            {

                return RedirectToAction("ShowWorks", "Work", new { WorkDto.SprintTaskId });
            }

            return RedirectToAction("ShowWorks", "Work", new { WorkDto.SprintTaskId });
        }

       
        [Authorize(Roles = "DEVELOPER")]
        public IActionResult EditWork(int WorkId)
        {
            var DeveloperId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var Work = WorkRep.GetWork(WorkId);
            return View(Work);
        }
        [Authorize(Roles = "DEVELOPER")]
        public IActionResult UpdateWork(WorkDto WorkDto)
        {
            var DeveloperId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            WorkDto.DeveloperId = DeveloperId;
            WorkRep.UpdateWork(WorkDto);
            //send email
            var Developer = DeveloperRep.GetDeveloper(DeveloperId);
            var SprintTask = SprintTaskRep.GetSprintTask(WorkDto.SprintTaskId);
            var Sprint = SprintRep.GetSprint(SprintTask.SprintId);
            var TeamLeader = TeamLeaderRep.GetTeamLeaderFroSprintId(Sprint.Id);
            try
            {
                WorkRep.SendMail(TeamLeader, Developer);
            }
            catch (Exception)
            {

                return RedirectToAction("ShowWorks", "Work", new { WorkDto.SprintTaskId });
            }
           
            return RedirectToAction("ShowWorks", "Work", new { WorkDto.SprintTaskId });
        }

        public IActionResult DeletWork(int WorkId)
        {
            var Work = WorkRep.GetWork(WorkId);
            WorkRep.DeletWork(Work);
            return RedirectToAction("ShowWorks", new { Work.SprintTaskId });
        }

    }
}
