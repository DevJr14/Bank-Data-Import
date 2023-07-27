using Application.Services;
using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddTransient<IBankAccountService, BankAccountService>()
                .AddTransient<ITransactionService, TransactionService>()
                .AddTransient<IReportService, ReportService>()
                .AddTransient<IImportService, ImportService>()
                .AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}