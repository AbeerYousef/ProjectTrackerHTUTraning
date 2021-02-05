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
    public class DeveloperRep : IDeveloperRep
    {

        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        private IPasswordHasher<IdentityUser> passwordHasher;

        public DeveloperRep(ApplicationDbContext db, UserManager<IdentityUser> userManager, IPasswordHasher<IdentityUser> passwordHasher)
        {
            this.db = db;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
        }

        public async Task DeletDeveloper(string DeveloperID)
        {
            try
            {
                var DeletDeveloper = await userManager.FindByIdAsync(DeveloperID);
                var result = await userManager.DeleteAsync(DeletDeveloper);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }
          

        }

        public List<Developer> DevelopersAfterDeletProjectDevelopers(int ProjectID)
        {
            var AllDevelopers = GetDevelopers();
            var AllProjectDevelopers = GetProjectDevelopers(ProjectID);
            foreach (var Developer in AllProjectDevelopers)
            {
                AllDevelopers.Remove(Developer);
            }

            return AllDevelopers;
        }

        public Developer GetDeveloper(string DeveloperID)
        {

            return db.Developers.Where(x => x.Id == DeveloperID).SingleOrDefault();
        }

        public List<Developer> GetDevelopers()
        {

            return db.Developers.ToList();
        }

        public List<Developer> GetProjectDevelopers(int ProjectID)
        {
            var t = db.ProjectDevelopers.Include(x => x.Developer).Where(x => x.ProjectId == ProjectID).Select(x => x.Developer).ToList();
            return db.ProjectDevelopers.Include(x => x.Developer).Where(x => x.ProjectId == ProjectID).Select(x => x.Developer).ToList();
        }

        public async Task InsertDeveloper(UserDto DeveloperDto)
        {
            var Developer = new Developer()
            {
                FirstName = DeveloperDto.FirstName,
                LastName = DeveloperDto.LastName,
                Email = DeveloperDto.Email,
                UserName = DeveloperDto.UserName,
                EmailConfirmed = true
            };
            var Reselt = await userManager.CreateAsync(Developer, DeveloperDto.Password);


            if (Reselt.Succeeded)
            {
                db.SaveChanges();
                db.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = Developer.Id,
                    RoleId = "4"

                });
                db.SaveChanges();
            }
            else
            {

                throw new Exception(); // (ModelState not Valid)==>return View("CreatDeveloper")

            }
        }

        public async Task UpdateDeveloper(UserDto DeveloperDto)
        {
            var Developer = new Developer();

            var OldDeveloper = await userManager.FindByIdAsync(DeveloperDto.Id);
            OldDeveloper.PasswordHash = passwordHasher.HashPassword(Developer, DeveloperDto.Password);
            OldDeveloper.Email = DeveloperDto.Email;
            OldDeveloper.UserName = DeveloperDto.UserName;
            var Reselt = await userManager.UpdateAsync(OldDeveloper);


            if (Reselt.Succeeded)
            {
                var oldDeveloper = db.Developers.Where(x => x.Id == DeveloperDto.Id).SingleOrDefault();
                oldDeveloper.FirstName = DeveloperDto.FirstName;
                oldDeveloper.LastName = DeveloperDto.LastName;
                db.Developers.Update(oldDeveloper);
                db.SaveChanges();

            }
            else
            {

                throw new Exception();  //(ModelState not Valid)==>return View("EditDeveloper")

            }
        }



    }
}
