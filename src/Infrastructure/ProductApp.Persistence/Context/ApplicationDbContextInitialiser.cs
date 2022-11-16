using Microsoft.EntityFrameworkCore;

using ProductApp.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Infrastructure.Context
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task InitializeAsync()
        {
            try
            {
                //if (_context.Database.IsSqlServer())
                //{
                //    await _context.Database.MigrateAsync();
                //}
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            if (!_context.Products.Any())
            {
                _context.Products.AddRange(
                    new Product() { Id = Guid.NewGuid(), Name = "Paper A4", Value = 1, Quantity = 100 },
                    new Product() { Id = Guid.NewGuid(), Name = "Paper A5", Value = 1, Quantity = 200 },
                    new Product() { Id = Guid.NewGuid(), Name = "Math Book", Value = 75, Quantity = 500 }
                );

                await _context.SaveChangesAsync();
            }
        }
    }
}
