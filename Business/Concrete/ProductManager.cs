using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;
        //ProductManager newlendiğinde bana bir tane IProductDal referansı ver. Bugün entityframework ertesi gün docker olabilir. Hepsi aynı referansı tutacak sonuçta.
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //encrypt => verinin şifrelenmesi, decrypt => şifrelenen verinin çözülmesi

        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Sınıfın en sonunda tanımladığımız iş kuralı parçacığı (metot) success döndürüyor ve aynı isimde ürün eklenemez ise ekleme işlemini yap
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded(product.CategoryId));
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 21)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(c => c.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId);
            if (result.Count > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }

        //Bu metot sadece bu class içerisinde kullanılmasını istediğimiz için private yaptık. Eğer bu metodu farklı managerlarda kullancaksak sakın bunu public e çekme. Öyle bir senaryo durumunda zaten bu bir service olur.
        //Bu bir iş kuralı parçacığı olduğu için 'category id' parametresi gönderdik.
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Select count(*) from products where CategoryId=1 => aşağıdaki kodun veritabanına gönderildiği hali
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        //Eklenecek ürün adında hali hazırda bir ürün var mı?
        private IResult CheckIfProductNameExists(string productName)
        {
            //Any() => var mı? Var ise result true döner.
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        //Eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez.
        private IResult CheckIfCategoryLimitExceded(int categoryId)
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
