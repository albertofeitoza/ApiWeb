using System.Collections.Generic;

namespace ApiWeb.Repository
{
    public interface IRepository<TEntity> where  TEntity : class, new()
    {
        void Adicionar(TEntity item);
        List<TEntity> BuscarTodos();
        TEntity BuscaPorId(int id);
        void Remover(TEntity item);
        void Editar(TEntity item);
        void Commit();
        void Dispose();
    }
}
