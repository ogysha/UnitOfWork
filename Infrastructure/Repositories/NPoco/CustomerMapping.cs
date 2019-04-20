using Infrastructure.Entities;
using NPoco.FluentMappings;

namespace Infrastructure.Repositories.NPoco
{
    public class CustomerMapping : Map<Customer>
    {
        public CustomerMapping()
        {
            PrimaryKey(x => x.Id);
            TableName(nameof(Customer));
            Columns(x =>
            {
                x.Column(y => y.FirstName);
                x.Column(y => y.LastName);
                x.Column(y => y.Created).ForceToUtc(true);
                x.Column(y => y.LastUpdate).ForceToUtc(true);
            });
        }
    }
}