using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//Data Transformation Object
ProductTest();
//IoC
//CategoryTest();

static void ProductTest()
{
    //SOLID
    //SOLID'in O'su: Open Closed Principle => Yeni bir özellik ekliyorsan, mevcuttaki hiçbir koda dokunamazsın. Biz de aşağıda ProductManager içerisinde InMemoryProductDal'dan vazgeçip EfProductDal kullandık.

    ProductManager productManager = new ProductManager(new EfProductDal());

    var result = productManager.GetProductDetails();
    if (result.Success == true)
    {
        foreach (var product in result.Data)
        {
            Console.WriteLine(product.ProductName + " --- " + product.CategoryName);
        }
    }
    else
    {
        {
            Console.WriteLine(result.Message);
        }
    }


    //foreach (var product in productManager.GetProductDetails())
    //{
    //    Console.WriteLine(product.ProductName + " --- " + product.CategoryName);
    //}

    //productManager.Add(new Product
    //{
    //    CategoryId = 1,
    //    ProductName = "DENEME",
    //    UnitPrice = 99999,
    //    UnitsInStock = 31
    //});
    //Console.WriteLine("**********************************************************************************************************************");

    //foreach (var product in productManager.GetProductDetails())
    //{
    //    Console.WriteLine(product.ProductName + " --- " + product.CategoryName);
    //}
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}