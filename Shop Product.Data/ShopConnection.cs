using System.Linq;

namespace Shop_Product.Data
{
    public class ShopConnection
    {
        public void UpdateProduct(string name, decimal price, string currency, int stock)
        {
            using (var shopEntities = new ShopEntities())
            {
                var existingProduct = shopEntities.Products.FirstOrDefault(x => x.Name == name);

                if (existingProduct != null)
                    existingProduct.Stock += stock;
                else
                {
                    shopEntities.Products.Add(new Product()
                    {
                        Name = name,
                        Price = price,
                        Currency = currency,
                        Stock = stock
                    });
                }

                shopEntities.SaveChanges();
            }
        }
    }
}
