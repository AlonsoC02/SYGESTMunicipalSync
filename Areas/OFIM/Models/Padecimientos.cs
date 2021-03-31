﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Padecimientos
    {
        [Display(Name = "Id:")]
        public int PadecimientoId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre del padecimiento")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripción del padecimiento")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        public virtual ICollection<PersonaOFIM> PersonaOFIM { get; set; }
        public Padecimientos()
        {
            PersonaOFIM = new HashSet<PersonaOFIM>();
        }
    }
}