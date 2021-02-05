using FinalProject.Dto;
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
    public class DeveloperController : Controller
    {

        private IDeveloperRep DeveloperRep;
        public DeveloperController(IDeveloperRep DeveloperRep)
        {
            this.DeveloperRep = DeveloperRep;
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult ShowDevelopers()
        {

            return View(DeveloperRep.GetDevelopers());
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult CreatDeveloper()
        {
            return View();
        }


        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> InsertDeveloper(UserDto DeveloperDto)
        {
            if (ModelState.IsValid)
            {
                await DeveloperRep.InsertDeveloper(DeveloperDto);
                return RedirectToAction("ShowDevelopers");
            }
            else
            {
                return View("CreatDeveloper");
            }
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult EditDeveloper(String DeveloperID)
        {
            var Developer = DeveloperRep.GetDeveloper(DeveloperID);
            var DeveloperDto = new UserDto()
            {
                FirstName = Developer.FirstName,
                LastName = Developer.LastName,
                Id = Developer.Id,
                Email = Developer.Email,
                UserName = Developer.UserName
            };


            return View(DeveloperDto);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> UpdateDeveloperInf(UserDto DeveloperDto)
        {

            if (ModelState.IsValid)
            {
                await DeveloperRep.UpdateDeveloper(DeveloperDto);
                return RedirectToAction("ShowDevelopers");
            }
            else
            {
                return View("EditDeveloper");
            }
        }


        [Authorize(Roles = "ADMIN")]
        public async Task<string> DeletDeveloper(String DeveloperID)
        {
            var Reselt="YES";
            try
            {
                await DeveloperRep.DeletDeveloper(DeveloperID);
            }
            catch (Exception)
            {
                Reselt = "NO";
                return JsonConvert.SerializeObject(Reselt);
            }


            return JsonConvert.SerializeObject(Reselt);
        }


    }
}
