using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceremedullum.Exe.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Ceremedullum.Exe.Services
{
    public class AppServices
    {
        public AppServices()
        {
            var services = new ServiceCollection();

            // View model
            //services.AddTransient<>

            //services
            services.AddTransient<IUserAccount, UserAccount>();
            ServiceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider {  get; }

        private static AppServices _instance;
        private static readonly object _instanceLock = new object();

        private static AppServices GetInstance()
        {
            lock (_instanceLock)
            {
                return _instance ?? (_instance = new AppServices());
            }
        }

        public static AppServices Instance => _instance ?? GetInstance();
    }
}
