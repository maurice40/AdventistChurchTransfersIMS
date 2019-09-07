using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        [Display(Name = "File Url")]
        public String AUrl { get; set; }
        public String Status { get; set; }
        [Display(Name = "Owner")]
        public Christian Christian { get; set; }
        public int ChristianId { get; set; }
    }
}