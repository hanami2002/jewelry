using Services.AccountRepository;

namespace API.Config
{
    public static class ServiceRegister
    {
        public static void Register(this IServiceCollection services) {
            services.AddScoped</*IAccountRepository,*/ AccountRepository>();

        }
    }
}
