using DevRoom.Domain.Common;
using DevRoom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DevRoom.Persistence
{
    public class DevRoomDbContext : DbContext
    {
        public DevRoomDbContext(DbContextOptions<DevRoomDbContext> options)
           : base(options)
        {

        }

        public DbSet<Content> Contents { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "Rodrigo Belmonte de Oliveira";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
