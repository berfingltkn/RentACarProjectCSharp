using Core.DataAccess.EntityFramework;
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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,RentCarDBContext>,ICustomerDal
    {
        public void Add(Customer entity)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
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

        public void Delete(Customer entity)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                var customerEntity = context.Entry(entity);
                customerEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Customer entity)
        {
            using(RentCarDBContext context=new RentCarDBContext())
            {
                var customerUpdate = context.Entry(entity);
                customerUpdate.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {

                return context.Set<Customer>().SingleOrDefault(filter);
            }
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {

                return filter == null ? context.Set<Customer>().ToList() : context.Set<Customer>().Where(filter).ToList();
            }
        }

      
    }
}
