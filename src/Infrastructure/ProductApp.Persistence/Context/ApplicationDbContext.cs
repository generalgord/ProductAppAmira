﻿using Microsoft.EntityFrameworkCore;

using ProductApp.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Paper A4", Value = 1, Quantity = 100 },
                new Product() { Id = Guid.NewGuid(), Name = "Paper A5", Value = 1, Quantity = 200 },
                new Product() { Id = Guid.NewGuid(), Name = "Math Book", Value = 75, Quantity = 500 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
