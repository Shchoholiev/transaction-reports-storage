using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionReportsStorage.Infrastructure;
using TransactionReportsStorage.Infrastructure.DataInitializer;

namespace TransactionReportsStorage.UIDevExpress
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider;

        public static IConfiguration Configuration;

        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton<Form1>();
            services.AddInfrastructure(Configuration);
            services.AddServices();
            services.AddLogging(builder => builder.AddLogger(Configuration));
            ServiceProvider = services.BuildServiceProvider();

            DbInitializer.InitializeDb(ServiceProvider);

            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }
    }
}
