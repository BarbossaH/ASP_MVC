using System;
using System.ComponentModel.DataAnnotations;
namespace CMVC.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public int Order { get; set; }
        public string Gender { get; set; }

	}
}

