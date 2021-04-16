using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Empresa
    {
        
        [Display(Name = "Empresa Id:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la Empresa")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        //[Display(Name = "Logo")]
        //public byte[] Logo { get; set; }

        [Display(Name = "Ubicacion:")]
        [Required(ErrorMessage = "Debe digitar la Ubicacion")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Ubicacion { get; set; }

        [Display(Name = "Pagina Web:")]
        [Required(ErrorMessage = "Debe digitar la Pagina Web de la empresa")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string PaginaWeb { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Debe digitar un email valido")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripcion de la empresa")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Name = "Telefono:")]
        [Required(ErrorMessage = "Debe digitar el numero de telefono de la empresa")]
        public int Telefono { get; set; }

        [Display(Name = "Persona:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        [Display(Name = "Categoria producto/servicio:")]
        public int CatProductoServicioId { get; set; }
        public virtual CatProductoServicio CatProductoServicio { get; set; }

        public virtual ICollection<ProductoServicio> ProductoServicio { get; set; }
        public Empresa()
        {
            ProductoServicio = new HashSet<ProductoServicio>();

        }
    }
}
