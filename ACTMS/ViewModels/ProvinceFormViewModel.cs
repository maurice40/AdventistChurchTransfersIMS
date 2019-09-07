using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACTMS.Models;

namespace ACTMS.ViewModels
{
    public class ProvinceFormViewModel
    {
        public IEnumerable<Division> Divisions { get; set; }
        public Province Province { get; set; }
    }
}