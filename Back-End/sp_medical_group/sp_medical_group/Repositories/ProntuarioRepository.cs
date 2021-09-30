using Microsoft.EntityFrameworkCore;
using sp_medical_group.Contexts;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        SpMedicalContext ctx = new();

        public void Atualizar(int idProntuario, Prontuario prontuarioAtualizado)
        {
            Prontuario prontuarioBuscado = ctx.Prontuarios.Find(idProntuario);

            if (prontuarioAtualizado.IdUsuario != null)
            {
                prontuarioBuscado.IdUsuario = prontuarioAtualizado.IdUsuario;

                ctx.Prontuarios.Update(prontuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Prontuario BuscarPorId(int idProntuario)
        {
            return ctx.Prontuarios.FirstOrDefault(e => e.IdProntuario == idProntuario);
        }

        public void Cadastrar(Prontuario novoProntuario)
        {
            ctx.Prontuarios.Add(novoProntuario);
            
            ctx.SaveChanges();
        }

        public void Deletar(int idProntuario)
        {
            ctx.Prontuarios.Remove(BuscarPorId(idProntuario));

            ctx.SaveChanges();
        }

        public List<Prontuario> Listar()
        {
            return ctx.Prontuarios.ToList();
        }

    }
}
