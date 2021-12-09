using sp_medical_group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Interfaces
{
    interface IConsultasRepository
    {
        /// <summary>
        /// Altera o status de uma Consulta
        /// </summary>
        /// <param name="idConsulta">ID da Consulta que terá a situação alterada</param>
        /// <param name="Status">Parâmetro que atualiza a situação da presença para 1 - Realizada, 2 - Cancelada ou 3 - Agendada</param>
        void AtualizarSituacao(int idConsulta, string Status);

        /// <summary>
        /// adiciona ou altera uma dscrição de uma determinada consulta
        /// </summary>
        /// <param name="idConsulta">ID da Consulta que terá a dscrição alterada</param>
        /// <param name="descrição">parâmetro que atualiza a descrição de uma consulta</param>
        void AdicionarDescricao(int idConsulta, Consulta descrição);

        

        /// <summary>
        /// Agenda uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta com os dados que serão cadastrados</param>
        void Agendar(Consulta novaConsulta);

        /// <summary>
        /// Deleta uma consulta existente
        /// </summary>
        /// <param name="idConsulta">ID da consulta que será deletada</param>
        void Deletar(int idConsulta);

        /// <summary>
        /// Busca uma consulta através do seu id
        /// </summary>
        /// <param name="idConsulta">ID da consulta que será buscado</param>
        /// <returns>Uma consulta encontrada</returns>
        Consulta BuscarPorId(int idConsulta);
    }
}
