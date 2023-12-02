using Lab13.Models;
using Lab13.Models.Request;
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

        [HttpPost]

        public void Insert(ProductV1 Request)
        {
            //trasnformar de request a model
            Product product = new Product
            {
                Price = Request.Price,
                Name = Request.Name,
                IsActive =  true
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpPost]

        public void InsertRange(List< ProductV1> Request)
        {
            List<Product> products = new List<Product>();
            foreach (var item in Request) 
            {
                Product product = new Product
                {
                    Price = item.Price,
                    Name = item.Name,
                    IsActive = true
                };

                _context.Products.Add(product);
                _context.SaveChanges();
            }

            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
    }
}
