using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class PersonaOFIM
    {

        [Display(Name = "Id:")]
        public int PersonaOFIMId { get; set; }

        [Display(Name = "Persona:")]
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        [Display(Name = "Ocupacion:")]
        public int OcupacionId { get; set; }
        public virtual Ocupacion Ocupacion { get; set; }

        [Display(Name = "Seguro:")]
        public int SeguroId { get; set; }
        public virtual Seguro Seguro { get; set; }

        [Display(Name = "Nacionalidad:")]
        public int NacionalidadId { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }

        [Display(Name = "Nivel Academico:")]
        public int NivelAcademicoId { get; set; }
        public virtual NivelAcademico NivelAcademico { get; set; }

        [Display(Name = "Estado Civil:")]
        public int EstadoCivilId { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Padecimiento:")]
        public int PadecimientoId { get; set; }
        public virtual Padecimientos Padecimiento { get; set; }

        [Display(Name = "Discapacidad:")]
        public int DiscapacidadId { get; set; }
        public virtual Discapacidades Discapacidad { get; set; }

        [Display(Name = "Ingreso Persona:")]
        public int IngresoPersonaId { get; set; }
        public virtual IngresoPersona IngresoPersona { get; set; }
    }
}
