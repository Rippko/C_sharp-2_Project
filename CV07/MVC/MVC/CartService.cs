using MVC.Models;

namespace MVC
{
    public class CartService
    {
        private List<Product> products = new List<Product>();

        public void Add(Product product)
        {
            products.Add(product);
        }
        public int Count { get { return products.Count; } }

    }
}
