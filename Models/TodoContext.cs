using DevotugasDaStreet.TodoTodo.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItem>(entity =>
            {
                entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(1);
            });

            base.OnModelCreating(builder);
        }
    }
}