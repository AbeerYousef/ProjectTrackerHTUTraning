using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
  
        public TeamLeader TeamLeader { get; set; }
        public string TeamLeaderId { get; set; }

        public Project  Project { get; set; }
        public int ProjectId { get; set; }

        public List<SprintTask> SprintTasks { get; set; }
        public SprintStatus StatusSprint { get; set; }
    }
    public enum SprintStatus
    {
        Pending = 1,
        Completed = 2
    }
}
