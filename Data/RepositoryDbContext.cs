using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext() { }
        public RepositoryDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Workspace>()
               .Property(e => e.Id);

            modelBuilder
                .Entity<Workspace>()
                .HasIndex(workspace => workspace.Name)
                .IsUnique();

            modelBuilder
                .Entity<Collection>()
                .HasIndex(collection => collection.Name)
                .IsUnique();

            modelBuilder
                .Entity<Folder>()
                .HasIndex(folder => folder.Name)
                .IsUnique();

            modelBuilder
                .Entity<Query>()
                .HasIndex(query => query.Name)
                .IsUnique();

            modelBuilder.HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }

        public DbSet<Collection> Collection { get; set; }
        public DbSet<Folder> Folder { get; set; }
        public DbSet<Query> Query { get; set; }
        public DbSet<Workspace> Workspace { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<User> User { get; set; }

    }
}
