using System;
using MediatR;

namespace Domain.Driven.Core.Events
{
    /// <summary>
    /// 抽象类message  用来获取我们事件执行过程中的类名
    /// 然后并添加聚合根
    /// </summary>
    public abstract class Message:IRequest
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public string  MessageType { get;protected set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid  AggregateId { get;protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string User { get; set; }
    }
}