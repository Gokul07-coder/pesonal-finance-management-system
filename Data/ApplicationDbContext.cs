using Microsoft.EntityFrameworkCore;
using pfms.Models;
using System;

namespace pfms
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Income> Incomes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Expense>().ToTable("Expenses");
            modelBuilder.Entity<Budget>().ToTable("Budgets");
            modelBuilder.Entity<Income>().ToTable("Incomes");

            modelBuilder.Entity<Expense>().HasOne(e => e.category).WithMany(c => c.Expenses).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Expense>().HasOne(e => e.user).WithMany(u => u.Expenses).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Budget>()
                .HasIndex(b => new { b.UserId, b.CategoryId, b.Year, b.Month })
                .IsUnique();

            modelBuilder.Entity<Budget>().HasOne(b => b.category).WithMany(c => c.Budgets).HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Budget>().HasOne(b => b.user).WithMany(u => u.Budgets).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Income>().HasOne(i => i.category).WithMany(c => c.Incomes).HasForeignKey(i => i.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Income>().HasOne(i => i.user).WithMany(u => u.Incomes).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.Restrict);

        }

    }
}