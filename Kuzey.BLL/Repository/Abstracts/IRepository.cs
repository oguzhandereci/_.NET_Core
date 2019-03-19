using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kuzey.MODELS.Entities;

namespace Kuzey.BLL.Repository.Abstracts
{
    public interface IRepository<T,TId> where T : BaseEntity<TId>
    {
        List<T> GetAll();
        List<T> GetAll(Func<T,bool> predicate);
        List<T> GetAll(params string[] includes);
        List<T> GetAll(Func<T, bool> predicate,params string[] includes);
        T GetById(TId id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        IQueryable<T> Queryable();
        IQueryable<T> Queryable(Func<T, bool> predicate);
    }
}
