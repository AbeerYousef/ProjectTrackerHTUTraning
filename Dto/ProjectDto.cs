using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string ProjectManagerId { get; set; }

        public string TeamLeaderId { get; set; }

        public List<int> SprintIds { get; set; }

        public List<String> DeveloperIds { get; set; }
        public ProjectStatusDto StatusProjectDto { get; set; }
    }
    public enum ProjectStatusDto
    {
        Pending = 1,
        Completed = 2
    }

}
