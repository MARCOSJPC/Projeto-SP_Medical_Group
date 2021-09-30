using sp_medical_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Interfaces
{
    interface IProntuarioRepository
    {
       
          /// <summary>
        /// Lista todos os Prontuarios
        /// </summary>
        /// <returns>Uma lista de Prontuarios</returns>
        List<Prontuario> Listar();

        /// <summary>
        /// Busca um Prontuario através do seu id
        /// </summary>
        /// <param name="idProntuario">ID do Prontuario que será buscado</param>
        /// <returns>Um Prontuario encontrado</returns>
        Prontuario BuscarPorId(int idProntuario);

        /// <summary>
        /// Cadastra um novo Prontuario
        /// </summary>
        /// <param name="novoProntuario">Objeto novoProntuario com os dados que serão cadastrados</param>
        void Cadastrar(Prontuario novoProntuario);

        /// <summary>
        /// Atualiza um Prontuario existente
        /// </summary>
        /// <param name="idProntuario">ID do Prontuario que será atualizado</param>
        /// <param name="prontuarioAtualizado">Objeto prontuarioAtualizado com as novas informações</param>
        void Atualizar(int idProntuario, Prontuario prontuarioAtualizado);

        /// <summary>
        /// Deleta um Prontuario existente
        /// </summary>
        /// <param name="idProntuario">ID do Prontuario que será deletado</param>
        void Deletar(int idProntuario);
    }
}

