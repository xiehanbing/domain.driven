using AutoMapper;
using Domain.Driven.Application.ViewModels;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Application.AutoMappers
{
    /// <summary>
    /// 实体转换配置  domain to view model
    /// </summary>
    public class DomainToViewModelMappingProfile:Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(d=>d.County,o=>o.MapFrom(s=>s.Address.County))
                .ForMember(d => d.Province, o => o.MapFrom(s => s.Address.Province))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Address.Street))
                .ForMember(d => d.Zip, o => o.MapFrom(s => s.Address.Zip))
                ;
        }
    }
}