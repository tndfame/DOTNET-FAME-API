using System;
using FAME_PROEJCT_API.Models.Entity;

namespace FAME_PROEJCT_API.Service
{
    public interface IAdminUserService
    {
        Task<bool> RegisterUserAsync(AdminUser user);
        Task<AdminUser?> CheckedUserByLogin(string email, string password);
    }

}

