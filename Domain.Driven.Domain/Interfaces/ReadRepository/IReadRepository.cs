using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Driven.Domain.Interfaces.ReadRepository
{
    public interface IReadRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// 根据id 获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(Guid id);
        /// <summary>
        /// 根据id 获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        Task<IList<TEntity>> GetAllAsync();
    }
}