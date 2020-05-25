using MoneyNote.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoneyNote.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> where = null);
        T Insert(T t);
        T Update(T t);
        void UpdateMany(IEnumerable<T> ts);
        void Delete(T t);
        void DeleteMany(IEnumerable<T> ts);
        void InsertMany(IEnumerable<T> ts);
    }
}
