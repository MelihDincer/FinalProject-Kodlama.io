using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        //ProductManager newlendiğinde bana bir tane IProductDal referansı ver. Bugün entityframework ertesi gün docker olabilir. Hepsi aynı referansı tutacak sonuçta.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(c => c.CategoryId == id).ToList();
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
