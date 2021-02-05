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
    public class ProjectRep : IProjectRep
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public ProjectRep(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public Project GetProject(int ProjectId)
        {
            
            return db.Projects.Include(x => x.TeamLeader).Where(x => x.Id == ProjectId).SingleOrDefault();
        }

        public Project GetProjectFromSprintId(int SprintId)
        {
            return db.Sprints.Include(x => x.Project).ThenInclude(y => y.TeamLeader).Where(x => x.Id == SprintId).Select(x => x.Project).SingleOrDefault();
        }

        public List<Project> GetProjects(string ProjetManagerId)
        {
           
            return db.Projects.Include(x => x.TeamLeader).Where(x => x.ProjectManagerId == ProjetManagerId).ToList();
        }
 
        public TeamLeader GetTeamLeaderWithProjects(string TeamLeaderId)
        {
            return db.TeamLeaders.Include(x => x.Projects).ThenInclude(y => y.ProjectManager).Where(x => x.Id == TeamLeaderId).SingleOrDefault();
        }
        public void InsertProject(ProjectDto ProjectDto , string ProjetManagerId)
        {
            
            var project = new Project()
            {
                Title = ProjectDto.Title,
                Description = ProjectDto.Description,
               ProjectManagerId= ProjetManagerId,
               TeamLeaderId= ProjectDto.TeamLeaderId

            };
            project.StatusProject = (ProjectStatus)ProjectDto.StatusProjectDto;
            db.Projects.Add(project);
            db.SaveChanges();
  
         
            foreach (var item in ProjectDto.DeveloperIds)
            {
                var projectDeveloper = new ProjectDeveloper()
                {
                    ProjectId= project.Id,
                    DeveloperId= item
                };
                db.ProjectDevelopers.Add(projectDeveloper);
            }
            db.SaveChanges();


        }

        public List<ProjectDeveloper> GetOldProjectDevelopers(int ProjectID)
        {
            var t = db.ProjectDevelopers.Include(x => x.Developer).Where(x => x.ProjectId == ProjectID).ToList();
            return db.ProjectDevelopers.Include(x => x.Developer).Where(x => x.ProjectId == ProjectID).ToList();
        }

        public void UpdateProject(ProjectDto ProjectDto)
        {
            var Project = GetProject(ProjectDto.Id);
            Project.Title = ProjectDto.Title;
            Project.Description = ProjectDto.Description ;
            Project.TeamLeaderId = ProjectDto.TeamLeaderId;
            db.Projects.Update(Project);
            db.SaveChanges();
            var OldProjectDevelopers = GetOldProjectDevelopers(ProjectDto.Id);
            db.ProjectDevelopers.RemoveRange(OldProjectDevelopers);
            foreach (var DeveloperId in ProjectDto.DeveloperIds)
            {
                var NewProjectDeveloper = new ProjectDeveloper() 
                {
                    ProjectId= ProjectDto.Id,
                    DeveloperId= DeveloperId
                };
                db.ProjectDevelopers.Add(NewProjectDeveloper);

            }
            db.SaveChanges();
        }

        public List<Project> GetDeveloperProjects(string DeveloperId)
        {
            
            return db.ProjectDevelopers.Include(x => x.Project).ThenInclude(y => y.ProjectManager).Where(x => x.DeveloperId == DeveloperId).Select(x => x.Project).ToList();
        }

        public List<Project> GetProjectManagerWorks(int ProjectId)
        {
           
            var Project = db.Projects.Include(x => x.Sprints).ThenInclude(y => y.SprintTasks).ThenInclude(z => z.Works).Where(x => x.Id == ProjectId).ToList();

            return (Project);
        }

    }
}
