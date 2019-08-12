using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Driven.Data.Context;
using Domain.Driven.Domain.Interfaces.ReadRepository;
using Microsoft.EntityFrameworkCore;

namespace Domain.Driven.Data.Repository.Read
{
    /// <summary>
    /// 只读仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ReadRepository<TEntity>:IReadRepository<TEntity> where TEntity : class
    {
        protected readonly StudyContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public ReadRepository(StudyContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// <see cref="IReadRepository{TEntity}.GetById(Guid)"/>
        /// </summary>
        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }
        /// <summary>
        /// <see cref="IReadRepository{TEntity}.GetByIdAsync(Guid)"/>
        /// </summary>
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        /// <summary>
        /// <see cref="IReadRepository{TEntity}.GetAll"/>
        /// </summary>
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
        /// <summary>
        /// <see cref="IReadRepository{TEntity}.GetAllAsync"/>
        /// </summary>
        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}