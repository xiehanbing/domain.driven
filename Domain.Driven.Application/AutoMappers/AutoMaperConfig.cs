using AutoMapper;

namespace Domain.Driven.Application.AutoMappers
{
    /// <summary>
    /// 静态全局 automapper 配置文件
    /// </summary>
    public class AutoMaperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            //创建automapperconfiguration ，提供静态方法 configure 一次加载所有层中profile定义
            //mapperconfiguration 实例 可以静态存储在一个静态字段中，也可以存储在一个 依赖注入容器中。 一旦创建，不能更改/修改
            return new MapperConfiguration(cfg =>
            {
                //这是个领域模型 -》视图模型 的映射 是读命令
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                //这是个 视图模型-》领域模型 的映射 是写命令
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}