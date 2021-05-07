using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Consulta
    {

        [Display(Name = "Consulta:")]
        public int ConsultaId { get; set; }

        [Display(Name = "Persona:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        [Required(ErrorMessage = "Debe digitar el motivo de la consulta")]
        [Display(Name = "Motivo:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Motivo { get; set; }

        [Display(Name = "Fecha:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Hora Inicio")]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? HoraInicio { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Hora Fin")]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? HoraFin { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripción de la consulta")]
        [StringLength(300, ErrorMessage = "Ha excedido los 300 caracteres")]
        public string Descripcion { get; set; }

        [Display(Name = "Respuesta:")]
        [Required(ErrorMessage = "Debe digitar la respuesta de la consulta")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Respuesta { get; set; }

        [Display(Name = "Remitir ")]
        public bool Remitir { get; set; }

        [Display(Name = "Tipo Consulta:")]
        public int TipoConsultaId { get; set; }
        public virtual TipoConsulta TipoConsulta { get; set; }


        [Display(Name = "Padecimiento:")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Padecimiento { get; set; }

        [Display(Name = "Discapacidad:")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Discapacidad { get; set; }

        

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

        public virtual ICollection<Seguimiento> Seguimiento { get; set; }
        public Consulta()
        {
            
            Seguimiento = new HashSet<Seguimiento>();
        }
    }
}
