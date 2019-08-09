﻿using System.Threading.Tasks;
using Domain.Driven.Core.Commands;

namespace Domain.Driven.Core.Bus
{
    /// <summary>
    /// 中介处理程序接口
    /// 可以定义多个处理程序
    /// 是异步的
    /// </summary>
    public interface IMediatorHandler
    {
        /// <summary>
        /// 发布命令 将我们的命令模型发布到中介者模块
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="command">命令模型 比如 registerstudentcommand</param>
        /// <returns></returns>
        Task SendCommand<T>(T command) where T : Command;
    }
}