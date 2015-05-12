using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EFDataAccessLayer.BaseTypes
{
    /// <summary>
    /// A generic repository pattern that wraps the IDbSet interface.
    /// </summary>
    /// <typeparam name="T"> Is a class derived from <see cref="EntityBase"/> class.</typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Inserts a single entity into the DbSet
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// Returns an entity based on primary key.
        /// </summary>
        /// <param name="id">Primary Key.</param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Returns an IEnumerable based on the query, order clause and the properties included
        /// </summary>
        /// <param name="query">Link query for filtering.</param>
        /// <param name="orderBy">Link query for sorting.</param>
        /// <param name="includeProperties">Navigation properties seperated by comma for eager loading.</param>
        /// <returns>IEnumerable containing the resulting entity set.</returns>
        IEnumerable<T> GetByQuery(Expression<Func<T, bool>> query = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "");

        /// <summary>
        /// Returns the first matching entity based on the query.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T GetFirst(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Updates an entity by primary key.
        /// </summary>
        /// <param name="id">Primary Key.</param>
        void UpdateById(int id);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Deletes an entity by primary key.
        /// </summary>
        /// <param name="id">Primary Key.</param>
        void DeleteByID(int id);

        /// <summary>
        /// Count the entities without load data
        /// </summary>
        /// <param name="query">Link query for filtering.</param>
        /// <returns>the count (type is long)</returns>
        long Count(Expression<Func<T, bool>> query = null);
    }
}
