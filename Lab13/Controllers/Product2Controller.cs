using Lab13.Models;
using Lab13.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Product2Controller : ControllerBase
    {
        private readonly InvoiceContext _context;

        public Product2Controller(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]

        public List<Product> GetProductsPrice(double price) 
        {
            var response = _context.Products.Where(x=>x.Price>price).ToList();
            return response;
        }

        [HttpGet]

        public Product GetProductPrice (double price) 
        {
            var response = _context.Products.Where(x => x.Price > price).FirstOrDefault();
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
        public void EliminarProduct(int productId)
        {
            var product = _context.Products.Find(productId);

            if (product != null && product.IsActive)
            {
                product.IsActive = false;

                _context.SaveChanges();
            }
        }

        [HttpPost]
        public void InsertCustomer(CustomerV1 Request)
        {
            //trasnformar de request a model
            Customer customer = new Customer
            {
                FirstName = Request.FirstName,
                LastName = Request.LastName,
                DocumentNumber = Request.DocumentNumber,
                IsActive = true
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        [HttpPost]
        public void EliminarCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);

            if (customer != null && customer.IsActive)
            {
                customer.IsActive = false;

                _context.SaveChanges();
            }
        }

        [HttpPost]
        public void InsertInvoice(InvoiceV1 Request)
        {
            //trasnformar de request a model
            Invoices invoices = new Invoices
            {
                InvoicesId = Request.InvoicesId,
                DateTime = Request.DateTime,
                InvoiceNumber = Request.InvoiceNumber,
                Total = Request.Total,
            };

            _context.Invoices.Add(invoices);
            _context.SaveChanges();
        }

        [HttpPost]
        public void UpdateCustomer(UpdateCustomer request)
        {
            var customer = _context.Customers.Find(request.customerId);

            if (customer != null && customer.IsActive)
            {
                customer.DocumentNumber = request.DocumentNumber;

                _context.SaveChanges();
            }
        }

        [HttpPost]
        public void UpdateProduct(UpdateProduct request)
        {
            var product = _context.Products.Find(request.ProductId);

            if (product != null && product.IsActive)
            {
                product.Price = request.Precio;

                _context.SaveChanges();
            }
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

                products.Add(product);
                //_context.Products.Add(product);
                //_context.SaveChanges();
            }

            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
    }
}
