using Microsoft.EntityFrameworkCore;
using Shop.BLL.Services.Interfaces;
using Shop.DAL.Models;
using Shop.DAL.Repositories.Interfaces;
using Shop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async  Task<Product> CheapestAsync()
        {
            return await _productRepository.GetAll().OrderBy(p => p.Price).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _productRepository.GetAll().CountAsync();
        }


        public async Task DeleteAllAsync()
        {
            await _productRepository.DeleteAllAsync();

        }

        public  async Task DeleteAsync(int productId)
        {
            await _productRepository.DeleteAsync(productId);
        }

        public async Task<Product> ExpensivestAsync()
        {
            return await _productRepository.GetAll().OrderByDescending(p=>p.Price).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAll().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }

        public async Task<List<Product>> GetFilteredAsync(ProductFilterDto filter)
        {
            var products = _productRepository.GetAll();

            products = products.Skip((filter.pageIndex - 1) * filter.pageSize).Take(filter.pageSize);

            if ((int)filter.sortField == 1)
            {
                products = products.OrderBy(p => p.Price);
            }
            if ((int)filter.sortField == 0)
            {
                products = products.OrderBy(p => p.Name.ToLower());
            }

            if((int)filter.sort == 1)
            {
                products = products.Reverse();
            }

            return await products.ToListAsync();
        }

        public async Task InsertAsync(Product product)
        {
            await _productRepository.InsertAsync(product);
        }

        public async Task<Product> MedianAsync()
        {
            int count = _productRepository.GetAll().Count();
            var products = await _productRepository.GetAll().OrderBy(p=>p.Price).ToListAsync();
            if (count == 1)
                return  products.FirstOrDefault();
            return products.Skip((int)(count / 2)).Take(1).First();
        }
    }
}
