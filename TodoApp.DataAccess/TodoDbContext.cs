using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Entities;

namespace TodoApp.DataAccess
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkileri ve kuralları burada Fluent API ile yapılandıracağız.

            // User ile Todo arasında Bire-Çok ilişki
            modelBuilder.Entity<User>()
                .HasMany(u => u.Todos)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Bir kullanıcı silinirse tüm görevleri de silinsin.

            // User ile Category arasında Bire-Çok ilişki
            modelBuilder.Entity<User>()
                .HasMany(u => u.Categories)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Bir kullanıcı silinirse tüm kategorileri de silinsin.

            // Category ile Todo arasında Bire-Çok ilişki
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Todos)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.SetNull); // Bir kategori silinirse, o kategorideki görevlerin CategoryId'si NULL olsun. Görevler silinmesin.

            // Benzersiz Alanlar (Unique Constraints)
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
