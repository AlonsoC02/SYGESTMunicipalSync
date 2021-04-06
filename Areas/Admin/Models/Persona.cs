using SYGESTMunicipalSync.Areas.OFIM.Models;
using SYGESTMunicipalSync.Areas.PATENTES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Persona
    {
        [Required(ErrorMessage = "Debe digitar el ID de la Persona")]
        [Display(Name = "Indentificacion:")]
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
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNac { get; set; }

        [Display(Name = "Correo Electronico:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electronico válido")]
        public string Email { get; set; }

        [Display(Name = "Sexo:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un sexo valido")]
        public char Sexo { get; set; }

        [Display(Name = "Telefono Movil:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un teléfono valido")]
        public int TelMovil { get; set; }

        [Display(Name = "Telefono Fijo:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un teléfono valido")]
        public int TelFijo { get; set; }

        [Display(Name = "Fax:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un fax valido")]
        public int Fax { get; set; }

        [Display(Name = "Dirección:")]
        [Required(ErrorMessage = "Debe digitar la dirección valida")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Direccion { get; set; }

        [Display(Name = "Distrito:")]
        public int DistritoId { get; set; }
        public virtual Distrito Distrito { get; set; }

        [Display(Name = "Canton:")]
        public int CantonId { get; set; }
        public virtual Canton Canton { get; set; }

        [Display(Name = "Provincia:")]
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }


        public virtual ICollection<Familia> Familia { get; set; }
        public virtual ICollection<PersonaOFIM> PersonaOFIM { get; set; }
        public virtual ICollection<TipoConsulta> TipoConsulta { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Seguimiento> Seguimiento { get; set; }
        public virtual ICollection<Solicitante> Solicitante { get; set; }
        public virtual ICollection<Propietario> Propietario { get; set; }
        
        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public Persona()
        {
            Familia = new HashSet<Familia>();
            PersonaOFIM = new HashSet<PersonaOFIM>();
            TipoConsulta = new HashSet<TipoConsulta>();
            Solicitante = new HashSet<Solicitante>();
            Propietario = new HashSet<Propietario>();
            Usuario = new HashSet<Usuario>();
        }
    }
}
