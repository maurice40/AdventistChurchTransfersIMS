using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Accountinfo
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Users Role")]
        public  String RoleName { get; set; }

        public int ChurrchId { get; set; }
        public int ProvinceId { get; set; }
        public int DivisionId { get; set; }
        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}