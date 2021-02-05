using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RejectionNote { get; set; }
        public SprintTask SprintTask { get; set; }
        public int SprintTaskId { get; set; }
        public Byte[] TheFile { get; set; }
        public string FileName { get; set; }
        //type of file
        public string ContentType { get; set; }
        public Developer Developer { get; set; }
        public String DeveloperId { get; set; }
        public WorkStatus StatusWork { get; set; }
    }
    public enum WorkStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}
