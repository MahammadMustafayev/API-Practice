using API.DAL;
using API.DTOs.ProductDTo;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private AppDbContext _context { get;  }
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult All()
        {
            return Ok(_context.Products);
        }
        [HttpPost("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) return StatusCode(StatusCodes.Status404NotFound);
            return Ok(product);
        }
        [HttpPost("")]
        public IActionResult Create( CreateDTo productDTo)
        {
            if (productDTo is null) return StatusCode(StatusCodes.Status400BadRequest);
            Product product = new Product
            {
                Name = productDTo.Name,
                Price=productDTo.Price,
                CostPrice=productDTo.CostPrice
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id,EditDTo editDTo)
        {
            Product productexst = _context.Products.Find(id);
            if (productexst is null) return StatusCode(StatusCodes.Status400BadRequest);
            productexst.Name = editDTo.Name;
            productexst.Price = editDTo.Price;
            productexst.CostPrice = editDTo.CostPrice;
            Product product = new Product
            {
                Name = editDTo.Name,
                Price=editDTo.Price,
                CostPrice=editDTo.CostPrice
            };
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product is null) return StatusCode(StatusCodes.Status400BadRequest);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
