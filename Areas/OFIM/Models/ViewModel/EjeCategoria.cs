using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class EjeCategoria
    {
        public int EjeId { get; set; }
        [Required]
        [Display(Name = "Nombre Eje")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "ID Categoria ")]
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }

        public static implicit operator List<object>(EjeCategoria v)
        {
            throw new NotImplementedException();
        }
    }
}
