using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using sp_medical_group.Repositories;
using System;

namespace sp_medical_group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultasRepository _consultasRepository { get; set; }

        public ConsultasController()
        {
            _consultasRepository = new ConsultasRepository();
        }

        /// <summary>
        /// Atualiza a situação de uma consulta
        /// </summary>
        /// <param name="idConsulta">id da consulta que será atualizada</param>
        /// <param name="status">situação da consulta</param>
        /// <returns>um status code 201 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPatch("{idConsulta}")]
        public IActionResult AtualizarSituacao(int idConsulta, Situacao status)
        {
            try
            {
                _consultasRepository.AtualizarSituacao(idConsulta, status.IdSituacao.ToString());
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// adiciona ou altera a descrição de uma determinada consulta
        /// </summary>
        /// <param name="idConsulta">id da consulta que terá a descrição aterada</param>
        /// <param name="descrição">objeto que receberá a descrição da consulta</param>
        /// <returns>um status code 201 - created</returns>
        [Authorize(Roles = "2")]
        [HttpPatch("descricao/{idConsulta}")]
        public IActionResult AdicionarDescricao(int idConsulta, Consulta descrição)
        {
            _consultasRepository.AdicionarDescricao(idConsulta, descrição);

            return StatusCode(201);
        }

        /// <summary>
        /// Agenda uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta com os dados que serão cadastrados</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Agendar(Consulta novaConsulta)
        {
            _consultasRepository.Agendar(novaConsulta);

            return StatusCode(201);
        }


        /// <summary>
        ///  Deleta uma consulta existente
        /// </summary>
        /// <param name="idConsulta">ID da consulta que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idConsulta}")]
        public IActionResult Deletar(int idConsulta)
        {
            _consultasRepository.Deletar(idConsulta);

            return StatusCode(204);
        }

        /// <summary>
        /// Busca uma consulta através do seu id
        /// </summary>
        /// <param name="idConsulta">ID da consulta que será buscada</param>
        /// <returns>Um estúdio e um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idConsulta}")]
        public IActionResult BuscarPorId(int idConsulta)
        {
            return Ok(_consultasRepository.BuscarPorId(idConsulta));
        }
    }
}
