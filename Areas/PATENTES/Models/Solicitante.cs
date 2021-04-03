using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class Solicitante
    {

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

        [Display(Name = "Tipo Representante:")]
        public int TipoRepresentanteId { get; set; }
        public virtual TipoRepresentante TipoRepresentante { get; set; }

        [Display(Name = "Contacto:")]
        public int ContactoId { get; set; }
        public virtual Contacto Contacto { get; set; }

        [Display(Name = "Persona:")]
        public int PersonaId { get; set; }
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public virtual Persona Persona { get; set; }

        public virtual ICollection<Formulario> Formulario { get; set; }
        public Solicitante()
        {
            Formulario = new HashSet<Formulario>();
        }
    }
}
