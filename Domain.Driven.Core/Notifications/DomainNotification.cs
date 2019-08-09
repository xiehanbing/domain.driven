using Domain.Driven.Core.Events;
using Guid = System.Guid;

namespace Domain.Driven.Core.Notifications
{
    /// <summary>
    /// 领域通知模型，用来获取当前总线中出现的通知信息
    /// 继承自领域事件和 INotification（也就意味着可以拥有中介的发布/订阅模式）
    /// </summary>
    public class DomainNotification:Event
    {
        /// <summary>
        /// 标识
        /// </summary>
        public Guid DomainNotificationId { get; private set; }
        /// <summary>
        ///  键（可以根据这个key，获取当前key下的全部通知信息）
        /// 这个我们在事件源和事件回溯的时候会用到，伏笔
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// 值（与key对应）
        /// </summary>
        public string Value { get; private set; }
        /// <summary>
        /// 版本信息
        /// </summary>
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}