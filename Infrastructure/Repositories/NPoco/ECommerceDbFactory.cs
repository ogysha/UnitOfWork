using System.Data.Common;
using Microsoft.Data.Sqlite;
using NPoco;
using NPoco.FluentMappings;

namespace Infrastructure.Repositories.NPoco
{
    public static class ECommerceDbFactory
    {
        public static IDatabase CreateDb()
        {
            var fluentConfig = FluentMappingConfiguration.Configure(new CustomerMapping());

            var connectionStringBuilder = new DbConnectionStringBuilder(false)
            {
                {"Data Source", ":memory:"},
                {"Version", "3"}
            };
            var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);

            return DatabaseFactory
                .Config(x =>
                {
                    x.UsingDatabase(() => new Database(connection));
                    x.WithFluentConfig(fluentConfig);
                })
                .GetDatabase();
        }
    }
}