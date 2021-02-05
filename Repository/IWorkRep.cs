using FinalProject.Dto;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public interface IWorkRep
    {
        public List<SprintTask> GetWorks(int SprintTaskId, String DeveloperId);
        public List<Work> GetSprintTaskWorks(int SprintTaskId);
        public void InsertWork(WorkDto WorkDto, String DeveloperId);
        public void UpdateWork(WorkDto WorkDto);
        public Work GetWork(int WorkId);
        public void RejectedWork(int WorkId, string RejectionNote);
        public void ApprovedWork(int WorkId);
        public Boolean IsAllWorksApproved(int SprintTaskId);
        public void SendMail(TeamLeader TeamLeader, Developer Developer);
        public void DeletWork(Work Work);






    }
}
