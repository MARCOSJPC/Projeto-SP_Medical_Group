using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using sp_medical_group.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os Medicos
        /// </summary>
        /// <returns>Uma lista de Medicos com um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_medicoRepository.Listar());
        }

        /// <summary>
        /// Busca um Medico através do seu id
        /// </summary>
        /// <param name="idMedico">ID do Medico que será buscado</param>
        /// <returns>Um Medico e um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idMedico}")]
        public IActionResult BuscarPorId(int idMedico)
        {
            return Ok(_medicoRepository.BuscarPorId(idMedico));
        }

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">Objeto com os dados que serão cadastrados</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            _medicoRepository.Cadastrar(novoMedico);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um medico existente
        /// </summary>
        /// <param name="idMedico">ID do medico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto com os novos dados</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idMedico}")]
        public IActionResult Atualizar(int idMedico, Medico medicoAtualizado)
        {
            _medicoRepository.Atualizar(idMedico, medicoAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// deleta um medico através do seu ID
        /// </summary>
        /// <param name="idMedico">Id do médico que será deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idMedico}")]
        public IActionResult Deletar(int idMedico)
        {
            _medicoRepository.Deletar(idMedico);

            return StatusCode(204);
        }
    }
}
