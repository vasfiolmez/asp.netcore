using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms_Application.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();
        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Telefon" });
            _categories.Add(new Category { CategoryId = 2, Name = "Bilgisayar" });

            _products.Add(new Product { CategoryId = 1, Name = "Iphone 14", Image = "1.jpg", İsActive = true, Price = 40000, ProductId = 1 });
            _products.Add(new Product { CategoryId = 1, Name = "Iphone 15", Image = "2.jpg", İsActive = false, Price = 60000, ProductId = 2 });
            _products.Add(new Product { CategoryId = 1, Name = "Iphone 10", Image = "3.jpg", İsActive = true, Price = 10000, ProductId = 3 });

            _products.Add(new Product { CategoryId = 2, Name = "Macbook Air ", Image = "5.jpg", İsActive = false, Price = 30000, ProductId = 4 });
            _products.Add(new Product { CategoryId = 2, Name = "Macbook Pro ", Image = "6.jpg", İsActive = true, Price = 30000, ProductId = 5 });
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        public static void CreateProduct(Product entity)
        {
            _products.Add(entity);
        }
        public static void EditProduct(Product updateProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updateProduct.ProductId);

            if (entity != null)
            {
                entity.Name = updateProduct.Name;
                entity.Price = updateProduct.Price;
                entity.Image = updateProduct.Image;
                entity.İsActive = updateProduct.İsActive;
                entity.CategoryId = updateProduct.CategoryId;
            }
        }
        public static void EditIsActive(Product updateProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updateProduct.ProductId);

            if (entity != null)
            {

                entity.İsActive = updateProduct.İsActive;

            }
        }

        public static void DeleteProduct(Product deletedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == deletedProduct.ProductId);
            if (entity != null)
            {
                _products.Remove(entity);
            }

        }
        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}