﻿using MVC.Models;

namespace MVC
{
    public class ProductService
    {
        public IEnumerable<Product> List()
        {
            return Product.GetProducts();
        }
        public Product Find(int id)
        {
            return Product.GetProducts().FirstOrDefault(x => x.Id == id);
        }

    }
}
