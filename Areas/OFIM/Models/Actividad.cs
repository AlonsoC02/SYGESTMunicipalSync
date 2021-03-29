using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Actividad
    {
        //public virtual ICollection<Cupos> Cupos { get; set; }
        //public Actividad()
        //{
        //    Cupos = new HashSet<Cupos>();
        //}
        public int ActividadId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la Actividad")]
        [DisplayName("Nombre Eje")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha ")]
        public DateTime? Fecha { get; set; }
        public byte[] Imagen { get; set; }
        [Display(Name = "Está Activo ")]
        public bool Activo { get; set; }

        [Display(Name = "Categoria Id: ")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }


    }
}
