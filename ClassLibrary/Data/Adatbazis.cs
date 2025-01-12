using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data
{
    public class Adatbazis:DbContext
    {
        public Adatbazis(DbContextOptions<Adatbazis> options)
           : base(options)
        {
        }

        public Adatbazis()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebAPIContext-5068d1fa-2d1a-47f8-80df-e27d7a49e5af;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<ClassLibrary.Models.Huzas> Huzas { get; set; } = default!;

    }
}
