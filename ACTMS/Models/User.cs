using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name="Enter Username")]
        public string Username { get; set; }
        [Display(Name = "Enter Firstname")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Enter Lastname")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Enter Email")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Enter Password")]
        [Required]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivationCode { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}