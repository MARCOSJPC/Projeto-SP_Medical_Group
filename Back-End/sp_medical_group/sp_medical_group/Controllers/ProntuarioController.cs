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
using System.Threading.Tasks;

namespace sp_medical_group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontarioRepository { get; set; }

        public ProntuarioController()
        {
            _prontarioRepository = new ProntuarioRepository();
        }

         
        /// <summary>
        /// Lista todos os Prontuarios
        /// </summary>
        /// <returns>Uma lista de estúdios com um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_prontarioRepository.Listar());
        }

        /// <summary>
        /// Busca um Prontuario através do seu id
        /// </summary>
        /// <param name="idProntuario">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio e um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idProntuario}")]
        public IActionResult BuscarPorId(int idProntuario)
        {
            return Ok(_prontarioRepository.BuscarPorId(idProntuario));
        }

        /// <summary>
        /// Cadastra um novo Prontuario
        /// </summary>
        /// <param name="novoProntuario">Objeto com os dados que serão cadastrados</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Prontuario novoProntuario)
        {
            _prontarioRepository.Cadastrar(novoProntuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pronruário existente
        /// </summary>
        /// <param name="idProntuario">ID do estúdio que será atualizado</param>
        /// <param name="prontarioAtualizado">Objeto com os novos dados</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idProntuario}")]
        public IActionResult Atualizar(int idProntuario, Prontuario prontarioAtualizado)
        {
            _prontarioRepository.Atualizar(idProntuario, prontarioAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um prontuário existente
        /// </summary>
        /// <param name="idProntuario">Id do prontuário que será deletado</param>
        /// <returns>um status code 204 - no content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idProntuario}")]
        public IActionResult Deletar(int idProntuario)
        {
            _prontarioRepository.Deletar(idProntuario);

            return StatusCode(204);
        }

    }
}
