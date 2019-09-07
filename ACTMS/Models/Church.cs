using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Church
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        
        public Province Province { get; set; }
        [Required]
        [Display(Name = "Choose The Church Province")]
        public int ProvinceId { get; set; }
        

    }
}