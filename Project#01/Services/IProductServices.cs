﻿using Project_01.Models;

namespace Project_01.Services
{
    public interface IProductServices
    {
        public Task<Product> GetProduct(int id);
        public Task<IEnumerable<Product>> GetProducts();
        public Task<IEnumerable<Product>> GetProductsByCategory(string category);
        public Task<Product> AddProduct(ProductDto request);
        public Task<Product> UpdateProduct(int id, ProductDto request);
        public Task<Product> DeleteProduct(int id);
    }
}
