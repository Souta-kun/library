using Libreria.DTO.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DAL.Database
{
    public class Context : DbContext
    {
        #region property
        private readonly IConfiguration configuration;
        private const string SQLSERVERConnection = "SQLServerConnection";
        #endregion

        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions) { }
        public Context(IConfiguration config)
        {
            this.configuration = config;
        }
        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString(SQLSERVERConnection), builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<AutorEntity> Autor { get; set; }
        public DbSet<EditorialEntity> Editorial { get; set; }
        public DbSet<LibroEntity> Libro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutorEntity>().ToTable("Autor");
            modelBuilder.Entity<EditorialEntity>().ToTable("Editorial");
            modelBuilder.Entity<LibroEntity>().ToTable("Libro");
        }
    }
}
