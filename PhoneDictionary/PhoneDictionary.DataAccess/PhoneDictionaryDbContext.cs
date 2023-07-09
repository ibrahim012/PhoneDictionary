using Microsoft.EntityFrameworkCore;
using PhoneDictionary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary.DataAccess
{
    public class PhoneDictionaryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source= DESKTOP-VO289U7;Initial Catalog=PhoneDictionary;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Person)
                .WithMany(p => p.ContactInfos);
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<ContactInfo> Contacts{ get; set; }
    }
}
