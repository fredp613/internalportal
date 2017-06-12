using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InternalPortal.Models.Portal.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InternalPortal.Models.Portal.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private string _language { get; set; }

        public Repository(DbContext context, string language)
        {
            Context = context;
            _language = language;
        }
        public TEntity Get(Guid id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            TrySetProperty(entity, "Lang", _language);
           
            return entity;
        }
        public async Task<TEntity> GetAsync(Guid id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                TrySetPropertyAsync(entity, "Lang", _language);                
            }
            return entity;     
           
        }


        public IEnumerable<TEntity> GetAll()
        {
            var entities = Context.Set<TEntity>().ToList();
            foreach (var e in entities)
            {
                TrySetProperty(e, "Lang", _language);
            }
            return entities;
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Context.Set<TEntity>().Where(predicate);
            foreach (var e in entities)
            {
                TrySetProperty(e, "Lang", _language);
            }
            return entities;
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        private void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }


        private void TrySetPropertyAsync(TEntity obj, string v, string value)
        {
            var prop = obj.GetType().GetProperty(v, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                 prop.SetValue(obj, value, null);
        }


    }

}
