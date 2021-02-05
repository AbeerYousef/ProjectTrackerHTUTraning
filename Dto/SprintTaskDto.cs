using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Dto
{
    public class SprintTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int SprintId { get; set; }
        public string DeveloperId { get; set; }

        public List<int> WorkIds { get; set; }
        public SprintTaskStatusDto StatusSprintTaskDto { get; set; }
    }
    public enum SprintTaskStatusDto
    {
        Pending = 1,
        Completed = 2
    }

}
