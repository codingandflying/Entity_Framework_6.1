using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EFDataAccessLayer.BaseTypes
{
    /// <summary>
    ///     Implements the generic <see cref="IRepository" /> interface.
    /// </summary>
    /// <typeparam name="T">A class derived from <see cref="EntityBase" class. /></typeparam>
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        /// <summary>
        ///     Underlying dbcontext
        /// </summary>
        protected DbContext _DbContext;

        /// <summary>
        ///     Underlying DbSet.
        /// </summary>
        protected DbSet<T> _DbSet;

        /// <summary>
        ///     Injects the DbContext holding DbSet.
        /// </summary>
        /// <param name="dataContext"></param>
        public Repository(DbContext dataContext)
        {
            _DbContext = dataContext;
            _DbSet = _DbContext.Set<T>();
        }

        #region IRepository<T> Members

        /// <summary>
        ///     Inserts a single entity into the DbSet
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            _DbSet.Add(entity);
        }

        /// <summary>
        ///     Returns an entity based on primary key.
        /// </summary>
        /// <param name="id">Primary Key.</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return _DbSet.Find(id);
        }

        /// <summary>
        ///     Returns an IEnumerable based on the query, order clause and the properties included
        /// </summary>
        /// <param name="query">Link query for filtering.</param>
        /// <param name="orderBy">Link query for sorting.</param>
        /// <param name="includeProperties">Navigation properties seperated by comma for eager loading.</param>
        /// <returns>IEnumerable containing the resulting entity set.</returns>
        public IEnumerable<T> GetByQuery(Expression<Func<T, bool>> query = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> queryResult = _DbSet;

            //If there is a query, execute it against the dbset
            if (query != null)
            {
                queryResult = queryResult.Where(query);
            }

            //get the include requests for the navigation properties and add them to the query result
            foreach (string property in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                queryResult = queryResult.Include(property);
            }

            //if a sort request is made, order the query accordingly.
            if (orderBy != null)
            {
                return orderBy(queryResult).ToList();
            }
                //if not, return the results as is
            return queryResult.ToList();
        }

        /// <summary>
        ///     Returns the first matching entity based on the query.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetFirst(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.First(predicate);
        }

        /// <summary>
        ///     Updates an entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _DbSet.Attach(entity);
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        ///     Updates an entity by primary key.
        /// </summary>
        /// <param name="id">Primary Key.</param>
        public void UpdateById(int id)
        {
            T entity = _DbSet.Find(id);
            _DbSet.Attach(entity);
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        ///     Deletes an entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            if (_DbContext.Entry(entity).State == EntityState.Detached)
                _DbSet.Attach(entity);

            _DbSet.Remove(entity);
        }

        /// <summary>
        ///     Deletes an entity by primary key.
        /// </summary>
        /// <param name="id">Primary Key.</param>
        public void DeleteByID(int id)
        {
            T entity = _DbSet.Find(id);
            _DbSet.Remove(entity);
        }

        #endregion

        //_________________________________________________________________________________________

        public long Count(Expression<Func<T, bool>> query = null)
        {
            if (query != null)
            {
                return _DbSet.LongCount(query);
            }
            return _DbSet.LongCount();
        }
    }
}