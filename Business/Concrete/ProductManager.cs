using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //
        private IProductDal _productDal;
        //ProductManager newlendiğinde bana bir tane IProductDal referansı ver. Bugün entityframework ertesi gün docker olabilir. Hepsi aynı referansı tutacak sonuçta.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }
    }
}
