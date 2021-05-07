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

        [Display(Name = "Padecimiento:")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Padecimiento { get; set; }

        [Display(Name = "Discapacidad:")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Discapacidad { get; set; }

        [Display(Name = "Persona:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string PersonaId { get; set; }
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

   
        [Display(Name = "Ingreso Persona:")]
        public int IngresoPersonaId { get; set; }
        public virtual IngresoPersona IngresoPersona { get; set; }
    }
}
