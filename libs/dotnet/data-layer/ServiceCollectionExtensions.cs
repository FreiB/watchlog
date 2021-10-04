using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchLog.Infra.Data.Abstract;
using WatchLog.Infra.Data.Services;

namespace WatchLog.Infra.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWatchLogDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IPointDataCreatorProvider, PointDataCreatorProvider>();
            services.AddSingleton<IDataService, DataService>();
        }
    }
}
