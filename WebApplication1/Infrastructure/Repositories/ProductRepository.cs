using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // private readonly AppDbContext _context;
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99M },
            new Product { Id = 2, Name = "Smartphone", Price = 499.99M },
            new Product { Id = 3, Name = "Headphones", Price = 199.99M },
            new Product { Id = 4, Name = "Monitor", Price = 299.99M },
            new Product { Id = 5, Name = "Keyboard", Price = 49.99M }
        };
        //AppDbContext context
        public ProductRepository()
        {
            //     _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {

            return await Task.FromResult(_products);

            // await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Task.FromResult(_products.Find(x => x.Id == id));


            //   _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {

            _products.Add(product);
            //   await _context.Products.AddAsync(product);
            //   await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {

            // _context.Products.Update(product);
            //  await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _products.Remove(product);
                //  _context.Products.Remove(product);
                //  await _context.SaveChangesAsync();
            }
        }
    }
}
