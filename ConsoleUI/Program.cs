using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;


//SOLID
//SOLID'in O'su: Open Closed Principle => Yeni bir özellik ekliyorsan, mevcuttaki hiçbir koda dokunamazsın. Biz de aşağıda ProductManager içerisinde InMemoryProductDal'dan vazgeçip EfProductDal kullandık.
ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var product in productManager.GetByUnitPrice(40, 100))
{
    Console.WriteLine(product.ProductName);
}

