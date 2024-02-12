using Core.Context;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductCartService
    {
        private readonly ProductContext context;

        public ProductCartService(ProductContext context)
        {
            this.context = context;
        }

        public async Task Add(Product product,int quantity)
        {
            var productCart = new ProductCart
            {
                Product = product,
                Quantity = quantity
            };

            this.context.ProductCarts.Add(productCart);
            await this.context.SaveChangesAsync();

        }

        public async Task Delete(string guid)
        {
            var cart = await this.context.ProductCarts.FindAsync(Guid.Parse(guid));
            if(cart is not null)
            {
                this.context.ProductCarts.Remove(cart);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductCart>> GetProducts()
        {
            return await this.context.ProductCarts.Include(p => p.Product).ToListAsync();
        }

        public async Task<IEnumerable<ProductCart>> GetProductSearch(string name)
        {
            return await this.context.ProductCarts
                .Include(p => p.Product)
                .Where(p => p.Product.Name == name)
                .ToListAsync();
        }





    }
}
