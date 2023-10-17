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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using(RentCarDBContext context=new RentCarDBContext()) {
                try
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Hata: " + ex.InnerException.Message);
                    }

                }
            }
        }

        public void Delete(Car entity)
        {
            using (RentCarDBContext context = new RentCarDBContext()) {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentCarDBContext context = new RentCarDBContext()) {

                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarDBContext context = new RentCarDBContext()) {

                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentCarDBContext context = new RentCarDBContext()) {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
