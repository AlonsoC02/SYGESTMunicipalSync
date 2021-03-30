﻿using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class TipoConsulta
    {

        [Display(Name = "Tipo Consulta:")]
        public int TipoConsultaId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del tipo de consulta")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Display(Name = "Persona:")]
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }


        public virtual ICollection<Consulta> Consulta { get; set; }
        public TipoConsulta()
        {
            
            Consulta = new HashSet<Consulta>();
        }
    }
}
