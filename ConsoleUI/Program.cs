using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//Data Transformation Object
ProductTest();
//IoC
//CategoryTest();

static void ProductTest()
{
    //SOLID
    //SOLID'in O'su: Open Closed Principle => Yeni bir özellik ekliyorsan, mevcuttaki hiçbir koda dokunamazsın. Biz de aşağıda ProductManager içerisinde InMemoryProductDal'dan vazgeçip EfProductDal kullandık.

    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var product in productManager.GetProductDetails())
    {
        Console.WriteLine(product.ProductName + "/" + product.CategoryName);
    }
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}