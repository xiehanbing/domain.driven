using System.Threading.Tasks;
using Domain.Driven.Core.Bus;
using Domain.Driven.Core.Commands;
using MediatR;

namespace Domain.Driven.Infra.Bus
{
    /// <summary>
    /// 一个密封类 实现我们的中介记忆总线
    /// </summary>
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}