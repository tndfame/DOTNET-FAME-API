using System;
using System.ComponentModel.DataAnnotations;

namespace FAME_PROEJCT_API.Models.Entity
{
	public class Categories
	{
        [Key]
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}

