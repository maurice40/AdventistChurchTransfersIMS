using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public DateTime Time_Added { get; set; }
        public String Comment { get; set; }
        [Required]
        public Christian Christian { get; set; }
        [Display(Name = "Choose the Destination Church")]
        public int ChristianId { get; set; }
        public String Status { get; set; }
        [Required]
        public Church Church { get; set; }

        [Display(Name = "Choose the Destination Church")]
        public int ChurchId { get; set; }
        public String SupportedDoc { get; set; }

    }
}