using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class SprintTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string Status { get; set; }

        public Sprint Sprint { get; set; }
        public int SprintId { get; set; }

        public Developer Developer { get; set; }
        public string DeveloperId { get; set; }
        //public TeamLeader TeamLeader { get; set; }
        //public string TeamLeaderId { get; set; }

        public List<Work> Works { get; set; }
        public SprintTaskStatus StatusSprintTask { get; set; }
    }
    public enum SprintTaskStatus
    {
        Pending = 1,
        Completed = 2
    }
}
