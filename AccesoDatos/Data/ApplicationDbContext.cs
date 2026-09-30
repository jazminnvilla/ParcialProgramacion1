using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace AccesoDatos.Data
{
    public class ApplicationDbContext : DbContext
    {
         public DbSet<Artista> Artistas { get; set; }
         public DbSet<Cancion> Canciones { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=parcialEF.db");
        }
    }
}

