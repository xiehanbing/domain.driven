using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Driven.Core.Events;
using Domain.Driven.Data.Context;
using Domain.Driven.Domain.Interfaces.EventSourcing;

namespace Domain.Driven.Data.Repository.EventSourcing
{
    /// <summary>
    /// 事件存储仓储数据库实现类
    /// </summary>
    public class EventStoreSqlRepository:IEventStoreRepository
    {
        /// <summary>
        /// 注入事件存储数据库上下文
        /// </summary>
        private readonly EventStoreSqlContext _context;

        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        /// <summary>
        /// 将命令事件持久化
        /// </summary>
        /// <param name="theEvent"></param>
        public void Stord(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }
        /// <summary>
        /// 根据聚合id 获取全部的事件
        /// 这个聚合是指领域模型中的聚合根模型
        /// </summary>
        /// <param name="aggregateId">聚合根id 比如订单模型id</param>
        /// <returns></returns>
        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select  e).ToList();
        }
    }
}