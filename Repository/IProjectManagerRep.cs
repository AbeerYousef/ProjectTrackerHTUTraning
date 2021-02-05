using FinalProject.Dto;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public interface IProjectManagerRep
    {
        public List<ProjectManager> GetProjectManagers();

        public Task InsertProjectManager(UserDto ProjectManagerDto);
        public ProjectManager GetProjectManager(String ProjectManagerID);
        public Task UpdateProjectManager(UserDto ProjectManagerDto);
        public Task DeletProjectManager(String ProjectManagerID);



    }
}
