using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public class Utilitarios
    {
        public static string MenuInicio;
        public static string MenuOFGA;
        public static string MenuOFIM;
        public static string MenuPATENTES;


        public static List<Pagina> ListarBotonesDatos(string nomcontroller)
        {
            List<Pagina> listapag = new List<Pagina>();
            listapag = Utilitarios.listaBotonesPagina
                .Where(p => p.Controlador.ToUpper() == nomcontroller.ToUpper()).ToList();
            return listapag;
        }

        public static List<Pagina> listaPagina;
        public static List<Pagina> listaBotonesPagina;

        public static List<string> ListaController { get; set; } = new List<string>();
        public static List<string> ListaMenu { get; set; } = new List<string>();
        public static List<string> ListaAccion { get; set; } = new List<string>();


    }
}
