using System;
using System.Linq;
using System.Reflection;
using BusinessLogic.Options;
using BusinessLogic.Order;
using BusinessLogic.Products;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class DiHelper
    {
        public static void AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IOptionsService, OptionsService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            // var serviceTypes = Assembly.Load("BusinessLogic")
            //                            .GetTypes()
            //                            .Where(i => i.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase))
            //                            .ToArray();
            //
            // foreach (var interfaceType in serviceTypes.Where(t => t?.IsInterface ?? false))
            // {
            //     var implementClassType = serviceTypes.FirstOrDefault(t => t.IsInterface == false
            //                                                            && interfaceType.IsAssignableFrom(t)
            //                                                            && !t.IsInterface && !t.IsAbstract);
            //     if (implementClassType != null)
            //     {
            //         typeof(ServiceCollectionServiceExtensions)
            //            .GetMethods()
            //            .FirstOrDefault(m => m.Name.Equals("AddTransient", StringComparison.CurrentCultureIgnoreCase)
            //                              && m.IsGenericMethod
            //                              && m.GetParameters().Length == 1)
            //           ?.MakeGenericMethod(interfaceType, implementClassType)
            //            .Invoke(null, new object[] { services });
            //     }
            // }
        }
    }
}
