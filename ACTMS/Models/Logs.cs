using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Logs
    {
        public int Id { get; set; }
        public DateTime TimeHappened { get; set; }
        [Required]
        public string Action { get; set; }
        public int level { get; set; }
    }
}