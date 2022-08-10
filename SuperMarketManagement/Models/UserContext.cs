using Microsoft.EntityFrameworkCore;

namespace SuperMarketManagement.Models
{
    public class UserContext:DbContext
    {
        public UserContext()
        {

        }
        public UserContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
       
        public DbSet<Bill> Bills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("dbconn"));
        }
    }
}
