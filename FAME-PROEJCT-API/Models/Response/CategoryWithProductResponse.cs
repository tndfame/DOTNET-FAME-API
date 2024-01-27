using System;
namespace FAME_PROEJCT_API.Models.Response
{
	public class CategoryWithProductResponse
	{
        public int? CategoryId { get; set; }
        public int? ProductId { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
    }
}

