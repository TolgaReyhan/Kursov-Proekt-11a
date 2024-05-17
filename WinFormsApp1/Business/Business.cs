using Data;
using Data.Models;
using System.Linq;

namespace Business
{
    public class ProductBusiness
    {
            private ProductDbContext productContext;
            public List<Product> GetAll()
            {
                using (productContext = new ProductDbContext())
                {
                    return productContext.Products.ToList();
                }
            }
            public Product Get(int id)
            {
                using (productContext = new ProductDbContext())
                {
                    return productContext.Products.Find(id);
                }
            }
            public void Add(Product product)
            {
                using (productContext = new ProductDbContext())
                {
                    productContext.Products.Add(product);
                    productContext.SaveChanges();
                }
            }
            public void Update(Product product)
            {
                using (productContext = new ProductDbContext())
                {
                    var item = productContext.Products.Find(product.Id);
                    if (item != null)
                    {
                        productContext.Entry(item).CurrentValues.SetValues(product);
                        productContext.SaveChanges();
                    }
                }
            }
            public void Delete(int id)
            {
                using (productContext = new ProductDbContext())
                {
                    var product = productContext.Products.Find(id);
                    if (product != null)
                    {
                        productContext.Products.Remove(product);
                        productContext.SaveChanges();
                    }
                }
            }
    }
}
