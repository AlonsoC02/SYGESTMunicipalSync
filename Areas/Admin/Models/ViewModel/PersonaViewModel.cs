using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models.ViewModel
{
    public class PersonaViewModel
    {
        [Required(ErrorMessage = "Debe digitar el ID de la Persona")]
        [Display(Name = "Cédula o Pasaporte:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string CedulaPersona { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la Persona")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe digitar el primer Apellido de la Persona")]
        [Display(Name = "Apellido:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string Ape1 { get; set; }

        [Required(ErrorMessage = "Debe digitar el segundo Apellido de la Persona")]
        [Display(Name = "Apellido:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string Ape2 { get; set; }

        [Display(Name = "Fecha Nacimiento:")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNac { get; set; }

        [Display(Name = "Correo Electronico:")]
        public string Email { get; set; }

        [Display(Name = "Sexo:")]
        public char Sexo { get; set; }

        [Display(Name = "Telefono Movil:")]
        public int TelMovil { get; set; }

        [Display(Name = "Telefono Fijo:")]
        public int TelFijo { get; set; }

        [Display(Name = "Fax:")]
        
        public int Fax { get; set; }

        [Display(Name = "Dirección:")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Direccion { get; set; }
        [Display(Name = "Domicilio:")]
        public string Domicilio { get; set; }
        [Display(Name = "Distrito:")]
        public int DistritoId { get; set; }
        public string Distrito { get; set; }

        [Display(Name = "Canton:")]
        public int CantonId { get; set; }
        public string Canton { get; set; }

        [Display(Name = "Provincia:")]
        public int ProvinciaId { get; set; }
        public string Provincia { get; set; }

        public string msgError { get; set; }

        public static implicit operator List<object>(PersonaViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
