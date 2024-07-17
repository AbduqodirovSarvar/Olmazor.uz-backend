using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Services;
using OlmaTech.Domain.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Infrastructure.Persistance.EntityFramework
{
    public class AppDbContext(
        DbContextOptions<AppDbContext> options,
        ICurrentUserService currentUserService
        ) : DbContext(options), IAppDbContext
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<HomePost> HomePosts { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditableEntity();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditableEntity()
        {
            foreach (var entry in ChangeTracker.Entries<AudiTableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _currentUserService.Id;
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                if(entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedBy = _currentUserService.Id;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }

        public async Task SeedAsync()
        {
            using var _context = this.GetService<AppDbContext>();
            await _context.Users.AddAsync(DefaultData.DefaultUserData.DefaultUser);
            await _context.SaveChangesAsync();
        }
    }
}
