using System;
using System.Collections.Generic;

#nullable disable

namespace sp_medical_group.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public short? IdMedico { get; set; }
        public int? IdProntuario { get; set; }
        public byte? IdSituacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Prontuario IdProntuarioNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
