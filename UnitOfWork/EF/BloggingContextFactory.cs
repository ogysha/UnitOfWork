using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UnitOfWork.EF
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<ECommerceContext>
    {
        public ECommerceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ECommerceContext>()
                .UseSqlite(@"Data Source=e-commerce.db");

            return new ECommerceContext(optionsBuilder.Options);
        }
    }
}