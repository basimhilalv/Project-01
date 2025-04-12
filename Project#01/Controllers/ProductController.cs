﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_01.Models;
using Project_01.Services;

namespace Project_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet("get{id}")]
        public async Task<ActionResult<Product>> Getproduct(int id)
        {
            var product = await _productServices.GetProduct(id);
            if (product is null) return NotFound("The product deos not exist");
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Getproducts()
        {
            var products = await _productServices.GetProducts();
            if (products is null) return NotFound("There are no products available");
            return Ok(products);
        }
        [HttpGet("{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products = await _productServices.GetProductsByCategory(category);
            if (products is null) return NotFound("There are no products in the category");
            return Ok(products);
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Product>> AddProduct(ProductDto request)
        {
            var create = await _productServices.AddProduct(request);
            if (create is null) return BadRequest("Product already exist");
            return Ok(create);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, ProductDto request)
        {
            var update = await _productServices.UpdateProduct(id, request);
            if (update is null) return BadRequest("Product not available");
            return Ok(update);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var delete = await _productServices.DeleteProduct(id);
            if (delete is null) return NotFound("Product not available");
            return NoContent();
        }
    }
}
