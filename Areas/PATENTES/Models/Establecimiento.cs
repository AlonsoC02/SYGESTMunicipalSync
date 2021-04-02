using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class Establecimiento
    {
        [Display(Name = "Establecimiento Id:")]
        public int EstablecimientoId { get; set; }

        [Display(Name = "Nombre Comercial:")]
        [Required(ErrorMessage = "Debe digitar el nombre comercial")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string NombreComercial { get; set; }

        [Display(Name = "Descripción Actividad:")]
        [Required(ErrorMessage = "Debe digitar la descripcion")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string DescripcionActividad { get; set; }

        [Display(Name = "Actividades Secundarias:")]
        [Required(ErrorMessage = "Debe digitar la o las activiades secundarias del establecimiento")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string ActividadesSecundarias { get; set; }

        [Display(Name = "Dirección:")]
        [Required(ErrorMessage = "Debe digitar la dirección del establecimiento")]
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

        [Display(Name = "Numero de finca:")]
        [Required(ErrorMessage = "Debe digitar el numero de finca del establecimiento")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string NumFinca { get; set; }

        [Display(Name = "Numero de palno:")]
        [Required(ErrorMessage = "Debe digitar el numero de plano del establecimiento")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string NumPlano { get; set; }

        [Required(ErrorMessage = "Debe digitar el area en metros cuadrados del establecimiento")]
        [Display(Name = "Área en metros cuadrados:")]
        public float Aream2 { get; set; }

        [Display(Name = "Hora entrada:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HoraEntrada { get; set; }

        [Display(Name = "Hora salida:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HoraCierre { get; set; }

        [Display(Name = "Cantidad de mujeres:")]
        [Required(ErrorMessage = "Debe digitar la cantidad de mujeres")]
        public int CantMujeres { get; set; }

        [Display(Name = "Cantidad de hombres:")]
        [Required(ErrorMessage = "Debe digitar la cantidad de hombres")]
        public int CantHombres { get; set; }

        [Display(Name = "Solicitante")]
        public bool Solicitante { get; set; }

        [Display(Name = "Pagina Web:")]
        [Required(ErrorMessage = "Debe digitar la pagina webdel establecimiento")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string PaginaWeb { get; set; }

        [Display(Name = "Calificados:")]
        [Required(ErrorMessage = "Debe digitar la cantidad de personas calificadas")]
        public int Calificados { get; set; }

        [Display(Name = "No Calificados:")]
        [Required(ErrorMessage = "Debe digitar la cantidad de personas no calificadas")]
        public int NoCalificados { get; set; }

        [Display(Name = "Tipo de Inmueble:")]
        public int TipoInmuebleId { get; set; }
        public virtual TipoInmueble TipoInmueble { get; set; }

        [Display(Name = "Clasificacion de Senasa:")]
        public int ClasifSenasaId { get; set; }
        public virtual ClasifSenasa ClasifSenasa { get; set; }

        [Display(Name = "Clase:")]
        public string ClaseId { get; set; }
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public virtual Clase Clase { get; set; }


        public virtual ICollection<Formulario> Formulario { get; set; }
        public Establecimiento()
        {
            Formulario = new HashSet<Formulario>();
        }
    }
}
