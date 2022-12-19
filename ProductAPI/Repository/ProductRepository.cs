using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext productDbContext;
        public ProductRepository(ProductDbContext _productDbContext)
        {
            productDbContext = _productDbContext;
        }

        public async Task<Product> Add(Product product)
        {
            productDbContext.Products.Add(product);
            await productDbContext.SaveChangesAsync();
            return product;
        }

        public bool Delete(int id)
        {
            bool result = false;

            var product = productDbContext.Products.Find(id);

            if (product != null)
            {
                productDbContext.Products.Remove(product);
                productDbContext.SaveChangesAsync();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await productDbContext.Products.FindAsync(id);
        }
        public async Task<Product> Update(Product product)
        {
            productDbContext.Entry(product).State = EntityState.Modified;
            await productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await productDbContext.Products.ToListAsync();
        }
    }
}
