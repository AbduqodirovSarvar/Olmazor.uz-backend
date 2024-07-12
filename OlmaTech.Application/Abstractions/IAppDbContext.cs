using Microsoft.EntityFrameworkCore;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<About> Abouts { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<BlogPost> BlogPosts { get; set; }
        DbSet<HomePost> HomePosts { get; set; }
        DbSet<Message> Messages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
