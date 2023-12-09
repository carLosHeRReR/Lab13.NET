namespace Lab13.Models.Request
{
    public class InvoiceV1
    {
        public int InvoicesId { get; set; }
        public DateTime DateTime { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }
    }
}
