using Microsoft.Extensions.DependencyInjection;
using PromotionsLib.Core;
using PromotionsLib.Core.PromotionLogics;
using PromotionsLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib
{
    public static class ConfigureDependency
    {
        public static void Configure(this IServiceCollection services) {
            services.AddTransient<IPromotionHandler, PromotionHandler>();
            services.AddScoped<IDBService, DBService>();
            services.AddTransient<Core.PromotionLogics.IPromotion,IndividualPromotion>();
            services.AddTransient<PromotionProcessor>();
        }
    }
}
