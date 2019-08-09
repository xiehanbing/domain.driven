using System;

namespace Domain.Driven.Domain.Interfaces
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork<TContext> :IDisposable where TContext : class
    {
        /// <summary>
        /// 是否提交成功
        /// </summary>
        /// <returns></returns>
        bool Commit();
    }

    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 是否提交成功
        /// </summary>
        /// <returns></returns>
        bool Commit();
    }
}