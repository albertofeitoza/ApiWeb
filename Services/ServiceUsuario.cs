
using ApiWeb.Model;
using ApiWeb.Repository;
using ApiWeb.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace ApiWeb.Services
{
    public class ServiceUsuario : IInterfaceDefault<Usuario>
    {
        private readonly IRepository<Usuario> serviceUsuario;
 
        public ServiceUsuario(IRepository<Usuario> serviceUsuario)
        {
            this.serviceUsuario = serviceUsuario;
        }


        public void Adicionar(Usuario item)
        {
            serviceUsuario.Adicionar(item);
        }

        public Usuario Atualizar(int id, Usuario entity)
        {
            var usuario = serviceUsuario.BuscaPorId(entity.Id);

            if (usuario != null)
            {
                usuario.Nome = entity.Nome;
                usuario.Endereco = entity.Endereco;
                usuario.Telefone = entity.Telefone;
                serviceUsuario.Editar(usuario);
            }
            return usuario;
        }

        public Usuario BuscaPorId(int id)
        {
            return serviceUsuario.BuscaPorId(id); 
        }

        public List<Usuario> BuscarTodos()
        {
            return serviceUsuario.BuscarTodos().ToList();
        }

        public void Excluir(int id)
        {
            var usuario = serviceUsuario.BuscaPorId(id);

            if (usuario != null)
                serviceUsuario.Remover(usuario);
        }
    }
}
