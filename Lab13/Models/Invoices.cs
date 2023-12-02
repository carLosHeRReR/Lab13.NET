namespace Lab13.Models
{
    public class Invoices
    {
        public int InvoicesId { get; set; }
        public DateTime DateTime { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }

        public Customer? Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}
