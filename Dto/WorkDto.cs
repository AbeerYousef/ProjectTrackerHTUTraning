using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Dto
{
    public class WorkDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RejectionNote { get; set; }
        public int SprintTaskId { get; set; }
        public String DeveloperId { get; set; }
        public WorkStatusDto StatusWorkDto { get; set; }
        //IFormFile Clss have many important fun (FileName,ContentType,Length,OpenReadStream,...)
        public IFormFile TheFile { get; set; }

    }
    public enum WorkStatusDto
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}
