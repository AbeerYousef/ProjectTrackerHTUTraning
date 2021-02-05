using FinalProject.Dto;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public interface IProjectRep
    {
        public List<Project> GetProjects(string ProjetManagerId);
        public List<Project> GetDeveloperProjects(string DeveloperId);
        public TeamLeader GetTeamLeaderWithProjects(string TeamLeaderId);
        public Project GetProject(int ProjectId);
        public void InsertProject(ProjectDto ProjectDto , string ProjetManagerId);
        public Project GetProjectFromSprintId(int SprintId);
        public void UpdateProject(ProjectDto ProjectDto);
        public List<ProjectDeveloper> GetOldProjectDevelopers(int ProjectID);
        public List<Project> GetProjectManagerWorks(int ProjectId);
       



    }
}
