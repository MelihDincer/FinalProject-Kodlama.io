using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        //IDisposable pattern implementation of C#
        public void Add(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //Referansı yakala
                addedEntity.State = EntityState.Added; //O aslında eklenecek bir nesne
                context.SaveChanges();//Kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //Referansı yakala
                deletedEntity.State = EntityState.Deleted; //O aslında silinecek bir nesne
                context.SaveChanges();//Kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using(NorthwindContext  context = new NorthwindContext()) 
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //Referansı yakala
                updatedEntity.State = EntityState.Modified; //O aslında güncellenecek bir nesne
                context.SaveChanges();//Kaydet
            }
        }
    }
}
