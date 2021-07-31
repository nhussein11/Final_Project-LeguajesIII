using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torneos_Futbol.Clases
{
    public class Partido
    {
        string fecha;
        string hora { get; set; }
        string lugar { get; set; }
        string resultado { get; set; }
        string equipo1 { get; set; }
        string equipo2 { get; set; }
        string arbitro { get; set; }

        public Partido()
        {
        }
        
        public  Partido(string fecha, string hora, string lugar, string equipo1, string equipo2, string arbitro)
        {
            this.fecha = fecha;
            this.hora = hora;
            this.lugar = lugar;
            this.equipo1 = equipo1;
            this.equipo2 = equipo2;
            this.arbitro = arbitro;
        }
        public Partido(string equipo1, string equipo2)
        {
            
            this.equipo1 = equipo1;
            this.equipo2 = equipo2;
        }
        public string enfrentamiento() {
            return (equipo1 + " vs. " + equipo2);
        }
        public string Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
            }
        }
        public string Hora
        {
            get { return hora; }
            set
            {
                hora = value;
            }
        }
        public string Lugar
        {
            get { return lugar; }
            set
            {
                lugar = value;
            }
        }
        public string Equipo1
        {
            get { return equipo1; }
            set
            {
                equipo1 = value;
            }
        }
        public string Equipo2
        {
            get { return equipo2; }
            set
            {
                equipo2 = value;
            }
        }
        public string Id_Arbitro
        {
            get { return arbitro; }
            set
            {
                arbitro = value;
            }
        }
    }
}