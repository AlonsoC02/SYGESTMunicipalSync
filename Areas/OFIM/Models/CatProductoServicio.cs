using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class CatProductoServicio
    {
        [Display(Name = "Id:")]
        public int CatProductoServicioId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre de la categoria o producto")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripción de la categoria")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<ProductoServicio> ProductoServicio { get; set; }
        public CatProductoServicio()
        {
            Empresa = new HashSet<Empresa>();
            
        }

    }
}
