using System;
using System.Collections.Generic;

#nullable disable

namespace sp_medical_group.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public byte IdEspecialidade { get; set; }
        public string TipoEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
