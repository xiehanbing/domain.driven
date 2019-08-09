using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Driven.Domain.Events;
using MediatR;

namespace Domain.Driven.Domain.EventHandlers.StudentEventHandlers
{
    /// <summary>
    /// 学生事件处理程序
    /// </summary>
    public class StudentEventHandler:INotificationHandler<StudentRegisteredEvent>,
        INotificationHandler<StudentRemoveEvent>,INotificationHandler<StudentUpdateEvent>
    {
        /// <summary>
        /// 学习被注册成功后的事假处理方法
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(StudentRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //todo something 恭喜你 注册成功 欢迎加入我们
            Console.WriteLine("恭喜你 注册成功 欢迎加入我们");
            return Task.CompletedTask;
        }
        /// <summary>
        /// 学生被删除成功后的事件处理方法
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(StudentRemoveEvent notification, CancellationToken cancellationToken)
        {
            //todo something 您已经删除成功啦，记得以后常来看看。
            Console.WriteLine("您已经删除成功啦，记得以后常来看看。");
            return Task.CompletedTask;
        }
        /// <summary>
        /// 学生被修改成功后的事件处理方法
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(StudentUpdateEvent notification, CancellationToken cancellationToken)
        {
            //todo something 恭喜你 更新成功 请牢记修改后的信息
            Console.WriteLine("恭喜你 更新成功 请牢记修改后的信息");
            return Task.CompletedTask;
        }
    }
}