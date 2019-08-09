using System;
using AutoMapper;
using Domain.Driven.Application.AutoMappers;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Driven.Ui.Extensions
{
    /// <summary>
    /// automapper 启动服务
    /// </summary>
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
            {
                //是否为空，抛出异常
                throw new ArgumentNullException(nameof(services));
            }
            //添加服务
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddAutoMapper();
            //启动配置
            var config=AutoMaperConfig.RegisterMappings();
            config.CreateMapper();
        }
    }
}