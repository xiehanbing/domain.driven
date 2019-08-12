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
using Domain.Driven.Domain.Interfaces.ReadRepository;
using Domain.Driven.Domain.Interfaces.WriteRepository;
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
        private readonly IWriteStudentRepository _writeStudentRepository;
        private readonly IReadStudentRepository _readStudentRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        public StudentAppService(IWriteStudentRepository writeStudentRepository,
            IReadStudentRepository readStudentRepository,
            IMapper mapper, IMediatorHandler bus)
        {
            _writeStudentRepository = writeStudentRepository;
            _readStudentRepository = readStudentRepository;
            _mapper = mapper;
            _bus = bus;
        }
        public async Task<IEnumerable<StudentViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudentViewModel>>(await _readStudentRepository.GetAllAsync());
        }

        public async Task<StudentViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<StudentViewModel>(await _readStudentRepository.GetByIdAsync(id));
        }

        public async Task AddAsync(StudentViewModel viewModel)
        {
            viewModel.User = "xiehanbing";
            var registerCommand = _mapper.Map<RegisterStudentCommand>(viewModel);
            await _bus.SendCommand(registerCommand);
        }

        public async Task UpdateAsync(StudentViewModel viewModel)
        {
            viewModel.User = "xiehanbing";
            var updateCommand = _mapper.Map<UpdateStudentCommand>(viewModel);
            await _bus.SendCommand(updateCommand);
        }

        public async Task RemoveAsync(Guid id)
        {
            var removeCommand =new RemoveStudentCommand(id)
            {
                User = "xiehanbing"
            };
            await _bus.SendCommand(removeCommand);
        }
    }
}