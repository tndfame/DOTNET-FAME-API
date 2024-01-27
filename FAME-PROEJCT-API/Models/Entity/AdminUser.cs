using System;
using System.ComponentModel.DataAnnotations;

namespace FAME_PROEJCT_API.Models.Entity
{
    public class AdminUser
    {
        [Key]
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

