using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class Quejas
    {
        [Display(Name = "Id:")]
        public int QuejasId { get; set; }

        [Required(ErrorMessage = "Debe digitar el asunto de la queja")]
        [Display(Name = "Asunto:")]
        public string Asunto { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripción de las quejas")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Direccion:")]
        [Required(ErrorMessage = "Debe digitar la direccion de la queja")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string Direccion { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }
        /////////preguntar sobre contacto y persona o usuario///////

        [Display(Name = "Clasificacion:")]
        public int ClasificacionId { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }

        [Display(Name = "Usuario:")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
