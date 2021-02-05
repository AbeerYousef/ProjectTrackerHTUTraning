using FinalProject.Dto;
using FinalProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ApiProjectController : ControllerBase
    {
        private IProjectManagerRep ProjectManagerRep;
        private IWorkRep WorkRep;
        private ISprintTaskRep SprintTaskRep;
        public ApiProjectController(IProjectManagerRep ProjectManagerRep, IWorkRep WorkRep, ISprintTaskRep SprintTaskRep)
        {
            this.ProjectManagerRep = ProjectManagerRep;
            this.WorkRep = WorkRep;
            this.SprintTaskRep = SprintTaskRep;
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult APIShowProjectManagers()
        {
            var ProjectManagers = ProjectManagerRep.GetProjectManagers().Select(x =>
            new ProjectManagerDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email =x.Email,
            }

            );
            return new JsonResult(ProjectManagers);  //convert to Joson
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet("{ProjectManagerID}")]
        public IActionResult GetProjectManager(string ProjectManagerID)
        {
            var ProjectManager = ProjectManagerRep.GetProjectManager(ProjectManagerID);
          
            return new JsonResult(ProjectManager);  //convert to Joson
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]  //Add .....>    /api/ApiProject/APIInsertProjectManager 
        public async Task<IActionResult> APIInsertProjectManager([FromBody] UserDto ProjectManagerDto)
        {
            if (ModelState.IsValid)
            {
                await ProjectManagerRep.InsertProjectManager(ProjectManagerDto);
                return RedirectToAction("APIShowProjectManagers");
            }
            else
            {
                return RedirectToAction("APIShowProjectManagers");
            }
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPut("{ProjectManagerId}")]  //Edit ....>   /api/ApiProject/APIEditProjectManager/0147383
        public async Task<IActionResult> APIEditProjectManager( string ProjectManagerId, [FromBody]UserDto ProjectManager)
        {

            if (ModelState.IsValid)
            {
                await ProjectManagerRep.UpdateProjectManager(ProjectManager);
                return RedirectToAction("APIShowProjectManagers");
            }
            else
            {
                return RedirectToAction("APIShowProjectManagers");
            }
        }
        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{ProjectManagerID}")]  // .....>   /api/ApiProject/APIDeleteProjectManager/0147383
        public async Task<IActionResult> APIDeleteProjectManager(String ProjectManagerID)
        {
            
            try
            {
                await ProjectManagerRep.DeletProjectManager(ProjectManagerID);

            }
            catch (Exception)
            {

                return RedirectToAction("APIShowProjectManagers");
            }

            return RedirectToAction("APIShowProjectManagers");
        }


    }
}



//500= internal server error
//200 = success
//400 or 404 = not found

///api/ApiProject/APIInsertProjectManager  APICreatProjectManager   APIDeleteProjectManager
///api/ApiProject/APIShowProjectManagers
//{
//    "FirstName":"Ahmad",
//    "LastName": "Yousef",
//    "Email":"AhmadYousef@gmail.com",
//    "Password":"Aa$079",
//    "ComperPassword":"ComperPassword",
//    "UserName":"AhmadYousef@gmail.com"
//}

