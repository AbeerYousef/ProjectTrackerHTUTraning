using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ProjectDeveloper
    {
        public Project Project { get; set; }
        public int ProjectId { get; set; }

        public Developer Developer { get; set; }
        public string DeveloperId { get; set; }
    }
}
