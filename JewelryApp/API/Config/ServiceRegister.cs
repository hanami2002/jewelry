using Services.AccountRepository;
using Services.ActivityRepository;
using Services.CategoryRepository;
using Services.ChecklogRepository;
using Services.DetailRepository;
using Services.PagingRepository;
using Services.ProductRepository;
using Services.OderRepository;
using System.ComponentModel.Design;
using Utilities;

namespace API.Config
{
    public static class ServiceRegister
    {
        public static void Register(this IServiceCollection services) {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped</*IAccountRepository,*/ ActivityRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped</*IAccountRepository,*/ ChecklogRepository >();
            services.AddScoped<IOrderRepository,OrderRepository >();
            services.AddScoped< IDetailRepository, DetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<PagingRepository>();
            //services.AddScoped<IEmailService, EmailService>();

        }
    }
}
