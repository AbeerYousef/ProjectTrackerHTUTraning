using FinalProject.Dto;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public interface ISprintTaskRep
    {
        public List<SprintTask> GetSprintTasks(int SprintId);
        
        public SprintTask GetSprintTask(int SprintTaskId);
        public void InsertSprintTask(SprintTaskDto SprintTaskDto);
        public List<SprintTask> GetDeveloperSprintTasks(int ProjectId, string DeveloperId);
        public void CompletedSprintTask(int SprintTaskId);
        public Boolean IsAllSprintTaskComplet(Sprint sprint);




    }
}
