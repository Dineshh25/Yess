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
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context ;
        private readonly int ProductId;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == productId);
            

        }


        public PagedResult<Product> GetPagedProducts(int pageNumber, int pageSize)
        {
            var totalItems = _context.Products.Count();
            var products = _context.Products
                .Skip((pageNumber - 1) * pageSize)  // Skip items from previous pages
                .Take(pageSize)  // Take the items for the current page
                .ToList();

            return new PagedResult<Product>
            {
                Items = products,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            existingProduct.ProductName = product.ProductName;
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Category.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Category.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        



    }




    }
//}



