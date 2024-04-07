using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
    public class New_CompanyDB : DbContext
    {
        public DbSet<Invoice_Header> InvoiceHeaders { get; set; }
        public DbSet<Invoice_Details> InvoiceDetails { get; set; }

        public New_CompanyDB(DbContextOptions<New_CompanyDB> options) : base(options)
        {
        }

        // Optionally, override the OnModelCreating method to configure the model

    }
}
