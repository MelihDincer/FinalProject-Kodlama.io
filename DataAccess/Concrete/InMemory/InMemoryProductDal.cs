using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice=15, UnitsInStock = 15},
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Kamera", UnitPrice=500, UnitsInStock = 3},
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Telefon", UnitPrice=1500, UnitsInStock = 2},
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Klavye", UnitPrice=150, UnitsInStock = 65},
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Fare", UnitPrice=85, UnitsInStock = 1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query (Dile Gömülü Sorgu)

            //Linq bilmediğimizi varsayalım burada.
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if(p.ProductId == product.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

            //Burada ise Linq bildiğimizi varsayalım.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //Ürünü bulduk.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
