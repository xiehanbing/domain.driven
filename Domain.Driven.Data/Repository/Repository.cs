using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Driven.Data.Context;
using Domain.Driven.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Domain.Driven.Data.Repository
{
    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly StudyContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(StudyContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.Add(TEntity)"/>
        /// </summary>
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
            //SaveChanges();
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.AddAsync(TEntity)"/>
        /// </summary>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var data=(await DbSet.AddAsync(entity))?.Entity;
            //SaveChanges();
            return data;
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.Update(TEntity)"/>
        /// </summary>
        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
            //SaveChanges();
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.Remove(Guid)"/>
        /// </summary>
        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            //SaveChanges();
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.SaveChanges"/>
        /// </summary>
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.SaveChangesAsync"/>
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }


        /// <summary>
        /// <see cref="IRepository{TEntity}.GetById(Guid)"/>
        /// </summary>
        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.GetByIdAsync(Guid)"/>
        /// </summary>
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.GetAll"/>
        /// </summary>
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
        /// <summary>
        /// <see cref="IRepository{TEntity}.GetAllAsync"/>
        /// </summary>
        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}