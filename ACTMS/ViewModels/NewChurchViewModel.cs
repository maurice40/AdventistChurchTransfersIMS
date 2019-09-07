using ACTMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACTMS.Models;

namespace ACTMS.ViewModels
{
    public class NewChurchViewModel
    {
        public IEnumerable<Province> Provinces { get; set; }
        public Church Church { get; set; }
    }
}