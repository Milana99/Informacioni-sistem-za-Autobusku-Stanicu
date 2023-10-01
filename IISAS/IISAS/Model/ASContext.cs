using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IISAS.Model;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;


namespace IISAS.Model
{
    internal class ASContext : DbContext
    {

        public ASContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Administrator\\Desktop\\projekat\\IISAS\\IISAS\\ASDatabase.mdf;Integrated Security=True")
        {
            
        }

        public DbSet<Autobus> autobusi { get; set; }
        public DbSet<Autoprevoznik> autoprevoznici { get; set; }
        public DbSet<Karta> karte { get; set; }
        public DbSet<Korisnik> korisnici { get; set; }
        public DbSet<Peron> peroni { get; set; }
        public DbSet<Stanica> stanice { get; set; }
        public DbSet<Voznja> voznje { get; set; }

        
    }
}
