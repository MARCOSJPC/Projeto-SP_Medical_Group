using System;
using System.Collections.Generic;

#nullable disable

namespace sp_medical_group.Domains
{
    public partial class Prontuario
    {
        public Prontuario()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdProntuario { get; set; }
        public int? IdUsuario { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNasc { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
