using ApiWeb.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiWeb.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class, new()
    {

        protected readonly DbContextApi  serviceContext;

        public Repository(DbContextApi _serviceContext)
        {
            serviceContext = _serviceContext;
        }
        
        public virtual void Adicionar(TEntity item)
        {
            serviceContext.Set<TEntity>().Add(item);
            Commit();
        }

        public virtual TEntity BuscaPorId(int id)
        {
            return serviceContext.Set<TEntity>().Find(id);
        }

        public List<TEntity> BuscarTodos()
        {
            return serviceContext.Set<TEntity>().ToList();
        }
        public virtual void Editar(TEntity item)
        {
            serviceContext.Entry(item).State = EntityState.Modified;
            Commit();
        }

        public virtual void Remover(TEntity item)
        {
            serviceContext.Set<TEntity>().Remove(item);
            Commit();
        }

        public virtual void Commit()
        {
            serviceContext.SaveChanges();
        }

        public virtual void Dispose()
        {
            serviceContext.Dispose();
        }
    }
}
