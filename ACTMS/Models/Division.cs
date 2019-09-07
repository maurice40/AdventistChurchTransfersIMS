using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Division
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Contacts { get; set; }
    }
}