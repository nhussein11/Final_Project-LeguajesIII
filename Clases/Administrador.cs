using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torneos_Futbol.Clases
{
    public static class Administrador
    {
        
        public static string nombre_administrador { get; set; }
        public static string apellido_administrador { get; set; }
        public static string username_administrador { get; set; }
        public static string password_administrador { get; set; }
        public static string mail_administrador { get; set; }

        public static bool administrador_conectado { get; set; }
    }
}