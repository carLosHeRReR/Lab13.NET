using Microsoft.EntityFrameworkCore;

namespace Lab13.Models
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
