﻿using System.Threading.Tasks;
using Domain.Driven.Core.Bus;
using Domain.Driven.Core.Commands;
using Domain.Driven.Core.Events;
using MediatR;

namespace Domain.Driven.Infra.Bus
{
    /// <summary>
    /// 一个密封类 实现我们的中介记忆总线
    /// </summary>
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStoreService _eventStoreService;
        public InMemoryBus(IMediator mediator,
            IEventStoreService storeService)
        {
            _mediator = mediator;
            _eventStoreService = storeService;
        }
        /// <summary>
        /// 实现我们在IMediatorHandler 定义的接口
        /// 没有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);//这里注意下command 对象
        }
        /// <summary>
        /// 引发事件的实现方法 /// </summary>
        /// <typeparam name="T">泛型 继承 Event：INotification</typeparam>
        /// <param name="event">事件模型，比如StudentRegisteredEvent</param>
        /// <returns></returns>
        public Task RaiseEvent<T>(T @event) where T : Event
        {
            //除了领域通知以外 的事件都保存下来
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                _eventStoreService?.Save(@event); //MediatR中介者模式中的第二种方法，发布 / 订阅模式
            }
            return _mediator.Publish(@event);
        }
    }
}