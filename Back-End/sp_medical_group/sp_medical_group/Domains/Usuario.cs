using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace sp_medical_group.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Prontuarios = new HashSet<Prontuario>();
        }

        public int IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        
        [Required(ErrorMessage = "O campo email é obrigatorio!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatorio!")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ImagemUsuario ImagemUsuario { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Prontuario> Prontuarios { get; set; }
    }
}
