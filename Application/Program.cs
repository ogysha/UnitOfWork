using System;
using System.Linq;
using Infrastructure.Entities;
using Infrastructure.Repositories.EF;
using Infrastructure.Repositories.NPoco;
using Microsoft.EntityFrameworkCore;
using UnitOfWork = Infrastructure.Repositories.NPoco.UnitOfWork;

namespace Application
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("###NPoco###");

            using (var db = ECommerceDbFactory.CreateDb())
            using (var uow = new UnitOfWork(db))
            {
                var customerServiceWithEf =
                    new CustomerService(uow, new Infrastructure.Repositories.NPoco.BaseRepository<Customer>(uow));

                try
                {
                    var customerDto =
                        customerServiceWithEf.Add("EF First Name", Guid.NewGuid().ToString().Substring(0, 7));

                    customerServiceWithEf.GetAll()
                        .ToList()
                        .ForEach(Console.WriteLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("###Entity Framework###");

            using (var context = new ECommerceContextFactory().CreateDbContext(args))
            using (var uow = new Infrastructure.Repositories.EF.UnitOfWork(context))
            {
                context.Database.Migrate();

                var customerServiceWithEf =
                    new CustomerService(uow, new Infrastructure.Repositories.EF.BaseRepository<Customer>(uow));

                try
                {
                    var customerDto =
                        customerServiceWithEf.Add("EF First Name", Guid.NewGuid().ToString().Substring(0, 7));

                    customerServiceWithEf.GetAll()
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