using System;
using System.Linq;
using System.Reflection;
using System.Web;
using BusinessLogic;
using BusinessLogic.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebForm.DI
{
    public class DiFactory : IDiFactory
    {
        private readonly ServiceProvider _serviceProvider;

        public DiFactory()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IDiFactory, DiFactory>();
            services.AddBusinessLogicServices();
            services.AddTransient<IConfigurationService, ConfigurationManagerService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public object GetService(Type propPropertyType)
        {
            return _serviceProvider.GetService(propPropertyType);
        }

        public void DiPropetiesForWebForm(IHttpHandler page, IDiFactory container)
        {
            var properties = GetInjectableProperties(page.GetType());

            foreach (var prop in properties)
            {
                try
                {
                    var service = container.GetService(prop.PropertyType);
                    if (service != null)
                    {
                        // DI Property
                        prop.SetValue(page, service);
                    }
                }
                catch (Exception)
                {
                    // DiFactory 沒辦法解析的型別
                }
            }
        }

        private static PropertyInfo[] GetInjectableProperties(Type type)
        {
            var props = type.GetProperties(BindingFlags.Public
                                         | BindingFlags.Instance
                                         | BindingFlags.DeclaredOnly);
            if (props.Length == 0)
            {
                // 傳入的型別若是由 ASPX 頁面所生成的類別，那就必須取得其父類別（code-behind 類別）的屬性。
                props = type.BaseType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            }

            return props;
        }
    }
}