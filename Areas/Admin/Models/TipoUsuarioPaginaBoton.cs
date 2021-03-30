using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class TipoUsuarioPaginaBoton
    {
        [Display(Name = "Tipo Usuario Página Boton Id:")]
        public int? TipoUsuarioPaginaBotonId { get; set; }

        [Display(Name = "Tipo Usuario Página Id:")]
        public int? TipoUsuarioPaginaId { get; set; }

        [Display(Name = "Boton Id:")]
        public int? BotonId { get; set; }

        [Display(Name = "Boton Habilitado:")]
        public int? BotonHabilitado { get; set; }
    }
}
