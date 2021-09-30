using sp_medical_group.Contexts;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedicalContext ctx = new();
        public void Atualizar(int idMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(idMedico);

            if (medicoAtualizado.IdUsuario != null)
            {
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;

                ctx.Medicos.Update(medicoBuscado);

                ctx.SaveChanges();
            }
        }

        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos.FirstOrDefault(e => e.IdMedico == idMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            ctx.Medicos.Remove(BuscarPorId(idMedico));

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }
    }
}
