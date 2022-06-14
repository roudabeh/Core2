using Microsoft.EntityFrameworkCore;
using Tamrin.Database.Models;

namespace Tamrin.Database
{
    public class TamrinDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }    
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<FactorDetail> FactorDetails { get; set; }

        public TamrinDBContext(DbContextOptions<TamrinDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }

    }
}
