using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Churrch
    {
        public int Id { get; set; }
        [Required]
        public String  Name { get; set; }
        public String Location { get; set; }
        public String Contact { get; set; }
        public Province Province { get; set; }
        [Required]
        public int ProvinceId { get; set; }
    }
}