using sp_medical_group.Contexts;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace sp_medical_group.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(idUsuario);

           
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;

                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,  
                })
                .FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario

                })
                .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public List<Consulta> ListarMinhas(int idTipoUsuario, int idUsuario)
        {
            if (idTipoUsuario == 2)
            {
                Medico medico = ctx.Medicos.FirstOrDefault(u => u.IdUsuario == idUsuario);

                return ctx.Consultas.Select(c => new Consulta()
                {
                    IdConsulta = c.IdConsulta,
                    IdMedico = c.IdMedico,
                    IdProntuario = c.IdProntuario,
                    IdSituacao = c.IdSituacao,
                    DataConsulta = c.DataConsulta,
                    Descricao = c.Descricao

                })
                    .Where(p => p.IdMedico == medico.IdMedico)
                    .ToList();
            }
            else if (idTipoUsuario == 3)
            {
                Prontuario Paciente = ctx.Prontuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                return ctx.Consultas.Select(c => new Consulta()
                {
                    IdConsulta = c.IdConsulta,
                    IdMedico = c.IdMedico,
                    IdProntuario = c.IdProntuario,
                    IdSituacao = c.IdSituacao,
                    DataConsulta = c.DataConsulta,
                    Descricao = c.Descricao

                })
                    .Where(p => p.IdProntuario == Paciente.IdProntuario)
                    .ToList();
            }
            else { return null; }
        }
    }
}
