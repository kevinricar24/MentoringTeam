

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Backend.DependencyResolution
{
    public static class DependencyInjectionRegistry
    {

        public static void AddPersistence(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var AzureKeyVault = builder.Configuration["AzureKeyVault"];
            var secretsClient = new SecretClient(new Uri(AzureKeyVault), new DefaultAzureCredential());

            string connectionString = secretsClient.GetSecret("mentoring-keyvault-connectionstring").Value.Value.ToString();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }


    }
}
