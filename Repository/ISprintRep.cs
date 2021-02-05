using FinalProject.Dto;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public interface ISprintRep
    {
        public List<Sprint> GetSprints(int ProjectId);
        public List<ProjectDeveloper> GetDeveloperSprints(int ProjectId , String DeveloperId );
        public void InsertSprint(SprintDto SprintDto);
        public Sprint GetSprint(int SprintId);
        public void UpdateSprint(SprintDto SprintDto);
        public Boolean IsAllSprintComplet(int ProjectID);

       

    }
}
