using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models.ViewModel
{
    public class PersonaUsuario
    {
        [Display(Name = "Usuario Id:")]
        public int UsuarioId { get; set; }

        [Display(Name = "Nombre usuario:")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Contraseña:")]
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña:")]
        public string ConfirmarContrasena { get; set; }

        [Display(Name = "Persona:")]
        public string PersonaId { get; set; }

        [Display(Name = "Nombre Persona:")]
        public string NombrePersona { get; set; }
        public string msgError { get; set; }

        public static implicit operator List<object>(PersonaUsuario v)
        {
            throw new NotImplementedException();
        }

    }
}
