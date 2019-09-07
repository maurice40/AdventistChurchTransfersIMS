using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACTMS.Models;
	
namespace ACTMS.ViewModels
{
	public class StatusesViewModel
	{
		public Status Status { get; set; }
		public List<Christian> Christian { get; set; }
	}
}