using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models.ViewModel
{
    public class SolicitanteViewModel
    {
        [Key]
        [Display(Name = "ID:")]
        public int SolicitanteId { get; set; }

        [Display(Name = "Cedula Juridica:")]
        [Required(ErrorMessage = "Debe digitar la cedula juridica de el solicitante")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string CedulaJuridica { get; set; }

        [Display(Name = "Nombre Razón Social:")]
        [Required(ErrorMessage = "Debe digitar la Razón social")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string NombreRazonSocial { get; set; }

        [Display(Name = "TipoRepresentante:")]
        public int TipoRepresentanteId { get; set; }
        public string TipoRepresentante { get; set; }

        [Display(Name = "Contacto:")]
        public int ContactoId { get; set; }
        public string Contacto { get; set; }

        [Display(Name = "Cédula o Pasaporte:")]
        public string PersonaId { get; set; }
        [Display(Name = "Nombre Persona:")]
        public string NombrePersona { get; set; }

        public string msgError { get; set; }

        public static implicit operator List<object>(SolicitanteViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
