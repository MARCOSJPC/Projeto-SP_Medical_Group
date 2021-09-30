using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using sp_medical_group.Repositories;
namespace sp_medical_group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todos as clinias
        /// </summary>
        /// <returns>Uma lista de clinicas com um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_clinicaRepository.Listar());
        }

        /// <summary>
        /// Busca uma clinica através do seu id
        /// </summary>
        /// <param name="idClinica">ID da clinica que será buscado</param>
        /// <returns>Uma clinica e um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idClinica}")]
        public IActionResult BuscarPorId(int idClinica)
        {
            return Ok(_clinicaRepository.BuscarPorId(idClinica));
        }

        /// <summary>
        /// Cadastra um nova Clinica
        /// </summary>
        /// <param name="novaClinica">Objeto com os dados que serão cadastrados</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica)
        {
            _clinicaRepository.Cadastrar(novaClinica);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma Clinica existente
        /// </summary>
        /// <param name="idClinica">ID da Clinica que será atualizado</param>
        /// <param name="clinicaAtualizada">Objeto com os novos dados</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idClinica}")]
        public IActionResult Atualizar(byte idClinica, Clinica clinicaAtualizada)
        {
            _clinicaRepository.Atualizar(idClinica, clinicaAtualizada);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma clinica existente
        /// </summary>
        /// <param name="idClinica">id da clinica que será deletada</param>
        /// <returns>um status code 204 - no content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idClinica}")]
        public IActionResult Deletar(int idClinica)
        {
            _clinicaRepository.Deletar(idClinica);

            return StatusCode(204);
        }
    }
}
