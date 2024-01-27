using System;
using FAME_PROEJCT_API.Context;
using FAME_PROEJCT_API.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FAME_PROEJCT_API.Service.Implement
{
    public class AdminUserService : IAdminUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminUserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegisterUserAsync(AdminUser user)
        {
            try
            {
                _dbContext.AdminUser.Add(user);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<AdminUser?> CheckedUserByLogin(string email, string password)
        {
            try
            {
                var result = await _dbContext.AdminUser.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
                Console.WriteLine(result != null ? result.ToString() : "User not found");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during login:");
                Console.WriteLine(ex);
                return null;
            }
        }



    }

}

