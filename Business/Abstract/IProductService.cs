using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max); //Bu fiyat aralığında olan ürünleri getir.
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);

        //Uygulamalarda tutarlılığı korumak için yaptığımız bir yöntem. Örneğin hesabımızda 100₺ para var ve başka hesaba 10₺ para aktaracağım. Benim hesabımda 10₺ düşecek şekilde update edilmesi. Karşıdaki adamın da 10₺ hesabının artacağı şekilde update edilmesi. Benim hesabımdan para eksilirken(düşerken) gönderdiğim kişiye eklenecekken sistem hata verdi. Bu yüzden işlemi geri alması gerekmektedir.
        IResult AddTransactionalTest(Product product);
    }
}
