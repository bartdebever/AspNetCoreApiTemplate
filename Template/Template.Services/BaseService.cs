﻿using System.Threading.Tasks;
using Template.Models.Interfaces;
using Template.Repositories.Interfaces;
using Template.Services.Interfaces;

namespace Template.Services
{
    /// <inheritdoc />
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        ///     The repository injected into this object.
        /// </summary>
        protected readonly IBaseRepository<TEntity> Repository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseService{TEntity}" /> class.
        /// </summary>
        /// <param name="repository"></param>
        public BaseService(IBaseRepository<TEntity> repository)
        {
            Repository = repository;
        }

        /// <inheritdoc />
        public TEntity Add(TEntity entity)
        {
            return Repository.Add(entity);
        }

        /// <inheritdoc />
        public Task<TEntity> AddAsync(TEntity entity)
        {
            return Repository.AddAsync(entity);
        }

        /// <inheritdoc />
        public void Update(TEntity entity)
        {
            Repository.Update(entity);
        }

        /// <inheritdoc />
        public TEntity Find(long id)
        {
            return Repository.Find(id);
        }

        /// <inheritdoc />
        public Task<TEntity> FindAsync(long id)
        {
            return Repository.FindAsync(id);
        }

        /// <inheritdoc />
        public void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }
    }
}