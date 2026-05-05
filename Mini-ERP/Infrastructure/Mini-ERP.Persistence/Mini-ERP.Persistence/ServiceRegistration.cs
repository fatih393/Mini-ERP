using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mini_ERP.Application.Abstractions.Services;
using Mini_ERP.Application.Repostories;
using Mini_ERP.Persistence.Contexts;
using Mini_ERP.Persistence.Repostories;
using Mini_ERP.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Mini_ErpAPIContext>(options => options.UseOracle(Configuration.ConnectionString));


            //////////////////////////SERVİCES///////////////////
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMilkCollectionService, MilkCollectionService>();
            services.AddScoped<IStockService , StockService >();
            services.AddScoped<IProductionService, ProductionService>();


            ///////////////////// REPOS ///////////////////
            services.AddScoped<ISupplierReadRepository, SupplierReadRepository>();
            services.AddScoped<ISupplierWriteRepository, SupplierWriteRepository>();
            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
            services.AddScoped<IMilkCollectionReadRepository, MilkCollectionReadRepository>();
            services.AddScoped<IMilkCollectionWriteRepository, MilkCollectionWriteRepository>();
            services.AddScoped<IStockReadRepository, StockReadRepository>();
            services.AddScoped<IStockWriteRepository, StockWriteRepository>();
            services.AddScoped<IProductionReadRepository, ProductionReadRepository>();
            services.AddScoped<IProductionWriteRepository, ProductionWriteRepository>();
        }
    }
}
