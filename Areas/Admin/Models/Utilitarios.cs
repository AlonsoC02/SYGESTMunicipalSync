using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public class Utilitarios
    {
        //HOME PAGE
        public static string MenuADMIN; //ADMINISTRADOR

        public static string MenuDep; //DEPARTAMENTOS
        public static string MenuServDig; //SERVICIOS DIGITALES
       

        public static string MenuServ;
       
        public static string MenuMant;
        public static string MenuMantOFIM;
        public static string MenuRegAten;
        public static string MenuGestServ;
        public static string MenuRED;
        public static string MenuConsulta;
        public static string MenuFormacion;
        public static string MenuEmpre;

        public static string MenuMantOFGA;
        public static string MenuAcopio;
        public static string MenuResi;
        public static string MenuDenun;
        public static string MenuCons;
        public static string MenuProcForm;

        public static string MenuMantPAT;
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
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public static string CifrarDatos(string data)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(data);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }


        public static string DescifrarDatos(string data)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(data);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }


    }
}
