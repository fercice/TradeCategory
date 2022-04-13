using Microsoft.Extensions.DependencyInjection;
using TradeCategory.Application.Interfaces;
using TradeCategory.Application.Services;

namespace TradeCategory.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<ITradeAppService, TradeAppService>();
            services.AddScoped<ITradeCategoryAppService, TradeCategoryAppService>();
        }
    }
}