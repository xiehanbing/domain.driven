using System;
using DomainCoreEvent = Domain.Driven.Core.Events;
namespace Domain.Driven.Domain.Events
{
    /// <summary>
    /// 学生移除事件模型
    /// </summary>
    public class StudentRemoveEvent : DomainCoreEvent.Event
    {
        public StudentRemoveEvent(Guid id,string user="")
        {
            Id = id;
            User = user;
            AggregateId = id;
        }
        /// <summary>
        /// 标示id
        /// </summary>
        public Guid Id { get; set; }
    }
}