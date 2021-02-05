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
    public class SprintRep : ISprintRep
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public SprintRep(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public List<ProjectDeveloper> GetDeveloperSprints(int ProjectId, string DeveloperId)
        {
            //List<ProjectDeveloper> with Developer sprints To Show all Developer Sprint From one Project
            var ProjectDeveloperSprints = db.ProjectDevelopers.Include(x => x.Project).ThenInclude(y => y.Sprints).ThenInclude(Z => Z.SprintTasks).Where(x => x.ProjectId == ProjectId && x.DeveloperId == DeveloperId).ToList();
             return ProjectDeveloperSprints;
        }

        public Sprint GetSprint(int SprintId)
        {
            
            return db.Sprints.Where(x => x.Id == SprintId).FirstOrDefault();
        }

        public List<Sprint> GetSprints(int ProjectId)
        {

            return db.Sprints.Include(x => x.Project).Where(x => x.ProjectId == ProjectId).ToList();
        }

        public void InsertSprint(SprintDto SprintDto)
        {
            var NewSprint = new Sprint() 
            {
                Title= SprintDto.Title,
                Description= SprintDto.Description,
                StartDate= SprintDto.StartDate,
                EndDate= SprintDto.EndDate,
                TeamLeaderId= SprintDto.TeamLeaderId,
                ProjectId= SprintDto.ProjectId
            };
            NewSprint.StatusSprint = (SprintStatus)SprintDto.StatusSprintDto;

            db.Sprints.Add(NewSprint);
            db.SaveChanges();
        }

        public Boolean IsAllSprintComplet(int ProjectID)
        {
            var Sprints = GetSprints(ProjectID);

            if (Sprints.Count() == 0) { return false; }
            var IsAllSprintComplet = true;
            
                foreach (var item in Sprints)
            {
                if(item.StatusSprint != (SprintStatus)2){  //....>project Not Complet
                    IsAllSprintComplet = false;
                    var Project = db.Projects.Where(x => x.Id == ProjectID).FirstOrDefault();
                    Project.StatusProject = ((ProjectStatus)1);
                    db.Projects.Update(Project);
                    db.SaveChanges();

                    break;
                }
             
                if (IsAllSprintComplet) //....>project Complet
                {
                    var Project = db.Projects.Where(x => x.Id == ProjectID).FirstOrDefault();
                    Project.StatusProject = ((ProjectStatus)2);
                    db.Projects.Update(Project);
                    db.SaveChanges();
                }

            }
            return IsAllSprintComplet;

        }

        public void UpdateSprint(SprintDto SprintDto)
        {
            var Sprint = GetSprint(SprintDto.Id);
            
            Sprint.Title = SprintDto.Title;
            Sprint.Description = SprintDto.Description;
            Sprint.EndDate = SprintDto.EndDate;
            Sprint.StartDate = SprintDto.StartDate;
            Sprint.StatusSprint = (SprintStatus)SprintDto.StatusSprintDto;
            db.Sprints.Update(Sprint);
            db.SaveChanges();
        }

    }
}
