using Microsoft.EntityFrameworkCore;
using MoneyNote.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MoneyNote.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DBContext db;
        private DbSet<T> dbSet;
        public Repository(DBContext db)
        {
            this.db = db;
            dbSet = db.Get<T>();
        }

        public void Delete(T t)
        {
            dbSet.Remove(t);
        }

        public void DeleteMany(IEnumerable<T> ts)
        {
            dbSet.RemoveRange(ts);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return dbSet.Where(where);
            }
            else
            {
                return dbSet;
            }
        }

        public T Insert(T t)
        {
            return dbSet.Add(t).Entity;
        }

        public void InsertMany(IEnumerable<T> ts)
        {
            dbSet.AddRange(ts);
        }

        public T Update(T t)
        {
            return dbSet.Update(t).Entity;
        }

        public void UpdateMany(IEnumerable<T> ts)
        {
            dbSet.UpdateRange(ts);
        }
    }
}
