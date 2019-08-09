using System;
using MediatR;

namespace Domain.Driven.Core.Events
{
    /// <summary>
    /// 事件模型 抽象基类 继承INotification
    /// 也就是说 拥有中介者模式的 发布/订阅 模式
    /// </summary>
    public abstract class Event:INotification
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime Timestamp { get;private set; }
        /// <summary>
        /// 每一个事件都是有状态的
        /// </summary>
        protected Event()
        {
            Timestamp=DateTime.Now;
        }
    }
}