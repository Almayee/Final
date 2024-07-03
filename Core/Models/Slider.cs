using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Models
{
	public class Slider:BaseEntity
	{
		[Required]
		[StringLength(50)]
		public string Title { get; set; }
		[StringLength(100)]
		public string? ImageUrl { get; set; }
		[NotMapped]
		public IFormFile? ImageFile { get; set; }
	}
}
