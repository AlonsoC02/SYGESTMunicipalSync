using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models.ViewModel
{
    public class RegistroExternoVM
    {
                
        [Display(Name = "Usuario Id:")]
        public int UsuarioId { get; set; }

        [Display(Name = "Cédula o Pasaporte:")]
        public string PersonaId { get; set; }
        
        [Display(Name = "Nombre Persona:")]
        public string NombrePersona { get; set; }

        [Display(Name = "Rol Id:")]
        public int RolId { get; set; }
        
        [Display(Name = "Rol:")]
        public string NombreRol { get; set; }

        [Display(Name = "Nombre usuario:")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Debe digitar la contraseña del usuario")]
        [Display(Name = "Contraseña:")]
        //[StringLength(12, ErrorMessage = "La clave debe contener almenos 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public int SelectedOption { get; set; }
        //public IEnumerable<SelectListItem> Lista { get; set; }
    }
}
