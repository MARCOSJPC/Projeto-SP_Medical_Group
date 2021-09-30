using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sp_medical_group.Interfaces;
using sp_medical_group.Repositories;

namespace sp_medical_group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Tipos de Usuarios
        /// </summary>
        /// <returns>Uma lista de tipos de usuarios com um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }
    }
}
