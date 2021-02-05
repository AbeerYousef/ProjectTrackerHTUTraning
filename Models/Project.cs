using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProjectManager ProjectManager { get; set; }
        public string ProjectManagerId { get; set; }

        public TeamLeader TeamLeader { get; set; }
        public string TeamLeaderId { get; set; }

        public List<Sprint> Sprints { get; set; }

        public List<ProjectDeveloper> ProjectDevelopers { get; set; }
        public ProjectStatus StatusProject { get; set; }
    }
    public enum ProjectStatus
    {
        Pending = 1,
        Completed = 2
    }
}
