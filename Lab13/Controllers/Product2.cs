using Lab13.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product2Controller : ControllerBase
    {
        private readonly InvoiceContext _context;

        public Product2Controller(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]

        public List<Product> GetProducts(double price) 
        {
            var response = _context.Products.Where(x=>x.Price>price).ToList();
            return response;
        }
    }
}
