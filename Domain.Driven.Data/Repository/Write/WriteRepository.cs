using System;
using System.Threading.Tasks;
using Domain.Driven.Data.Context;
using Domain.Driven.Domain.Interfaces;
using Domain.Driven.Domain.Interfaces.WriteRepository;
using Microsoft.EntityFrameworkCore;

namespace Domain.Driven.Data.Repository.Write
{
    /// <summary>
    /// 写库仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class WriteRepository<TEntity>:IWriteRepository<TEntity> where TEntity:class 
    {
        protected readonly StudyContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public WriteRepository(StudyContext context)
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
        /// <see cref="IWriteRepository{TEntity}.Add(TEntity)"/>
        /// </summary>
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
            //SaveChanges();
        }
        /// <summary>
        /// <see cref="IWriteRepository{TEntity}.AddAsync(TEntity)"/>
        /// </summary>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var data = (await DbSet.AddAsync(entity))?.Entity;
            //SaveChanges();
            return data;
        }
        /// <summary>
        /// <see cref="IWriteRepository{TEntity}.Update(TEntity)"/>
        /// </summary>
        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
            //SaveChanges();
        }
        /// <summary>
        /// <see cref="IWriteRepository{TEntity}.Remove(Guid)"/>
        /// </summary>
        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            //SaveChanges();
        }
        /// <summary>
        /// <see cref="IWriteRepository{TEntity}.SaveChanges"/>
        /// </summary>
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        /// <summary>
        /// <see cref="IWriteRepository{TEntity}.SaveChangesAsync"/>
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }
    }
}