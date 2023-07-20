using System;
using System.ComponentModel.DataAnnotations;
namespace RazorSample.Models
{
	public class ItemCategory
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public int Order { get; set; }
        public string Gender { get; set; }

	}
}

