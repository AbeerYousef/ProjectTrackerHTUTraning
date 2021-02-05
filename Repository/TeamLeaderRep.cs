using FinalProject.Data;
using FinalProject.Dto;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public class TeamLeaderRep : ITeamLeaderRep
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        private IPasswordHasher<IdentityUser> passwordHasher;

        public TeamLeaderRep(ApplicationDbContext db, UserManager<IdentityUser> userManager, IPasswordHasher<IdentityUser> passwordHasher)
        {
            this.db = db;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
        }

        public async Task DeletTeamLeader(string TeamLeaderID)
        {
            try
            {
                var DeletTeamLeader = await userManager.FindByIdAsync(TeamLeaderID);
                var result = await userManager.DeleteAsync(DeletTeamLeader);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TeamLeader GetTeamLeader(string TeamLeaderID)
        {

            return db.TeamLeaders.Where(x => x.Id == TeamLeaderID).SingleOrDefault();
        }

        public List<TeamLeader> GetTeamLeaders()
        {

            return db.TeamLeaders.ToList();
        }

        public async Task InsertTeamLeader(UserDto TeamLeaderDto)
        {
            var TeamLeader = new TeamLeader()
            {
                FirstName = TeamLeaderDto.FirstName,
                LastName = TeamLeaderDto.LastName,
                Email = TeamLeaderDto.Email,
                UserName = TeamLeaderDto.UserName,
                EmailConfirmed = true
            };
            var Reselt = await userManager.CreateAsync(TeamLeader, TeamLeaderDto.Password);

            if (Reselt.Succeeded)
            {
                db.SaveChanges();
                db.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = TeamLeader.Id,
                    RoleId = "3"

                });
                db.SaveChanges();
            }
            else
            {

                throw new Exception(); //ModelState not Valid ==>return View("CreatTeamLeader")

            }
        }

        public async Task UpdateTeamLeader(UserDto TeamLeaderDto)
        {
            var TeamLeader = new TeamLeader();

            var OldTeamLeader = await userManager.FindByIdAsync(TeamLeaderDto.Id);
            OldTeamLeader.PasswordHash = passwordHasher.HashPassword(TeamLeader, TeamLeaderDto.Password);
            OldTeamLeader.Email = TeamLeaderDto.Email;
            OldTeamLeader.UserName = TeamLeaderDto.UserName;
            var Reselt = await userManager.UpdateAsync(OldTeamLeader);



            if (Reselt.Succeeded)
            {
                var OldTLeader = db.TeamLeaders.Where(x => x.Id == TeamLeaderDto.Id).SingleOrDefault();
                OldTLeader.FirstName = TeamLeaderDto.FirstName;
                OldTLeader.LastName = TeamLeaderDto.LastName;
                db.TeamLeaders.Update(OldTLeader);
                db.SaveChanges();

            }
            else
            {

                throw new Exception();//ModelState not Valid ==>return View("EditTeamLeader")

            }
        }
        public List<TeamLeader> GetAnotherTeamLeaders(String TeamLeaderId)
        {
            var TeamLeader = GetTeamLeader(TeamLeaderId);
            var TeamLeaders = GetTeamLeaders();
            TeamLeaders.Remove(TeamLeader);
            return TeamLeaders;
        }

        public TeamLeader GetTeamLeaderFroSprintId(int SprintId)
        {
            var TeamLeader= db.Sprints.Include(x => x.TeamLeader).Where(x => x.Id == SprintId).Select(x => x.TeamLeader).SingleOrDefault();
            return TeamLeader;
        }
    }
}
