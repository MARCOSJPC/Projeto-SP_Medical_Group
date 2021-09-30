using sp_medical_group.Contexts;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedicalContext ctx = new();
        public void Atualizar(byte idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(idClinica);

            clinicaBuscada.NomeClinica = clinicaAtualizada.NomeClinica;
            clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            clinicaBuscada.Endereco = clinicaAtualizada.Endereco;

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
            
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(e => e.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            ctx.Clinicas.Remove(BuscarPorId(idClinica));

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
