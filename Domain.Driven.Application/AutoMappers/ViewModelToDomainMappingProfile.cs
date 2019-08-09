using AutoMapper;
using Domain.Driven.Application.ViewModels;
using Domain.Driven.Domain.Commands.Student;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Application.AutoMappers
{
    /// <summary>
    /// view model to domain
    /// </summary>
    public class ViewModelToDomainMappingProfile:Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<StudentViewModel, Student>()
            //    .ForPath(d=>d.Address.Province,o=>o.MapFrom(s=>s.Province))
            //    .ForPath(d => d.Address.Province, o => o.MapFrom(s => s.Province))
            //    .ForPath(d => d.Address.City, o => o.MapFrom(s => s.City))
            //    .ForPath(d => d.Address.County, o => o.MapFrom(s => s.County))
            //    .ForPath(d => d.Address.Street, o => o.MapFrom(s => s.Street))
            //    .ForPath(d => d.Address.Zip, o => o.MapFrom(s => s.Zip));

            CreateMap<StudentViewModel, RegisterStudentCommand>()
                .ForPath(d => d.Address.Province, o => o.MapFrom(s => s.Province))
                .ForPath(d => d.Address.Province, o => o.MapFrom(s => s.Province))
                .ForPath(d => d.Address.City, o => o.MapFrom(s => s.City))
                .ForPath(d => d.Address.County, o => o.MapFrom(s => s.County))
                .ForPath(d => d.Address.Street, o => o.MapFrom(s => s.Street))
                .ForPath(d => d.Address.Zip, o => o.MapFrom(s => s.Zip));
        }

    }
}