using ApiWeb.Model;
using System.Collections.Generic;

namespace ApiWeb.Services.Interface
{
    public interface IInterfaceDefault<T> where T : class, new()
    {
        void Adicionar(T item);
        List<T> BuscarTodos();
        T BuscaPorId(int id);
        void Excluir(int id);
        T Atualizar(int id, T entity);
    }
}
