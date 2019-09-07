using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Province
    {
        public int id { get; set; }
        [Required]
        public String Name  { get; set; }
        public Division Division { get; set; }
        public int DivisionId { get; set; }
    }


}