using AutoMapper;
using Domain.Driven.Application.ViewModels;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Application.AutoMappers
{
    /// <summary>
    /// 实体转换配置
    /// </summary>
    public class DomainToViewModelMappingProfile:Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}