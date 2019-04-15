using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UnitOfWork.EF;

namespace Application
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("###Entity Framework###");

            using (var context = new ECommerceContextFactory().CreateDbContext(args))
            using (var uow = new UnitOfWork.EF.UnitOfWork(context))
            {
                context.Database.Migrate();

                var customerService = new CustomerService(uow, new Repository<Customer>(uow));

                try
                {
                    CustomerDto customerDto = customerService.Add("EF First Name", Guid.NewGuid().ToString().Substring(0, 7));

                    customerService.GetAll()
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