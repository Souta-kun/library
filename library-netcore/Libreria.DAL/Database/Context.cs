using Libreria.DTO.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Protocols;

namespace Libreria.DAL.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions) { }

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
