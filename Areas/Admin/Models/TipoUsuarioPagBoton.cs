using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class TipoUsuarioPagBoton
    {
        [Display(Name = "Tipo Usuario Página Boton Id:")]
        public int? TipoUsuarioPagBotonId { get; set; }

        [Display(Name = "Tipo Usuario Página Id:")]
        public int? TipoUsuarioPagId { get; set; }
        public virtual TipoUsuarioPag TipoUsuarioPag { get; set; }

        [Display(Name = "Boton Id:")]
        public int? BotonId { get; set; }
        public virtual Boton Boton { get; set; }

        [Display(Name = "Boton Habilitado:")]
        public bool BotonHabilitado { get; set; }


    }
}
