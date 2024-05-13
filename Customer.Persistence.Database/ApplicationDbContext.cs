﻿using Customer.Domain;
using Customer.Persistence.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Customer");

            ModelConfig(modelBuilder);
        }


        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new CustomerConfiguration(modelBuilder.Entity<Client>());
        }

        public DbSet<Client> Clients { get; set; }
    }
}
