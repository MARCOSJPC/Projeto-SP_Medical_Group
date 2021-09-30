using System;
using System.Collections.Generic;

#nullable disable

namespace sp_medical_group.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public byte IdClinica { get; set; }
        public string Cnpj { get; set; }
        public string NomeClinica { get; set; }
        public string Endereco { get; set; }
        public string RazaoSocial { get; set; }
        public TimeSpan? HorarioAbre { get; set; }
        public TimeSpan? HorarioFecha { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
