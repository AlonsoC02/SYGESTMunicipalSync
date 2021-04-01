using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class Charlas
    {

        [Display(Name = "Id:")]
        public int CharlasId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre de la charla")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Fecha:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }


        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripción de la charla")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }

        [Display(Name = "Lugar:")]
        [Required(ErrorMessage = "Debe digitar el lugar del punto de recuperacion")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string Lugar { get; set; }

        [Display(Name = "Activa")]
        public bool Activa { get; set; }

        [Display(Name = "Expositor:")]
        [Required(ErrorMessage = "Debe digitar el expositor de la charla")]
        [StringLength(250, ErrorMessage = "Ha excedido los 250 caracteres")]
        public string Expositor { get; set; }

    }
}
