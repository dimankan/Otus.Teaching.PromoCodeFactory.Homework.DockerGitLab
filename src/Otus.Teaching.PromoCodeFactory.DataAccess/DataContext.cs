using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using Otus.Teaching.PromoCodeFactory.DataAccess.Model;

namespace Otus.Teaching.PromoCodeFactory.DataAccess
{
    public class DataContext
        : DbContext
    {
        private readonly DbOptions _options;
        
        public DbSet<PromoCode> PromoCodes { get; set; }

        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<Preference> Preferences { get; set; }
        
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<Employee> Employees { get; set; }

        public DataContext(IOptions<DbOptions> options)
        {
            _options = options.Value;
        }
        
        public DataContext(DbContextOptions<DataContext> options, IOptions<DbOptions> dbOptions)
            : base(options)
        {
            _options = dbOptions.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema(_options.Schema);
            
            modelBuilder.Entity<CustomerPreference>()
                .HasKey(bc => new { bc.CustomerId, bc.PreferenceId });  
            modelBuilder.Entity<CustomerPreference>()
                .HasOne(bc => bc.Customer)
                .WithMany(b => b.Preferences)
                .HasForeignKey(bc => bc.CustomerId);  
            modelBuilder.Entity<CustomerPreference>()
                .HasOne(bc => bc.Preference)
                .WithMany()
                .HasForeignKey(bc => bc.PreferenceId); 
        }
    }
}