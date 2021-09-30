using sp_medical_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Interfaces
{
    interface IMedicoRepository
    {

        /// <summary>
        /// Lista todos os Medicos
        /// </summary>
        /// <returns>Uma lista de Medicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Busca um Medico através do seu id
        /// </summary>
        /// <param name="idMedico">ID do Medico que será buscado</param>
        /// <returns>Um Medico encontrado</returns>
        Medico BuscarPorId(int idMedico);

        /// <summary>
        /// Cadastra um novo Medico
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico com os dados que serão cadastrados</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Atualiza um Medico existente
        /// </summary>
        /// <param name="idMedico">ID do Medico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto Medic
        /// oAtualizado com as novas informações</param>
        void Atualizar(int idMedico, Medico medicoAtualizado);

        /// <summary>
        /// Deleta um Medico existente
        /// </summary>
        /// <param name="idMedico">ID do Medico que será deletado</param>
        void Deletar(int idMedico);
    }
}
