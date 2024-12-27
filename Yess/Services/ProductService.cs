using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System.ComponentModel;
using System;
using Yess.Data;
using Yess.Models;
using System.Linq;

namespace Yess.Services
{
    public class ProductService(AppDbContext context) : IProductService
    {
        private readonly AppDbContext _context = context;
        private readonly int ProductId;

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public Product GetProductById(int Productid)
        {
            return _context.Products
                //.Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == ProductId);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Category.ToList();
        }
        public Category GetCategoryById(int ProductId)
        {
            return _context.Category.FirstOrDefault(c => c.CategoryId == ProductId);
        }
        public void DeleteProduct(int ProductId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        //public void UpdateProduct(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        public void UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.CategoryId = product.CategoryId;
                _context.SaveChanges();
            }
            
        }

        //public List<Category> GetAllCategories()
        //{
        //    return _context.Category.ToList();
        //}
        //List<Product> IProductService.GetAllProducts()
        //{
        //    return _context.Products
        //        .ToList();
        //}


    }
}



