using FinalProject.Dto;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public interface IDeveloperRep
    {
        public List<Developer> GetDevelopers();

        public Task InsertDeveloper(UserDto DeveloperDto);
        public Developer GetDeveloper(String DeveloperID);
        public List<Developer> GetProjectDevelopers(int ProjectID);
        public List<Developer> DevelopersAfterDeletProjectDevelopers(int ProjectID);
        public Task UpdateDeveloper(UserDto DeveloperDto);
        public Task DeletDeveloper(String DeveloperID);
    }
}
