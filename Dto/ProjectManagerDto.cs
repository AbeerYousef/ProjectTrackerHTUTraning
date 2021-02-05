using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Dto
{
    public class ProjectManagerDto
    {
        public String Id { get; set; }
        //[Display(Name = "First Name")]
        public string FirstName { get; set; }
        //[Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Comper Password is incorrect")]
        public string ComperPassword { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
