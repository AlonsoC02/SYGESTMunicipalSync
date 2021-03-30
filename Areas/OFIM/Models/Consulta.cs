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
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        [Required(ErrorMessage = "Debe digitar el motivo de la consulta")]
        [Display(Name = "Motivo:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Motivo { get; set; }

        [Display(Name = "Fecha:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; }

        [Display(Name = "Hora inicio:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? HoraInicio { get; set; }

        [Display(Name = "Hora Fin:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
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

        public virtual ICollection<Seguimiento> Seguimiento { get; set; }
        public Consulta()
        {
            
            Seguimiento = new HashSet<Seguimiento>();
        }
    }
}
