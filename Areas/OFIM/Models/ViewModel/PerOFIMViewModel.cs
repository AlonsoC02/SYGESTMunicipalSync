using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class PerOFIMViewModel
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

        public string Persona { get; set; }

        [Display(Name = "Ocupacion:")]
        public int OcupacionId { get; set; }

        public string Ocupacion { get; set; }

        [Display(Name = "Seguro:")]
        public int SeguroId { get; set; }
        public string Seguro { get; set; }

        [Display(Name = "Nacionalidad:")]
        public int NacionalidadId { get; set; }
        public string  Nacionalidad { get; set; }

        [Display(Name = "Nivel Academico:")]
        public int NivelAcademicoId { get; set; }
        public string  NivelAcademico { get; set; }

        [Display(Name = "Estado Civil:")]
        public int EstadoCivilId { get; set; }
        public string  EstadoCivil { get; set; }


        [Display(Name = "Ingreso Persona:")]
        public int IngresoPersonaId { get; set; }
        public double  IngresoPersona { get; set; }
    }
}
