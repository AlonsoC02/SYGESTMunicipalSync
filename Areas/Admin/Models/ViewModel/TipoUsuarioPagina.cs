using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models.ViewModel
{
    public class TipoUsuarioPagina
    {
        [Display(Name = "Tipo Usuario Página Id:")]
        public int TipoUsuarioPaginaId { get; set; }

        [Display(Name = "Tipo Usuario:")]
        public int? TipoUsuarioId { get; set; }

        [Display(Name = "Página Id")]
        public int? PaginaId { get; set; }

        [Display(Name = "Boton Habilitado")]
        public int? BotonHabilitado { get; set; }
        public string NombreTipoUsuario { get; set; }
        public string NombrePagina { get; set; }
    }
}
