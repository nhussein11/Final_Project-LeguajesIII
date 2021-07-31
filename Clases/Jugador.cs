using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torneos_Futbol.Clases
{
    public static class Jugador
    {
        public static string nombre_jugador { get; set; }
        public static string apellido_jugador { get; set; }
        public static string telefono_jugador { get; set; }
        public static string direccion_jugador { get; set; }
        public static int rojas_jugador { get; set; }
        public static int amarillas_jugador { get; set; }
        public static int goles_jugador { get; set; }
        public static string username_jugador { get; set; }
        public static string password_jugador { get; set; }
        public static string mail_jugador { get; set; }
        public static string equipo_jugador { get; set; }
        public static bool jugador_conectado { get; set; }
    }
}