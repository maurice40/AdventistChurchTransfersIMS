using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACTMS.Dtos
{
    public class ChurchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public ProvinceDto Province { get; set; }
        
    }
}