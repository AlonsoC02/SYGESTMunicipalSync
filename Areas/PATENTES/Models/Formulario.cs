using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class Formulario
    {

        [Display(Name = "Formulario Id:")]
        public int FormularioId { get; set; }

        [Display(Name = "Fecha Recibido:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaRecibo { get; set; }

        [Display(Name = "Numero de tramite:")]
        public int NumTramite { get; set; }

        [Display(Name = "Motivo:")]
        public int MotivoId { get; set; }
        public virtual Motivo Motivo { get; set; }

        [Display(Name = "Solicitante:")]
        public int SolicitanteId { get; set; }
        public virtual Solicitante Solicitante { get; set; }

        [Display(Name = "Propietario:")]
        public int PropietarioId { get; set; }
        public virtual Propietario Propietario { get; set; }

        [Display(Name = "Establecimiento:")]
        public int EstablecimientoId { get; set; }
        public virtual Establecimiento Establecimiento { get; set; }
    }
}
