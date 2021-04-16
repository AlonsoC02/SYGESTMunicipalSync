using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class ProductoServicio
    {
        [Display(Name = "Producto/Servicio Id:")]
        public int Id { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Debe digitar el nombre del producto/servicio")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripcion del producto/servicio")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        public byte[] Imagen { get; set; }

        [Display(Name = "Empresa:")]
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        [Display(Name = "Categoria producto/servicio:")]
        public int CatProductoServicioId { get; set; }
        public virtual CatProductoServicio CatProductoServicio { get; set; }
    }
}

