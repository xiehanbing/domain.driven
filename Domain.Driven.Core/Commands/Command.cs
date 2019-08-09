using System;
using FluentValidation.Results;
using MediatR;

namespace Domain.Driven.Core.Commands
{
    /// <summary>
    /// 抽象命令基类
    /// </summary>
    public abstract class Command:IRequest
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime Timestamp { get;private set; }
        /// <summary>
        /// 验证结果，需要引用 FluentValidation
        /// </summary>
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp=DateTime.Now;
        }
        /// <summary>
        /// 定义抽象方法，是否有效
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();
    }
}