namespace Lab13.Models
{
    public class Details
    {
        public int DetailsId { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float SubTotal { get; set; }

        public Invoices? Invoices { get; set; }
        public int? InvoicesId { get; set; }

        public Product? Products { get; set; }
        public int? ProductId { get; set; }
    }
}
