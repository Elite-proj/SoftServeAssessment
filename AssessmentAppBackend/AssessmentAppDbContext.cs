using AssessmentAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentAppBackend
{
    public class AssessmentAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CustomerDB");
        }

        public DbSet<Customer> Customers { get; set; }

    }
}
