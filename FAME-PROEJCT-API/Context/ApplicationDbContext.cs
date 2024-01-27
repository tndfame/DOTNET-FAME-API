using System;
using FAME_PROEJCT_API.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace FAME_PROEJCT_API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Postgresql"));
            }
        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set snake_case naming convention
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(ConvertToSnakeCase(entity.GetTableName()));

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ConvertToSnakeCase(property.GetColumnName()));
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(ConvertToSnakeCase(key.GetName()));
                }

                foreach (var index in entity.GetIndexes())
                {
                    // Use HasName to set the index name
                    _ = modelBuilder.Entity(entity.Name).HasIndex(index.Properties.Select(p => p.Name).ToArray()).HasName(ConvertToSnakeCase(index.Name));
                }
            }
        }

        private static string ConvertToSnakeCase(string input)
        {
            return string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
    }
}
