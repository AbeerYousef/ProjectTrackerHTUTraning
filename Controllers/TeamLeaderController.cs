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
    public class TeamLeaderController : Controller
    {
        private ITeamLeaderRep TeamLeaderRep ;
        public TeamLeaderController(ITeamLeaderRep TeamLeaderRep)
        {
            this.TeamLeaderRep = TeamLeaderRep;
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult ShowTeamLeaders()
        {

            return View(TeamLeaderRep.GetTeamLeaders());
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult CreatTeamLeader()
        {
            return View();
        }


        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> InsertTeamLeader(UserDto TeamLeaderDto)
        {
            if (ModelState.IsValid)
            {
                await TeamLeaderRep.InsertTeamLeader(TeamLeaderDto);
                return RedirectToAction("ShowTeamLeaders");
            }
            else
            {
                return View("CreatTeamLeader");
            }
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult EditTeamLeader(String TeamLeaderID)
        {
            var TeamLeader = TeamLeaderRep.GetTeamLeader(TeamLeaderID);
            var TeamLeaderDto = new UserDto()
            {
                FirstName = TeamLeader.FirstName,
                LastName = TeamLeader.LastName,
                Id = TeamLeader.Id,
                Email = TeamLeader.Email,
                UserName = TeamLeader.UserName
            };


            return View(TeamLeaderDto);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> UpdateTeamLeaderInf(UserDto TeamLeaderDto)
        {

            if (ModelState.IsValid)
            {
                await TeamLeaderRep.UpdateTeamLeader(TeamLeaderDto);
                return RedirectToAction("ShowTeamLeaders");
            }
            else
            {
                return View("EditTeamLeader");
            }
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<String> DeletTeamLeader(String TeamLeaderID)
        {
            var Reselt = "YES";
            try
            {
                await TeamLeaderRep.DeletTeamLeader(TeamLeaderID);
               
            }
            catch (Exception)
            {

                Reselt = "NO";
               
            }
            return JsonConvert.SerializeObject(Reselt);

        }
    }
}
