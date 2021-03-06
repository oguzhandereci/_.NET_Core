﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Kuzey.DAL;
using Kuzey.MODELS.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kuzey.BLL.Repository.Abstracts
{
    public abstract class RepoBase<T, TId> : IRepository<T, TId> where T : BaseEntity<TId>
    {
        private readonly MyContext DbContext;
        private readonly DbSet<T> DbObject;

        internal RepoBase(MyContext dbContext)
        {
            DbContext = dbContext;
            DbObject = DbContext.Set<T>();
        }
        public List<T> GetAll()
        {
            return DbObject.ToList();
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
            return DbObject.Where(predicate).ToList();
        }

        public List<T> GetAll(params string[] includes)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(Func<T, bool> predicate, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public T GetById(TId id)
        {
            return DbObject.Find(id);
        }

        public void Insert(T entity)
        {
            DbObject.Add(entity);
            DbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            DbObject.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            DbObject.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Queryable()
        {
            return DbObject.AsQueryable();
        }

        public IQueryable<T> Queryable(Func<T, bool> predicate)
        {
            return DbObject.Where(predicate).AsQueryable();
        }

        
    }
}
