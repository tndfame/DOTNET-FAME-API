using System;
namespace FAME_PROEJCT_API.Models.Request
{
	public class ProductRequest
	{
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public int? CategoryId { get; set; }
    }
}

