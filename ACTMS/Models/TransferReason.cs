using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class TransferReason
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Description { get; set; }

    }
}