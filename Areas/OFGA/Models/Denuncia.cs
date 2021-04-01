using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class Denuncia
    {

        [Display(Name = "Id:")]
        public int DenunciaId { get; set; }

        [Display(Name = "Fecha:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Infractor:")]
        [Required(ErrorMessage = "Debe digitar el infractor")]
        [StringLength(250, ErrorMessage = "Ha excedido los 250 caracteres")]
        public string Infractor { get; set; }

        [Display(Name = "Direccion:")]
        [Required(ErrorMessage = "Debe digitar la direccion de la denuncia")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Direccion { get; set; }

        [Display(Name = "Distrito:")]
        public int DistritoId { get; set; }
        public virtual Distrito Distrito { get; set; }

        [Display(Name = "Canton:")]
        public int CantonId { get; set; }
        public virtual Canton Canton { get; set; }

        [Display(Name = "Provincia:")]
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }

        [Display(Name = "Reincidente: ")]
        public bool Reincidente { get; set; }

        [Display(Name = "Dependencia Anterior:")]
        [Required(ErrorMessage = "Debe digitar la dependencia anterior")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string DependenciaAnterior { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripcion de la denuncia")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Name = "Anonima: ")]
        public bool Anonima { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }

        [Display(Name = "Usuario:")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Display(Name = "Tipo Denuncia:")]
        public int TipoDenunciaId { get; set; }
        public virtual TipoDenuncia TipoDenuncia { get; set; }

        [Display(Name = "Tipo Actividad:")]
        public int TipoActividadId { get; set; }
        public virtual TipoActividad TipoActividad { get; set; }
    }
}
