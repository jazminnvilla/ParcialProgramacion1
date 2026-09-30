using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace AccesoDatos.Data
{
    public class ApplicationDbContext : DbContext
    {
        // public DbSet<Autor> Autor { get; set; }
        //public DbSet<Libro> Libro { get; set; }
        //public DbSet<Categoria> Categoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=parcialEF.db");
        }
    }
}

