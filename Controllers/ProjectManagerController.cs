using FinalProject.Dto;
using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class ProjectManagerController : Controller
    {

        private IProjectManagerRep ProjectManagerRep;
        public ProjectManagerController(IProjectManagerRep ProjectManagerRep)
        {
            this.ProjectManagerRep = ProjectManagerRep;
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult ShowProjectManagers()
        {
           
            return View(ProjectManagerRep.GetProjectManagers());
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult CreatProjectManager()
        {
            return View();
        }


        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> InsertProjectManager (UserDto ProjectManagerDto)
        {
            if (ModelState.IsValid)
            {
                await ProjectManagerRep.InsertProjectManager(ProjectManagerDto);
                return RedirectToAction("ShowProjectManagers");
            }
            else
            {
                return View("CreatProjectManager");
            }
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult EditProjectManager(String ProjectManagerID)
        {
            var ProjectManager = ProjectManagerRep.GetProjectManager(ProjectManagerID);
            var ProjectManagerDto = new UserDto() {
            FirstName= ProjectManager.FirstName,
            LastName= ProjectManager.LastName,
            Id= ProjectManager.Id,
            Email= ProjectManager.Email,
            UserName= ProjectManager.UserName
            };


            return View(ProjectManagerDto);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> UpdateProjectManagerInf(UserDto ProjectManagerDto)
        {

            if (ModelState.IsValid)
            {
                await ProjectManagerRep.UpdateProjectManager(ProjectManagerDto);
                return RedirectToAction("ShowProjectManagers");
            }
            else
            {
                return View("EditProjectManager");
            }
        }

        [Authorize(Roles = "ADMIN")]
        public async Task <String> DeletProjectManager(String ProjectManagerID)
        {
            var Reselt = "YES";
            try
            {
                await ProjectManagerRep.DeletProjectManager(ProjectManagerID);

            }
            catch (Exception)
            {

                Reselt = "NO";
            }

              return JsonConvert.SerializeObject(Reselt);
        }


    }
}
