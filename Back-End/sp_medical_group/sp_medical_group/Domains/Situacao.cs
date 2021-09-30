using System;
using System.Collections.Generic;

#nullable disable

namespace sp_medical_group.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public byte IdSituacao { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
