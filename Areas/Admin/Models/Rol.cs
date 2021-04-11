using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Rol
    {
        public Rol()
        {
            RolUsuario = new HashSet<RolUsuario>();
            
        }
        [Display(Name = "Rol Usuario Id:")]
        public int RolId { get; set; }

        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }
        
        [Display(Name = "Descripcion:")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        [Required(ErrorMessage = "Debe digitar la descripción de la Especialidad")]
        public string Descripcion { get; set; }
        

        public virtual ICollection<RolUsuario> RolUsuario { get; set; }

       


    }
}
