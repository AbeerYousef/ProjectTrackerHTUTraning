using FinalProject.Data;
using FinalProject.Dto;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public class ProjectManagerRep : IProjectManagerRep
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        private IPasswordHasher<IdentityUser> passwordHasher;

        public ProjectManagerRep(ApplicationDbContext db, UserManager<IdentityUser> userManager , IPasswordHasher<IdentityUser> passwordHasher)
        {
            this.db = db;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
        }

        public async Task DeletProjectManager(string ProjectManagerID)
        {
            try
            {
                var DeletProjectManager = await userManager.FindByIdAsync(ProjectManagerID);
                var result = await userManager.DeleteAsync(DeletProjectManager);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw; /*(ModelState not Valid)==>return View("ShowProjectManager")*/
            }
        }

        public ProjectManager GetProjectManager(string ProjectManagerID)
        {

            return db.ProjectManagers.Where(x => x.Id == ProjectManagerID).SingleOrDefault();
        }

        public List<ProjectManager> GetProjectManagers()
        {
            
            return db.ProjectManagers.ToList();
        }

        public async Task InsertProjectManager(UserDto ProjectManagerDto)
        {
            var ProjectManager = new ProjectManager()
            {
                FirstName= ProjectManagerDto.FirstName,
                LastName= ProjectManagerDto.LastName,
                Email= ProjectManagerDto.Email,
                UserName= ProjectManagerDto.UserName,
                EmailConfirmed=true
            };
            var Reselt = await userManager.CreateAsync(ProjectManager, ProjectManagerDto.Password);
            

            if (Reselt.Succeeded)
            {
                db.SaveChanges();
                db.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = ProjectManager.Id,
                    RoleId = "2"

                });
                db.SaveChanges();
            }
            else
            {

                throw new Exception(); // (ModelState not Valid)==>return View("CreatProjectManager")

            }
        }

        public async Task UpdateProjectManager(UserDto ProjectManagerDto)
        {
            var ProjectManager = new ProjectManager();
         
            var OldProjectManager = await userManager.FindByIdAsync(ProjectManagerDto.Id);
            OldProjectManager.PasswordHash = passwordHasher.HashPassword(ProjectManager, ProjectManagerDto.Password);
            OldProjectManager.Email = ProjectManagerDto.Email;
            OldProjectManager.UserName = ProjectManagerDto.UserName;
            var Reselt = await userManager.UpdateAsync(OldProjectManager);


            if (Reselt.Succeeded)
            {
                var oldProjMan = db.ProjectManagers.Where(x => x.Id == ProjectManagerDto.Id).SingleOrDefault();
                oldProjMan.FirstName = ProjectManagerDto.FirstName;
                oldProjMan.LastName = ProjectManagerDto.LastName;
                db.ProjectManagers.Update(oldProjMan);
                db.SaveChanges();
             
            }
            else
            {

                throw new Exception();  // (ModelState not Valid)==>return View("EditProjectManager")

            }
        }
    }
}
