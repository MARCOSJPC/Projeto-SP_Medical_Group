using sp_medical_group.Contexts;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Repositories
{
    public class TipoUsuarioRepository :ITipoUsuarioRepository
    {
        SpMedicalContext ctx = new();

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
