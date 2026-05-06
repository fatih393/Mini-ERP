using Microsoft.Extensions.DependencyInjection;
using Mini_EEP.Infrastructure.Services;
using Mini_ERP.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_EEP.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IQRCodeService, QRCodeService>();
        }
    }
}
