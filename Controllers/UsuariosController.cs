using System;
using System.Collections.Generic;
using ApiWeb.Model;
using ApiWeb.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackPalm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IInterfaceDefault<Usuario> serviceUsuario;
        
        public UsuarioController(IInterfaceDefault<Usuario> _serviceUsuario)
        {
            serviceUsuario = _serviceUsuario;
        }
        
        
        [HttpGet()]
        public List<Usuario> BuscaTodos()
        {
            return serviceUsuario.BuscarTodos();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult BuscaPorId(int id)
        {
            var usuario = serviceUsuario.BuscaPorId(id);
            
            if (usuario == null)
                return NotFound();

            return new ObjectResult(usuario);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Usuario usuario)
        {

            if (usuario == null)
                return BadRequest();

            serviceUsuario.Adicionar(usuario);

            return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
        }

        [HttpPut]
        public IActionResult Atualizar(int id, [FromBody] Usuario usuario)
        {
            id = usuario.Id;

            if (usuario == null || usuario.Id != id)
                return BadRequest();

            var _usuario = serviceUsuario.BuscaPorId(id);

            if (_usuario == null)
                return NotFound();
            
            return new ObjectResult(serviceUsuario.Atualizar(id, usuario));

        }

        [HttpDelete("{id}")]

        public IActionResult Excluir(int id)
        {
            try
            {
                var usuario = serviceUsuario.BuscaPorId(id);
                if (usuario == null)
                    return NotFound();

                serviceUsuario.Excluir(id);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
    }
}
