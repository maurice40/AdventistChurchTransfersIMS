using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACTMS.Models
{
    public class Transfer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Enter Comment")]
        public String Comment { get; set; }
        public DateTime Added_at { get; set; }
        [Required]
        public String Status { get; set; }
        public TransferReason TransferReason { get; set; }
        public int TransferReasonId { get; set; }
        public Christian Christian { get; set; }
        [Required]
        [Display(Name = "Christian Name")]
        public int ChristianId { get; set; }

        public Churrch Churrch { get; set; }
        public int ChurrchId { get; set; }

    }
}