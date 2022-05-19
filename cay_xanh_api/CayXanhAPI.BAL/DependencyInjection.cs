using CayXanhAPI.BAL.Interfaces;
using CayXanhAPI.BAL.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CayXanhAPI.BAL
{
    public static class DependencyInjection
    {
        //public static IServiceCollection AddApplication(this IServiceCollection services)
        //{
        //    services.AddMediatR(Assembly.GetExecutingAssembly());
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //   // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //    return services;
        //}

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<INhomNhanVienRepository, NhomNhanVienRepository>();
            services.AddTransient<INhanVienRepository, NhanVienRepository>();
            services.AddTransient<ICayCamTrongRepository, CayCamTrongRepository>();
            services.AddTransient<IDanhMucDungChungRepository, DanhMucDungChungRepository>();
            services.AddTransient<IDanhMucDungChungChiTietRepository, DanhMucDungChungChiTietRepository>();
            return services;
        }
    }

    //public static class DependencyInjection
    //{
    //    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    //    {
    //        services.AddTransient<ITaskRepository, TaskRepository>();
    //        services.AddTransient<IUnitOfWork, UnitOfWork>();
    //        return services;
    //    }
    //}
}
