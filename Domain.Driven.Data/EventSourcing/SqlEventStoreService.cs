using Domain.Driven.Core.Events;
using Domain.Driven.Data.Repository.EventSourcing;
using Domain.Driven.Domain.Interfaces.EventSourcing;
using Newtonsoft.Json;

namespace Domain.Driven.Data.EventSourcing
{
    /// <summary>
    /// 事件存储服务类
    /// </summary>
    public class SqlEventStoreService : IEventStoreService
    {
        /// <summary>
        /// 注入仓储接口
        /// </summary>
        private readonly IEventStoreRepository _repository;

        public SqlEventStoreService(IEventStoreRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 保持事件模型统一方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEvent"></param>
        public void Save<T>(T theEvent) where T : Event
        {
            var serizlizedData = JsonConvert.SerializeObject(theEvent);
            var storedEvent=new StoredEvent(theEvent,serizlizedData,theEvent.User);
            _repository.Stord(storedEvent);
        }
    }
}