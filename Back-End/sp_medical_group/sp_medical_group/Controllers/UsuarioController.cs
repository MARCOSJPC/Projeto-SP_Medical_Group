using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using sp_medical_group.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sp_medical_group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuariosRepository { get; set; }

        public UsuarioController()
        {
            _usuariosRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Listar Todas as consultas de um determinado usuario
        /// </summary>
        /// <returns>uma lista de consultas</returns>
        [HttpGet("consultas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                int idTipoUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
                return Ok(_usuariosRepository.ListarMinhas(idTipoUsuario,idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar o Prontuario se o usuário não estiver logado!",
                    error
                });
            }
        }


        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Usuarios com um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuariosRepository.Listar());
        }

        /// <summary>
        /// Busca um Usuario através do seu id
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será buscado</param>
        /// <returns>Um Usuario e um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            return Ok(_usuariosRepository.BuscarPorId(idUsuario));
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com os dados que serão cadastrados</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuariosRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com os novos dados</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            _usuariosRepository.Atualizar(idUsuario, usuarioAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um Usuario
        /// </summary>
        /// <param name="idUsuario">id do Usuario que será deletado</param>
        /// <returns>um staus code 204 - No content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuariosRepository.Deletar(idUsuario);

            return StatusCode(204);
        }

    }
}
