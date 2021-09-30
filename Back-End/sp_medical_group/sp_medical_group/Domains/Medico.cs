using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace sp_medical_group.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public short IdMedico { get; set; }

        [Required(ErrorMessage = "Informe o id de Usuario!")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o id da Clinica!")]
        public byte? IdClinica { get; set; }

        [Required(ErrorMessage = "Informe o ID da Especialidade do Médico!")]
        public byte? IdEspecialidade { get; set; }
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
