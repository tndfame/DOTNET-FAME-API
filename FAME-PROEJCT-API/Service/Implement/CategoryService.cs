using System;
using FAME_PROEJCT_API.Context;
using FAME_PROEJCT_API.Models.Entity;
using FAME_PROEJCT_API.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace FAME_PROEJCT_API.Service.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<CategoryWithProductResponse>> GetCategoryWithProductsAsync(int categoryId)
        {
            try
            {
                var result = await (from cg in _dbContext.Categories
                                    join pd in _dbContext.Products on cg.CategoryId equals pd.CategoryId
                                    where cg.CategoryId == categoryId
                                    select new CategoryWithProductResponse
                                    {
                                        CategoryId = pd.CategoryId,
                                        ProductId = pd.ProductId,
                                        CategoryName = cg.CategoryName,
                                        ProductName = pd.ProductName,
                                        ProductPrice = pd.ProductPrice,
                                        ProductDescription = pd.ProductDescription
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    


        public async Task<Categories> AddCategoryAsync(Categories category)
        {
            try
            {
                _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();
                return category;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
           
        }


        public async Task<List<Categories>> GetCategoriesAsync()
        {
            try
            {
                return await _dbContext.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        //Product
        public async Task<Products> AddProductAsync(Products product)
        {
            try
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Products>> GetProductsAsync()
        {
            try
            {
                return await _dbContext.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    }

}

