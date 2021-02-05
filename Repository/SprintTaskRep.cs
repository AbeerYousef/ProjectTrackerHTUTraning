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
    public class SprintTaskRep : ISprintTaskRep
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public SprintTaskRep(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public List<SprintTask> GetSprintTasks(int SprintId)
        {
          
            return db.SprintTasks.Include(x => x.Developer).Where(x => x.SprintId== SprintId).ToList();
        }
       

        public SprintTask GetSprintTask(int SprintTaskId)
        {
            return db.SprintTasks.Include(x => x.Developer).Where(x => x.Id == SprintTaskId).FirstOrDefault();
        }

        public void InsertSprintTask(SprintTaskDto SprintTaskDto)
        {
            var NewSprintTask = new SprintTask() 
            {
                Title= SprintTaskDto.Title,
                Description= SprintTaskDto.Description,
                SprintId= SprintTaskDto.SprintId,
                DeveloperId= SprintTaskDto.DeveloperId
            };
            NewSprintTask.StatusSprintTask =(SprintTaskStatus)SprintTaskDto.StatusSprintTaskDto;
            db.SprintTasks.Add(NewSprintTask);
            db.SaveChanges();
        }

        public List<SprintTask> GetDeveloperSprintTasks(int SprintId, string DeveloperId)
        {
           
            var DeveloperSprintTasks = db.SprintTasks.Include(x => x.Sprint).ThenInclude(y => y.Project).ThenInclude(z => z.ProjectDevelopers).Where(x => x.SprintId == SprintId && x.DeveloperId == DeveloperId).ToList();

            return DeveloperSprintTasks;
        }

        public void CompletedSprintTask(int SprintTaskId)
        {
            
            //All works for this SprintTask is Approved....> make SprintTask Completed
            var SprintTask = db.SprintTasks.Where(x => x.Id == SprintTaskId).FirstOrDefault();
            SprintTask.StatusSprintTask = (SprintTaskStatus)2; //Completed
            db.SprintTasks.Update(SprintTask);
            db.SaveChanges();
           
        }
        public Boolean IsAllSprintTaskComplet(Sprint sprint)
        {
            var SprintTasks = GetSprintTasks(sprint.Id);
            var IsAllSprintTaskComplet = true;
            foreach (var SprintTask in SprintTasks)
            {
                if(SprintTask.StatusSprintTask != (SprintTaskStatus)2){
                    IsAllSprintTaskComplet = false; //sprint should be Pending
                    var Sprint = db.Sprints.Where(x => x.Id == sprint.Id).FirstOrDefault();
                    Sprint.StatusSprint = (SprintStatus)1;
                    db.Sprints.Update(Sprint);
                    db.SaveChanges();
                    break;
                }
            }
            if (IsAllSprintTaskComplet) //AllSprintTaskCompleted ....>Sprint Completed
            {
                var Sprint = db.Sprints.Where(x => x.Id == sprint.Id).FirstOrDefault();
                Sprint.StatusSprint = (SprintStatus)2;
                db.Sprints.Update(Sprint);
                db.SaveChanges();
            }
            return IsAllSprintTaskComplet;
        }

    }
}
