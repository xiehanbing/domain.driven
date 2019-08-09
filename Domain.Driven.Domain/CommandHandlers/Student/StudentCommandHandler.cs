using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Driven.Core.Bus;
using Domain.Driven.Domain.Commands.Student;
using Domain.Driven.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Driven.Domain.CommandHandlers.Student
{
    /// <summary>
    ///  Student命令处理程序
    ///
    /// 用来处理该Student下的所有命令
    ///
    /// 注意必须要继承接口IRequestHandler<,>，这样才能实现各个命令的Handle方法
    /// </summary>
    public class StudentCommandHandler : CommandHandler, IRequestHandler<RegisterStudentCommand, Unit>,
        IRequestHandler<UpdateStudentCommand, Unit>, IRequestHandler<RemoveStudentCommand, Unit>
    {
        /// <summary>
        /// 注入仓储接口
        /// </summary>
        private readonly IStudentRepository _studentRepository;
        /// <summary>
        /// 注入总线
        /// </summary>
        private readonly IMediatorHandler _bus;
        private readonly IMemoryCache _cache;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="bus"></param>
        /// <param name="cache"></param>
        public StudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IMediatorHandler bus, IMemoryCache cache) : base(unitOfWork, bus, cache)
        {
            _studentRepository = studentRepository;
            _bus = bus;
            _cache = cache;
        }
        /// <summary>
        /// registerstudentcommand 命令的处理程序
        /// 整个命令处理程序的核心都在这里
        /// 不仅包括命令验证的收集，持久化，还有领域事件和通知的添加
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            //命令验证
            if (!request.IsValid())
            {
                //错误信息收集
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }

            var customer = new Models.Student(Guid.NewGuid(), request.Name, request.Email, request.Phone,
                request.BirthDate);
            customer.Address = request.Address;
            // 判断邮箱是否存在
            // 这些业务逻辑，当然要在领域层中（领域命令处理程序中）进行处理
            if (_studentRepository.GetByEmail(customer.Email) != null)
            {
                //这里☑错误信息进行发布 目前采用缓存形式
                List<string> errorInfo = new List<string>()
                {
                    "The customer e-mail has already been taken."
                };
                _cache.Set("ErrorData", errorInfo);
                return Task.FromResult(new Unit());
            }

            //持久化操作
            _studentRepository.Add(customer);
            //统一提交
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件 // 比如欢迎用户注册邮件呀，短信呀等 // waiting....
            }
            return Task.FromResult(new Unit());
        }
        /// <summary>
        /// 同上，UpdateStudentCommand 的处理方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 同上，RemoveStudentCommand 的处理方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}