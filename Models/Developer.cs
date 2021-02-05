using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Developer : Person
    {
       
        public List<ProjectDeveloper> ProjectDevelopers { get; set; }
      
        public List <SprintTask> SprintTasks { get; set; }
        public List<Work> Works { get; set; }
    }
}
