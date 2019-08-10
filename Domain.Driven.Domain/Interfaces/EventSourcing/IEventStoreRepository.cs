using System;
using System.Collections.Generic;
using Domain.Driven.Core.Events;

namespace Domain.Driven.Domain.Interfaces.EventSourcing
{
    /// <summary>
    /// 事件存储仓储接口
    /// 继承IDisposable  可手动回收
    /// </summary>
    public interface IEventStoreRepository:IDisposable
    {
        /// <summary>
        /// 存储事件
        /// </summary>
        /// <param name="theEvent"></param>
        void Stord(StoredEvent theEvent);
        /// <summary>
        /// 获取事件
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        IList<StoredEvent> All(Guid aggregateId);
    }
}