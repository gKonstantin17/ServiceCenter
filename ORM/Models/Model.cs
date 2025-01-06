using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using Npgsql;
namespace ORM.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() {
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
       
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Ordered_product> Ordered_product { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Technique> Technique { get; set; }
        public DbSet<Diagnostic_card> Diagnostic_card { get; set; }
        public DbSet<Employee> Employee { get; set; }

        // установка текущего времени при создании записи
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .Property(e => e.CreateDate)
                .HasDefaultValueSql("now()");
            modelBuilder.Entity<Client>()
                .Property(e => e.UpdateDate)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Diagnostic_card>()
               .Property(e => e.CreateDate)
               .HasDefaultValueSql("now()");
            modelBuilder.Entity<Diagnostic_card>()
                .Property(e => e.UpdateDate)
                .HasDefaultValueSql("now()");
            modelBuilder.Entity<Diagnostic_card>()
                .Property(e => e.Deadline)
                .HasDefaultValueSql("now() + INTERVAL '7 days'");

            modelBuilder.Entity<Employee>()
               .Property(e => e.CreateDate)
               .HasDefaultValueSql("now()");
            modelBuilder.Entity<Employee>()
                .Property(e => e.UpdateDate)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Order>()
              .Property(e => e.CreateDate)
              .HasDefaultValueSql("now()");
            modelBuilder.Entity<Order>()
                .Property(e => e.UpdateDate)
                .HasDefaultValueSql("now()");
            modelBuilder.Entity<Order>()
                .Property(e => e.OrderDate)
                .HasDefaultValueSql("now()");
            modelBuilder.Entity<Order>()
                .Property(e => e.Deadline)
                .HasDefaultValueSql("now() + INTERVAL '7 days'");

            modelBuilder.Entity<Ordered_product>()
               .Property(e => e.CreateDate)
               .HasDefaultValueSql("now()");
            modelBuilder.Entity<Ordered_product>()
                .Property(e => e.UpdateDate)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Product>()
               .Property(e => e.CreateDate)
               .HasDefaultValueSql("now()");
            modelBuilder.Entity<Product>()
                .Property(e => e.UpdateDate)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Service>()
               .Property(e => e.CreateDate)
               .HasDefaultValueSql("now()");
            modelBuilder.Entity<Service>()
                .Property(e => e.UpdateDate)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Supply>()
               .Property(e => e.CreateDate)
               .HasDefaultValueSql("now()");
            modelBuilder.Entity<Supply>()
                .Property(e => e.UpdateDate)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Technique>()
               .Property(e => e.CreateDate)
               .HasDefaultValueSql("now()");
            modelBuilder.Entity<Technique>()
                .Property(e => e.UpdateDate)
                .HasDefaultValueSql("now()");
        }

    }
}