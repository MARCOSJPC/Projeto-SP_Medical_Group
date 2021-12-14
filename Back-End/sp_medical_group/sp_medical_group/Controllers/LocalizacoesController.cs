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
    public class LocalizacoesController : ControllerBase
    {
        private ILocalizacao _localizacoesRepository { get; set; }

        public LocalizacoesController()
        {
            _localizacoesRepository = new LocalizacaoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_localizacoesRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Localizacao novaLocalizacao)
        {
            try
            {
                _localizacoesRepository.Cadastrar(novaLocalizacao);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
