using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class EmpresaViewModel
    {
        [Key]
        [Display(Name = "Paca Id: ")]
        public int EmpresaId { get; set; }


        public Empresa Empresa { get; set; }  //objeto de Actividad (CRUD)
        public IEnumerable<Persona> Persona { get; set; }
        
        public IEnumerable<CatProductoServicio> CatProductoServicio { get; set; }


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
        public string PersonaId { get; set; }
      

        [Display(Name = "Categoria Producto/Servicio:")]
        public int CatProductoServicioId { get; set; }
     

        public string msgError { get; set; }

        public static implicit operator List<object>(EmpresaViewModel v)
        {
            throw new NotImplementedException();
        }

    }
}
