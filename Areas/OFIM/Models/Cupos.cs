using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Cupos
    {
        [Display(Name = "Id:")]
        public int CuposId { get; set; }

        [Required(ErrorMessage = "Debe digitar cupo maximo")]
        [Display(Name = "CupoMax:")]
        public int CupoMax { get; set; }
    }
}
