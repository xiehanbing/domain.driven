using System;

namespace Domain.Driven.Core.Events
{
    /// <summary>
    /// 存储事件模型StoredEvent
    /// </summary>
    public class StoredEvent:Event
    {
        /// <summary>
        /// 构造方法实例化
        /// </summary>
        /// <param name="theEvent"></param>
        /// <param name="data"></param>
        /// <param name="user"></param>
        public StoredEvent(Event theEvent,
            string data,string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        protected StoredEvent() { }
        /// <summary>
        /// 事件存储id
        /// </summary>
        public Guid Id { get;private set; }
        /// <summary>
        /// 存储的数据
        /// </summary>
        public string Data { get; private set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public string User { get; private set; }
    }
}