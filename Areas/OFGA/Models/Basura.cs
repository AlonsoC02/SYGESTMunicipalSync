using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class Basura
    {
        [Display(Name = "ID:")]
        public int BasuraId { get; set; }

        [Display(Name = "Fecha:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe digitar el peso")]
        [Display(Name = "Peso")]
        public float Peso { get; set; }
    }
}
