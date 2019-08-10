using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Driven.Application.Interfaces;
using Domain.Driven.Application.ViewModels;
using Domain.Driven.Core.Bus;
using Domain.Driven.Domain.Commands.Student;
using Domain.Driven.Domain.Interfaces;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Application.Services
{
    /// <summary>
    /// StudentAppService 服务接口实现类,继承 服务接口
    /// 通过 DTO 实现视图模型和领域模型的关系处理
    /// 作为调度者，协调领域层和基础层，
    /// 这里只是做一个面向用户用例的服务接口,不包含业务规则或者知识
    /// </summary>
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public StudentAppService(IStudentRepository studentRepository,
            IMapper mapper, IMediatorHandler bus)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _bus = bus;
        }
        public async Task<IEnumerable<StudentViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudentViewModel>>(await _studentRepository.GetAllAsync());
        }

        public async Task<StudentViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<StudentViewModel>(await _studentRepository.GetByIdAsync(id));
        }

        public async Task AddAsync(StudentViewModel viewModel)
        {
            viewModel.User = "xiehanbing";
            var registerCommand = _mapper.Map<RegisterStudentCommand>(viewModel);
            await _bus.SendCommand(registerCommand);
            //return _mapper.Map<StudentViewModel>(await _studentRepository.AddAsync(_mapper.Map<Student>(viewModel)));
        }

        public async Task<bool> UpdateAsync(StudentViewModel viewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(viewModel));
            return (await _studentRepository.SaveChangesAsync()) > 0;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            _studentRepository.Remove(id);
            return (await _studentRepository.SaveChangesAsync()) > 0;
        }
    }
}