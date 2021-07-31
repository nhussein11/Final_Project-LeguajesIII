using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torneos_Futbol.Clases
{
    public static class Arbitro
    {
        public static string nombre_arbitro { get; set; }
        public static string apellido_arbitro { get; set; }
        public static string username_arbitro { get; set; }
        public static string password_arbitro { get; set; }


        public static bool arbitro_conectado { get; set; }
    }
}