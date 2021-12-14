using sp_medical_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Interfaces
{
    interface ILocalizacao
    {
        List<Localizacao> ListarTodos();

        void Cadastrar(Localizacao novaLocalizacao);
    }
}
