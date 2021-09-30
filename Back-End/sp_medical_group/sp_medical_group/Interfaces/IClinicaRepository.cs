using sp_medical_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Interfaces
{
    interface IClinicaRepository
    {

        /// <summary>
        /// Lista todos as Clinicas
        /// </summary>
        /// <returns>Uma lista de Clinicas</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Busca uma Cilica através do seu id
        /// </summary>
        /// <param name="idClinica">ID da Cilica que será buscada</param>
        /// <returns>Uma Cilica encontrado</returns>
        Clinica BuscarPorId(int idClinica);

        /// <summary>
        /// Cadastra um nova Cilica
        /// </summary>
        /// <param name="novaClinica">Objeto novaCilica com os dados que serão cadastrados</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Atualiza uma Cilica existente
        /// </summary>
        /// <param name="idClinica">ID da Cilica que será atualizado</param>
        /// <param name="clinicaAtualizada">Objeto clinicaAtualizada com as novas informações</param>
        void Atualizar(byte idClinica, Clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma Clinica existente
        /// </summary>
        /// <param name="idClinica">ID da Clinica que será deletada</param>
        void Deletar(int idClinica);
    }
}
