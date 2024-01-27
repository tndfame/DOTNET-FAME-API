using System;
using FAME_PROEJCT_API.Models.Entity;
using FAME_PROEJCT_API.Models.Response;

namespace FAME_PROEJCT_API.Service
{
    public interface ICategoryService
    {

        Task<Categories> AddCategoryAsync(Categories category);
        Task<List<Categories>> GetCategoriesAsync();

        //Product
        Task<Products> AddProductAsync(Products product);
        Task<List<Products>> GetProductsAsync();

        Task<List<CategoryWithProductResponse>> GetCategoryWithProductsAsync(int categoryId);
    }

}

