using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace PropertyRental.Infrastructure
{
    public static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            InitializeLocalMongoDBConnection(services);

            return services;
        }

        private static void InitializeLocalMongoDBConnection(IServiceCollection services)
        {
            MongoDbClassMap.Initialize();

            RegisterMongoClient(services);
        }

        private static void RegisterMongoClient(IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(services =>
            {
                var settings = services.GetRequiredService<MongoDbSettings>();

                string connectionString =
                    $"{settings.Address}/{settings.DatabaseName}?retryWrites=true&w=majority";

                return new MongoClient(connectionString);
            });
        }
    }
}