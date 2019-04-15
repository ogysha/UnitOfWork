using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UnitOfWork;
using EF = UnitOfWork.EF;
using NH = UnitOfWork.NH;

namespace Application
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("###NHibernate###");

            using (NH.UnitOfWork uow = new NH.UnitOfWork())
            {
                CustomerService customerServiceWithNH = new CustomerService(uow, new NH.Repository<Customer>(uow));

                try
                {
                    CustomerDto customerDto = customerServiceWithNH.Add("NH First Name", Guid.NewGuid().ToString().Substring(0, 7));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("###Entity Framework###");

            using (var context = new EF.ECommerceContextFactory().CreateDbContext(args))
            using (var uow = new EF.UnitOfWork(context))
            {
                context.Database.Migrate();

                var customerServiceWithEF = new CustomerService(uow, new EF.Repository<Customer>(uow));

                try
                {
                    CustomerDto customerDto = customerServiceWithEF.Add("EF First Name", Guid.NewGuid().ToString().Substring(0, 7));

                    customerServiceWithEF.GetAll()
                        .ToList()
                        .ForEach(Console.WriteLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}