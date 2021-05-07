using System.Collections.Generic;


namespace SYGESTMunicipalSync.Areas.Admin.Models.ViewModel
{
    public class PersonaViewModel
    {
        public Persona Persona { get; set; }  //objeto de ProductItem (CRUD)
        public IEnumerable<Provincia> Provincia { get; set; }   //combo categoria
        public IEnumerable<Canton> Canton { get; set; }     //combo todos los datos prod
        public IEnumerable<Distrito> Distrito { get; set; }     //combo todos los datos prod
    }
}
