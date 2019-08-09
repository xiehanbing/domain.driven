using System.Collections.Generic;
using Domain.Driven.Core.Bus;
using Domain.Driven.Core.Commands;
using Domain.Driven.Core.Notifications;
using Domain.Driven.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Driven.Domain.CommandHandlers
{
    /// <summary>
    /// 领域命令处理程序
    /// 用来作为全部处理程序的基类
    /// 提供公共方法和接口数据
    /// </summary>
    public class CommandHandler<TContext> where TContext : DbContext
    {
        /// <summary>
        /// 注入工作单元
        /// </summary>
        private readonly IUnitOfWork<TContext> _unitOfWork;
        /// <summary>
        /// 注入中介处理接口
        /// </summary>
        private readonly IMediatorHandler _bus;
        /// <summary>
        /// 注入缓存 用来存储错误信息 （目前是错误方法，以后用领域通知替换）
        /// </summary>
        private readonly IMemoryCache _cache;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="bus"></param>
        /// <param name="cache"></param>
        public CommandHandler(IUnitOfWork<TContext> unitOfWork, IMediatorHandler bus, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
            _cache = cache;
        }
        /// <summary>
        /// 工作单元提交
        /// 如果有错误  下一步将在这里添加领域通知
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            if (_unitOfWork.Commit()) return true;
            return false;
        }
        /// <summary>
        /// 将领域命令中的验证错误信息收集
        /// 目前用的是缓存方法（以后通过领域通知替换）
        /// </summary>
        /// <param name="message"></param>
        protected void NotifyValidationErrors(Command message)
        {
            List<string> errorInfo = new List<string>(); foreach (var error in message.ValidationResult.Errors)
            {
                errorInfo.Add(error.ErrorMessage);

            } //将错误信息收集
            _cache.Set("ErrorData", errorInfo);
        }
    }

    /// <summary>
    /// 领域命令处理程序
    /// 用来作为全部处理程序的基类
    /// 提供公共方法和接口数据
    /// </summary>
    public class CommandHandler
    {
        /// <summary>
        /// 注入工作单元
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// 注入中介处理接口
        /// </summary>
        private readonly IMediatorHandler _bus;
        /// <summary>
        /// 注入缓存 用来存储错误信息 （目前是错误方法，以后用领域通知替换）
        /// </summary>
        private readonly IMemoryCache _cache;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="bus"></param>
        /// <param name="cache"></param>
        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
            _cache = cache;
        }
        /// <summary>
        /// 工作单元提交
        /// 如果有错误  下一步将在这里添加领域通知
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            if (_unitOfWork.Commit()) return true;
            return false;
        }
        /// <summary>
        /// 将领域命令中的验证错误信息收集
        /// 目前用的是缓存方法（以后通过领域通知替换）
        /// </summary>
        /// <param name="message"></param>
        protected void NotifyValidationErrors(Command message)
        {
            //List<string> errorInfo = new List<string>();
            foreach (var error in message.ValidationResult.Errors)
            {
                //errorInfo.Add(error.ErrorMessage);
                _bus.RaiseEvent(new DomainNotification("", error.ErrorMessage));
            } //将错误信息收集
            //_cache.Set("ErrorData", errorInfo);
        }
    }
}