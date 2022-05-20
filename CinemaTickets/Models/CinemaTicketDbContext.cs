using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class CinemaTicketDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=CinemaTicketsDb;User Id=sa;Password=12345;");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-374K0KD;Database=CinemaTicketsDb;User Id=sa;Password=12345;");
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Saloon> Saloons { get; set; }
        public DbSet<Seanse> Seanses { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Userr> Userrs { get; set; }
        public DbSet<Rolee> Rolees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rolee>().HasData(
               new Rolee { RoleeID = 1, RoleeName = "Pasif Kullanıcı" },
               new Rolee { RoleeID = 2, RoleeName = "Aktif Kullanıcı" },
               new Rolee { RoleeID = 3, RoleeName = "Admin" },
               new Rolee { RoleeID = 4, RoleeName = "SuperVisor" }
               );
        }

        }
}
