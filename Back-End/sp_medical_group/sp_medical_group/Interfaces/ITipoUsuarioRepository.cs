using sp_medical_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Tipos de Usuarios
        /// </summary>
        /// <returns>Uma lista de Tipos de Usuarioss</returns>
        List<TipoUsuario> Listar();
    }
}
