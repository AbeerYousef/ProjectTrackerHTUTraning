using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Dto
{
    public class SprintDto
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string TeamLeaderId { get; set; }

        public int ProjectId { get; set; }

        public List<int> SprintTaskIds { get; set; }
        public SprintStatusDto StatusSprintDto { get; set; }
    }
    public enum SprintStatusDto
    {
        Pending = 1,
        Completed = 2
    }

}
