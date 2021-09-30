using sp_medical_group.Contexts;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Repositories
{
    public class ConsultasRepository : IConsultasRepository
    {
        SpMedicalContext ctx = new();

        public void AdicionarDescricao(int idConsulta, Consulta descrição)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(idConsulta);
            consultaBuscada.Descricao = descrição.Descricao;
            ctx.Consultas.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public void Agendar(Consulta novaConsulta)
        {
            ctx.Consultas.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void AtualizarSituacao(int idConsulta, string Status)
        {

            Consulta consultaBuscada = ctx.Consultas
                .FirstOrDefault(s => s.IdConsulta == idConsulta);

            switch (Status)
            {
                case "1":
                    consultaBuscada.IdSituacao = 1;
                    break;
                case "2":
                    consultaBuscada.IdSituacao = 2;
                    break;
                case "3":
                    consultaBuscada.IdSituacao = 3;
                    break;

                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;
            }
            ctx.Consultas.Update(consultaBuscada);
            ctx.SaveChanges();

        }

        public Consulta BuscarPorId(int idConsulta)
        {
            return ctx.Consultas.FirstOrDefault(e => e.IdConsulta == idConsulta);
        }

        public void Deletar(int idConsulta)
        {
            ctx.Consultas.Remove(BuscarPorId(idConsulta));

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas.ToList();
        }
    }
}
