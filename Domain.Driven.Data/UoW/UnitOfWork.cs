using Domain.Driven.Data.Context;
using Domain.Driven.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Driven.Data.UoW
{
    /// <summary>
    /// 工作单元类
    /// </summary>
    public class UnitOfWork<TContext>:IUnitOfWork<TContext> where TContext:DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 手动收回
        /// </summary>
        public void Dispose()
        {
           _context.Dispose();
        }
        /// <summary>
        /// 上下文提交
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            return _context.SaveChanges()>0;
        }
    }
    /// <summary>
    /// 工作单元类
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudyContext _context;

        public UnitOfWork(StudyContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 手动收回
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
        /// <summary>
        /// 上下文提交
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}