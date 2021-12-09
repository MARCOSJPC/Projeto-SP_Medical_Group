using Microsoft.EntityFrameworkCore;
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


                return ctx.Consultas.Where(c => c.IdMedicoNavigation.IdUsuario == idUsuario)
                    .Include(c => c.IdMedicoNavigation.IdClinicaNavigation)
                    .Include(c => c.IdMedicoNavigation.IdUsuarioNavigation)
                    .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)
                    .Include(c => c.IdSituacaoNavigation)
                    .Select(c => new Consulta()
                    {
                        IdSituacao = c.IdSituacao,
                        DataConsulta = c.DataConsulta,
                        Descricao = c.Descricao,

                        IdMedicoNavigation = new Medico()
                        {
                            IdMedico = c.IdMedicoNavigation.IdMedico,
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                            IdClinica = c.IdMedicoNavigation.IdClinica,


                            IdEspecialidadeNavigation = new Especialidade()
                            {
                                IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                                TipoEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.TipoEspecialidade
                            }

                        },

                        IdProntuarioNavigation = new Prontuario()
                        {
                            IdProntuario = c.IdProntuarioNavigation.IdProntuario,
                            DataNasc = c.IdProntuarioNavigation.DataNasc,
                            Rg = c.IdProntuarioNavigation.Rg,
                            Cpf = c.IdProntuarioNavigation.Cpf,
                            Endereco = c.IdProntuarioNavigation.Endereco,


                            IdUsuarioNavigation = new Usuario()
                            {
                                IdUsuario = c.IdProntuarioNavigation.IdUsuarioNavigation.IdUsuario,
                                NomeUsuario = c.IdProntuarioNavigation.IdUsuarioNavigation.NomeUsuario,
                                Email = c.IdProntuarioNavigation.IdUsuarioNavigation.Email,
                                IdTipoUsuario = c.IdProntuarioNavigation.IdUsuarioNavigation.IdTipoUsuario
                            },
                        },

                        IdSituacaoNavigation = new Situacao()
                        {
                            IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                            Descricao = c.IdSituacaoNavigation.Descricao
                        }

                    }).ToList();
            }
            else if (idTipoUsuario == 3)
            {


                return ctx.Consultas.Where(p => p.IdProntuarioNavigation.IdUsuario == idUsuario)
                    .Include(c => c.IdProntuarioNavigation.IdUsuarioNavigation)
                    .Include(c => c.IdMedicoNavigation.IdClinicaNavigation)
                    .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)
                    .Include(c => c.IdSituacaoNavigation)


                    .Select(c => new Consulta()
                    {
                        IdSituacao = c.IdSituacao,
                        DataConsulta = c.DataConsulta,
                        Descricao = c.Descricao,

                        IdMedicoNavigation = new Medico()
                        {
                            IdMedico = c.IdMedicoNavigation.IdMedico,
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                            IdClinica = c.IdMedicoNavigation.IdClinica,


                            IdEspecialidadeNavigation = new Especialidade()
                            {
                                IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                                TipoEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.TipoEspecialidade
                            }

                        },

                        IdProntuarioNavigation = new Prontuario()
                        {
                            IdProntuario = c.IdProntuarioNavigation.IdProntuario,
                            DataNasc = c.IdProntuarioNavigation.DataNasc,
                            Rg = c.IdProntuarioNavigation.Rg,
                            Cpf = c.IdProntuarioNavigation.Cpf,
                            Endereco = c.IdProntuarioNavigation.Endereco,


                            IdUsuarioNavigation = new Usuario()
                            {
                                IdUsuario = c.IdProntuarioNavigation.IdUsuarioNavigation.IdUsuario,
                                NomeUsuario = c.IdProntuarioNavigation.IdUsuarioNavigation.NomeUsuario,
                                Email = c.IdProntuarioNavigation.IdUsuarioNavigation.Email,
                                IdTipoUsuario = c.IdProntuarioNavigation.IdUsuarioNavigation.IdTipoUsuario
                            },
                        },

                        IdSituacaoNavigation = new Situacao()
                        {
                            IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                            Descricao = c.IdSituacaoNavigation.Descricao
                        }
                    })

                    .ToList();
            }
            else if ( idTipoUsuario == 1)
            {
                return ctx.Consultas.
                Include(c => c.IdProntuarioNavigation.IdUsuarioNavigation).
                Include(c => c.IdMedicoNavigation.IdUsuarioNavigation).
                Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation).
                Include(c => c.IdMedicoNavigation.IdClinicaNavigation).
                Include(c => c.IdSituacaoNavigation).
                ToList();
            }
            else { return null; }
        }
    }
}
