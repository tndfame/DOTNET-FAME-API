using FAME_PROEJCT_API.Models.Entity;
using FAME_PROEJCT_API.Models.Request;
using FAME_PROEJCT_API.Models.Response;
using FAME_PROEJCT_API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FAME_PROEJCT_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("getCategoryWithProducts/{categoryId}")]
        public async Task<ActionResult<List<CategoryWithProductResponse>>> GetCategoryWithProducts(int categoryId)
        {
            try
            {
                var categoryWithProducts = await _categoryService.GetCategoryWithProductsAsync(categoryId);
                return Ok(categoryWithProducts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("getCategory")]
        public async Task<ActionResult<List<Categories>>> GetCategories()
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("addCategory")]
        public async Task<ActionResult<Categories>> AddCategory([FromBody] CategoryRequest categoryRequest)
        {
            var newCategory = new Categories
            {
                CategoryName = categoryRequest.CategoryName,
            };

            var addedCategory = await _categoryService.AddCategoryAsync(newCategory);

            return Ok(addedCategory);
        }


        //Product
        [HttpGet("getProduct")]
        public async Task<ActionResult<List<Products>>> GetProductsAsync()
        {
            try
            {
                var product = await _categoryService.GetProductsAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("addProduct")]
        public async Task<ActionResult<Products>> AddProductAsync([FromBody] ProductRequest productRequest)
        {
            var newProduct = new Products
            {
                ProductName = productRequest.ProductName,
                ProductPrice = productRequest.ProductPrice,
                ProductDescription = productRequest.ProductDescription,
                CategoryId = productRequest.CategoryId,
            };
            var addedProduct = await _categoryService.AddProductAsync(newProduct);
            return Ok(addedProduct);
        }

    }
}
