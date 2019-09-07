using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Christian
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int BirthYear { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Father { get; set; }
        [Required]
        public string Mother { get; set; }
        [Required]
        public string MartalStatus { get; set; }
        public int BaptismYear { get; set; }
        [Required]
        
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }

        public Church Church { get; set; }
        public int ChurchId { get; set; }
    }
}