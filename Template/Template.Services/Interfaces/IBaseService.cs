﻿using System;
using System.Threading.Tasks;
using Template.Models.Interfaces;

namespace Template.Services.Interfaces
{
    /// <summary>
    ///     Base CRUD service that passes calls to the underlying repository.
    /// </summary>
    /// <typeparam name="TEntity">The entity used for the CRUD actions.</typeparam>
    public interface IBaseService<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        ///     Adds an entity to the underlying data source.
        /// </summary>
        /// <param name="entity">The entity intended to be inserted.</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="entity" /> is null.</exception>
        /// <returns>The tracked entity.</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        ///     Asynchronously adds an entity to the underlying data source.
        /// </summary>
        /// <param name="entity">The entity intended to be inserted.</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="entity" /> is null.</exception>
        /// <returns>The tracked entity wrapped in a task.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        ///     Updates an entity to the new values in the data source.
        /// </summary>
        /// <param name="entity">The entity intended to be updated.</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="entity" /> is null.</exception>
        void Update(TEntity entity);

        /// <summary>
        ///     Finds an entity based on the provided <paramref name="id" />.
        /// </summary>
        /// <param name="id">The primary key of the entity wanted to be searched for.</param>
        /// <exception cref="ArgumentException">When the <paramref name="id" /> is bellow 1</exception>
        /// <returns>An instance of the entity from the data source or null.</returns>
        TEntity Find(long id);

        /// <summary>
        ///     Asynchronously finds an entity based on the provided <paramref name="id" />.
        /// </summary>
        /// <param name="id">The primary key of the entity wanted to be searched for.</param>
        /// <exception cref="ArgumentException">When the <paramref name="id" /> is bellow 1</exception>
        /// <returns>An instance of the entity from the data source or null warped in a task.</returns>
        Task<TEntity> FindAsync(long id);

        /// <summary>
        ///     Deletes an entity from the data source.
        /// </summary>
        /// <param name="entity">The entity intended to be deleted.</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="entity" /> is null.</exception>
        void Delete(TEntity entity);
    }
}