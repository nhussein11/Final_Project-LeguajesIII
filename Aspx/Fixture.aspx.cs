using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Torneos_Futbol.Clases;

namespace Torneos_Futbol.Aspx
{
    public partial class Fixture : System.Web.UI.Page
    {
        //EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Administrador.administrador_conectado) {
                Button_CrearFixture.Visible = true;
            }
            //Oculto todo
            TextBox[] textBoxes_All = new[] { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12, TextBox_1_1, TextBox_1_2, TextBox_1_3, TextBox_1_4, TextBox_1_5, TextBox_1_6, TextBox_dia1, TextBox_dia2, TextBox_dia3, TextBox_dia4, TextBox_dia5, TextBox_dia6, TextBox_hora1, TextBox_hora2, TextBox_hora3, TextBox_hora4, TextBox_hora5, TextBox_hora6, TextBox_cancha1, TextBox_cancha2, TextBox_cancha3, TextBox_cancha4, TextBox_cancha5, TextBox_cancha6, TextBox_arbitro1, TextBox_arbitro2, TextBox_arbitro3, TextBox_arbitro4, TextBox_arbitro5, TextBox_arbitro6 };
            for (int i = 0; i < textBoxes_All.Length; i++) {
                textBoxes_All[i].Visible = false;
            }
            Label[] labels_All = new[] { Label_Fecha, Label_partido, Label_dia, Label_hora, Label_cancha, Label_arbitro, Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label11, Label12 };
            for (int i = 0; i < labels_All.Length; i++)
            {
                labels_All[i].Visible = false;
            }
            Button_CrearFixtureFinal.Visible = false;
            Button_AgregarTabla.Visible = false;
            cargar_tabla_fixture();
            Table_Fixture.Visible = true;
        }


        protected void Button_CrearFixture_Click(object sender, EventArgs e)
        {
            crea_calendario.Visible = true;
            CheckBox1.Visible = true;
            Button_CrearFixtureFinal.Visible = true;
            Button_AgregarTabla.Visible = false;
            
            mostrar_labels_textboxs();
            borrar_partidos();
            borrar_puntos();
            borrar_datos_jug();
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            mostrar_labels_textboxs();
            Button_CrearFixtureFinal.Visible = true;
            Button_AgregarTabla.Visible = false;

            
            if (CheckBox1.Checked)
            {
                cargar_equipos();
            }
            else {
                Label[] labels_All = new[] { Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label11, Label12 };
                for (int i = 0; i < labels_All.Length; i++)
                {
                    labels_All[i].Text = "Equipo " + (i + 1).ToString() + ":";
                }
                TextBox[] textBoxes = new[] { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12 };
                for (int i = 0; i < textBoxes.Length; i++) {
                    textBoxes[i].Text = "";
                }
            }
        }
        protected void Button_CrearFixtureFinal_Click(object sender, EventArgs e)
        {
            
            Button_CrearFixtureFinal.Visible = true;
            Button_AgregarTabla.Visible = true;
            Label_Fecha.Visible = true;
            
            ViewState["count"] = Convert.ToInt32(ViewState["count"]) + 1;
            Label_Fecha.Text = "Fecha " + ViewState["count"].ToString() + ":";
            if (Convert.ToInt32(ViewState["count"]) > 0)
            {
                Button_CrearFixtureFinal.Text = "Proxima Fecha";
                CheckBox1.Visible = false;
                Table_Fixture.Visible = true;
            }
            //Vistas
            if (Convert.ToInt32(ViewState["count"]) == cantidad_equipos() - 1)
            {
                Button_CrearFixtureFinal.Visible = false;

                Label_Fecha.Text = "Para " + cantidad_equipos().ToString() + " equipos existirán solamente " + (cantidad_equipos() - 1).ToString() + " fechas";
                Label_partido.Visible = false;
                Label_dia.Visible = false;
                Label_hora.Visible = false;
                Label_cancha.Visible = false;
                Label_arbitro.Visible = false;

            }

            visbilidad();
            TextBox[] textBoxes_All = new[] { TextBox_1_1, TextBox_1_2, TextBox_1_3, TextBox_1_4, TextBox_1_5, TextBox_1_6, TextBox_dia1, TextBox_dia2, TextBox_dia3, TextBox_dia4, TextBox_dia5, TextBox_dia6, TextBox_hora1, TextBox_hora2, TextBox_hora3, TextBox_hora4, TextBox_hora5, TextBox_hora6, TextBox_cancha1, TextBox_cancha2, TextBox_cancha3, TextBox_cancha4, TextBox_cancha5, TextBox_cancha6, TextBox_arbitro1, TextBox_arbitro2, TextBox_arbitro3, TextBox_arbitro4, TextBox_arbitro5, TextBox_arbitro6 };
            for (int i = 0; i < textBoxes_All.Length; i++)
            {
                textBoxes_All[i].Visible = true;
            }
            Label[] labels_All = new[] { Label_Fecha, Label_partido, Label_dia, Label_hora, Label_cancha, Label_arbitro, Label1, Label2, Label3, Label4, Label5, Label6 };
            for (int i = 0; i < labels_All.Length; i++)
            {
                labels_All[i].Visible = true;
            }
            //Calcula la fecha en cuestion
            proxima_fecha();
            cargar_horas();
            cargar_arbitros();


        }

        protected void Click_Agregar_Tabla(object sender, EventArgs e)
        {
            Button_AgregarTabla.Visible = true;
            Button_CrearFixtureFinal.Visible = true;
            Label_Fecha.Visible = true;
            Table_Fixture.Visible = true;
            
            visbilidad();

            //Equipo 1 = TextBox_1_1.Text.ToString().Substring(0, TextBox_1_1.Text.IndexOf("vs"));
            //Equipo 2 = TextBox_1_1.Text.ToString().Substring(Convert.ToInt32((TextBox_1_1.Text.IndexOf("."))+2) , Convert.ToInt32( TextBox_1_1.Text.Length.ToString())- Convert.ToInt32((TextBox_1_1.Text.IndexOf(".")) + 2));

            //INSTANCIO LOS 6 PARTIDOS DE LA FECHA i
            Partido partido1 = new Partido(TextBox_dia1.Text, TextBox_hora1.Text, TextBox_cancha1.Text, TextBox_1_1.Text.ToString().Substring(0, TextBox_1_1.Text.IndexOf("vs")), TextBox_1_1.Text.ToString().Substring(Convert.ToInt32((TextBox_1_1.Text.IndexOf(".")) + 2), Convert.ToInt32(TextBox_1_1.Text.Length.ToString()) - Convert.ToInt32((TextBox_1_1.Text.IndexOf(".")) + 2)), TextBox_arbitro1.Text.ToString().Substring(0, TextBox_arbitro1.Text.IndexOf(" ")));
            Partido partido2 = new Partido(TextBox_dia2.Text, TextBox_hora2.Text, TextBox_cancha2.Text, TextBox_1_2.Text.ToString().Substring(0, TextBox_1_2.Text.IndexOf("vs")), TextBox_1_2.Text.ToString().Substring(Convert.ToInt32((TextBox_1_2.Text.IndexOf(".")) + 2), Convert.ToInt32(TextBox_1_2.Text.Length.ToString()) - Convert.ToInt32((TextBox_1_2.Text.IndexOf(".")) + 2)), TextBox_arbitro2.Text.ToString().Substring(0, TextBox_arbitro2.Text.IndexOf(" ")));
            Partido partido3 = new Partido(TextBox_dia3.Text, TextBox_hora3.Text, TextBox_cancha3.Text, TextBox_1_3.Text.ToString().Substring(0, TextBox_1_3.Text.IndexOf("vs")), TextBox_1_3.Text.ToString().Substring(Convert.ToInt32((TextBox_1_3.Text.IndexOf(".")) + 2), Convert.ToInt32(TextBox_1_3.Text.Length.ToString()) - Convert.ToInt32((TextBox_1_3.Text.IndexOf(".")) + 2)), TextBox_arbitro3.Text.ToString().Substring(0, TextBox_arbitro3.Text.IndexOf(" ")));
            Partido partido4 = new Partido(TextBox_dia4.Text, TextBox_hora4.Text, TextBox_cancha4.Text, TextBox_1_4.Text.ToString().Substring(0, TextBox_1_4.Text.IndexOf("vs")), TextBox_1_4.Text.ToString().Substring(Convert.ToInt32((TextBox_1_4.Text.IndexOf(".")) + 2), Convert.ToInt32(TextBox_1_4.Text.Length.ToString()) - Convert.ToInt32((TextBox_1_4.Text.IndexOf(".")) + 2)), TextBox_arbitro4.Text.ToString().Substring(0, TextBox_arbitro4.Text.IndexOf(" ")));
            Partido partido5 = new Partido(TextBox_dia5.Text, TextBox_hora5.Text, TextBox_cancha5.Text, TextBox_1_5.Text.ToString().Substring(0, TextBox_1_5.Text.IndexOf("vs")), TextBox_1_5.Text.ToString().Substring(Convert.ToInt32((TextBox_1_5.Text.IndexOf(".")) + 2), Convert.ToInt32(TextBox_1_5.Text.Length.ToString()) - Convert.ToInt32((TextBox_1_5.Text.IndexOf(".")) + 2)), TextBox_arbitro5.Text.ToString().Substring(0, TextBox_arbitro5.Text.IndexOf(" ")));
            Partido partido6 = new Partido(TextBox_dia6.Text, TextBox_hora6.Text, TextBox_cancha6.Text, TextBox_1_6.Text.ToString().Substring(0, TextBox_1_6.Text.IndexOf("vs")), TextBox_1_6.Text.ToString().Substring(Convert.ToInt32((TextBox_1_6.Text.IndexOf(".")) + 2), Convert.ToInt32(TextBox_1_6.Text.Length.ToString()) - Convert.ToInt32((TextBox_1_6.Text.IndexOf(".")) + 2)), TextBox_arbitro6.Text.ToString().Substring(0, TextBox_arbitro6.Text.IndexOf(" ")));
            //Inserto el partido i en la bdd
            agregar_partido(partido1);
            agregar_partido(partido2);
            agregar_partido(partido3);
            agregar_partido(partido4);
            agregar_partido(partido5);
            agregar_partido(partido6);
            //Los cargo en la tabla
            
            cargar_tabla_fixture();
            if (Convert.ToInt32(ViewState["count"]) == cantidad_equipos()-1) {
                Button_AgregarTabla.Visible = false;
                Button_CrearFixtureFinal.Visible = false;
            }
            

        }

        //FUNCIONES
        public void cargar_equipos()
        {
            TextBox[] textBoxes = new[] { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12 };
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();
                string query_cantidad_equipos = "SELECT count(1) FROM Equipo";
                SqlCommand cmd_quipos_cantidad = new SqlCommand(query_cantidad_equipos, conn);
                int cantidad_equipos = Convert.ToInt32(cmd_quipos_cantidad.ExecuteScalar());

                string query_TablaNoticias = "SELECT * FROM Equipo";
                SqlCommand cmd_Noticias = new SqlCommand(query_TablaNoticias, conn);
                SqlDataReader dr = cmd_Noticias.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    textBoxes[i].Text = Convert.ToString(dr[1]);
                    i++;
                }
            }
        }
        public void rotar_equipos() {
            TextBox[] textBoxes = new[] { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12 };
            //Tomando a "Equipo 1" como pivot, roto los valores de los text boxs:
            //Almaceno todos los valores actuales en un string para no perder valores

            string _2 = TextBox2.Text;
            string _3 = TextBox3.Text;
            string _4 = TextBox4.Text;
            string _5 = TextBox5.Text;
            string _6 = TextBox6.Text;
            string _7 = TextBox7.Text;
            string _8 = TextBox8.Text;
            string _9 = TextBox9.Text;
            string _10 = TextBox10.Text;
            string _11 = TextBox11.Text;
            string _12 = TextBox12.Text;
            //Hago los intercambios correspondientes
            TextBox2.Text = _3;
            TextBox3.Text = _4;
            TextBox4.Text = _5;
            TextBox5.Text = _6;

            TextBox6.Text = _12;

            TextBox12.Text = _11;
            TextBox11.Text = _10;
            TextBox10.Text = _9;
            TextBox9.Text = _8;
            TextBox8.Text = _7;

            TextBox7.Text = _2;

        }
        public void proxima_fecha() {
            Partido partido1 = new Partido(TextBox1.Text, TextBox7.Text);
            Partido partido2 = new Partido(TextBox2.Text, TextBox8.Text);
            Partido partido3 = new Partido(TextBox3.Text, TextBox9.Text);
            Partido partido4 = new Partido(TextBox4.Text, TextBox10.Text);
            Partido partido5 = new Partido(TextBox5.Text, TextBox11.Text);
            Partido partido6 = new Partido(TextBox6.Text, TextBox12.Text);


            TextBox_1_1.Text = partido1.enfrentamiento();
            TextBox_1_2.Text = partido2.enfrentamiento();
            TextBox_1_3.Text = partido3.enfrentamiento();
            TextBox_1_4.Text = partido4.enfrentamiento();
            TextBox_1_5.Text = partido5.enfrentamiento();
            TextBox_1_6.Text = partido6.enfrentamiento();

            rotar_equipos();
        }
        public int cantidad_equipos() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();
                string query_cantidad_equipos = "SELECT count(1) FROM Equipo";
                SqlCommand cmd_quipos_cantidad = new SqlCommand(query_cantidad_equipos, conn);
                int cantidad_equipos = Convert.ToInt32(cmd_quipos_cantidad.ExecuteScalar());
                return cantidad_equipos;
            }
        }
        public void cargar_arbitros() {
            TextBox[] textBoxes_arbitros = new[] { TextBox_arbitro1, TextBox_arbitro2, TextBox_arbitro3, TextBox_arbitro4, TextBox_arbitro5, TextBox_arbitro6 };
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();

                string query_TablaNoticias = "SELECT * FROM Arbitro";
                SqlCommand cmd_Noticias = new SqlCommand(query_TablaNoticias, conn);
                SqlDataReader dr = cmd_Noticias.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    textBoxes_arbitros[i].Text = Convert.ToString(dr[1]) + " " + Convert.ToString(dr[2]);
                    i++;
                }
            }
        }
        public void cargar_horas() {
            TextBox[] textBoxes_horas = new[] { TextBox_hora1, TextBox_hora2, TextBox_hora3, TextBox_hora4, TextBox_hora5, TextBox_hora6 };
            int hora = 13;
            for (int i = 0; i < 6; i++) {
                textBoxes_horas[i].Text = (hora + 1).ToString() + ":00 hs";
                hora += 1;
            }
        }
        public void mostrar_labels_textboxs() {
            Label[] labels_All = new[] { Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label11, Label12 };
            for (int i = 0; i < labels_All.Length; i++)
            {
                labels_All[i].Visible = true;
            }
            TextBox[] textBoxes_All = new[] { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12 };
            for (int i = 0; i < textBoxes_All.Length; i++)
            {
                textBoxes_All[i].Visible = true;
            }
        }
        public void agregar_partido(Partido partido_i) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();

                string query_InsertoPartido = "INSERT Partido(fecha_partido,hora_partido,lugar_partidod,id_equipo1,id_equipo2,id_arbitro) VALUES (@fecha_partido,@hora_partido,@lugar_partidod,@id_equipo1,@id_equipo2,@id_arbitro)";
                SqlCommand cmd_InsertoPartido = new SqlCommand(query_InsertoPartido, conn);
                cmd_InsertoPartido.Parameters.AddWithValue("@fecha_partido", partido_i.Fecha.ToString());
                cmd_InsertoPartido.Parameters.AddWithValue("@hora_partido", partido_i.Hora.ToString());
                cmd_InsertoPartido.Parameters.AddWithValue("@lugar_partidod", partido_i.Lugar.ToString());
                cmd_InsertoPartido.Parameters.AddWithValue("@id_equipo1", buscar_id_equipo(partido_i.Equipo1).ToString());
                cmd_InsertoPartido.Parameters.AddWithValue("@id_equipo2", buscar_id_equipo(partido_i.Equipo2).ToString());
                cmd_InsertoPartido.Parameters.AddWithValue("@id_arbitro", buscar_id_arbitro(partido_i.Id_Arbitro).ToString());

                cmd_InsertoPartido.ExecuteNonQuery();
            }
        }
        public string buscar_id_equipo(string nombre_equipo) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();

                string query_BuscoIDequipo = "SELECT * FROM Equipo WHERE nombre_equipo=@nombre_equipo";
                SqlCommand cmd_BusoIDequipo = new SqlCommand(query_BuscoIDequipo, conn);
                cmd_BusoIDequipo.Parameters.AddWithValue("@nombre_equipo", nombre_equipo);
                SqlDataReader dr = cmd_BusoIDequipo.ExecuteReader();
                string id_equipo = "";
                while (dr.Read())
                {
                    id_equipo = Convert.ToString(dr[0]);
                }
                return id_equipo;
            }
        }
        public string buscar_id_arbitro(string nombre_arbitro)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();

                string query_BuscoIDarbitro = "SELECT * FROM Arbitro WHERE nombre_arbitro=@nombre_arbitro";
                SqlCommand cmd_BuscoIDarbitro = new SqlCommand(query_BuscoIDarbitro, conn);
                cmd_BuscoIDarbitro.Parameters.AddWithValue("@nombre_arbitro", nombre_arbitro);
                SqlDataReader dr = cmd_BuscoIDarbitro.ExecuteReader();
                string id_arbitro = "";
                while (dr.Read())
                {
                    id_arbitro = Convert.ToString(dr[0]);
                }
                return id_arbitro;
            }
        }
        public void visbilidad() {
            //ESTO PONER EN UNA FUNCION
            TextBox[] textBoxes = new[] { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12, TextBox_1_1, TextBox_1_2, TextBox_1_3, TextBox_1_4, TextBox_1_5, TextBox_1_6, TextBox_dia1, TextBox_dia2, TextBox_dia3, TextBox_dia4, TextBox_dia5, TextBox_dia6, TextBox_hora1, TextBox_hora2, TextBox_hora3, TextBox_hora4, TextBox_hora5, TextBox_hora6, TextBox_cancha1, TextBox_cancha2, TextBox_cancha3, TextBox_cancha4, TextBox_cancha5, TextBox_cancha6, TextBox_arbitro1, TextBox_arbitro2, TextBox_arbitro3, TextBox_arbitro4, TextBox_arbitro5, TextBox_arbitro6 };
            for (int i = 0; i < 12; i++)
            {
                textBoxes[i].Visible = false;
            }
            for (int i = 12; i < textBoxes.Length; i++)
            {
                textBoxes[i].Visible = true;
            }


            //Cambio "Equipo x:" por Fecha x:
            Label[] labels = new[] {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label11, Label12 };
            for (int i = 0; i < 6; i++)
            {
                labels[i].Visible = true;
                labels[i].Text = "Partido " + (i + 1).ToString() + " :";
            }
            for (int i = 6; i < labels.Length; i++)
            {
                labels[i].Visible = false;
            }
            Label_Fecha.Visible = true;
            Label_partido.Visible = true;
            Label_dia.Visible = true;
            Label_hora.Visible = true;
            Label_cancha.Visible = true;
            Label_arbitro.Visible = true;


            //HASTA ACA
        }
        public void cargar_tabla_fixture() {

            Table_Fixture.Controls.Clear();
           
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();
                string query_TablaFixture_cantidad = "SELECT count(1) FROM Partido";
                SqlCommand cmd_Partidos_cantidad = new SqlCommand(query_TablaFixture_cantidad, conn);
                int cantidad_partidos = Convert.ToInt32(cmd_Partidos_cantidad.ExecuteScalar());

                string query_Partidos = "select id_partido, fecha_partido, hora_partido, lugar_partidod, e1.nombre_equipo, e2.nombre_equipo, (Arbitro.nombre_arbitro+' '+Arbitro.apellido_arbitro) from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2 inner join Arbitro on Partido.id_arbitro=Arbitro.id_arbitro order by id_partido asc";
                SqlCommand cmd_Partidos = new SqlCommand(query_Partidos, conn);
                SqlDataReader dr = cmd_Partidos.ExecuteReader();
                int cantidad_fechas=1;

                while ((cantidad_partidos/6)>0) {
                    //FECHA
                    TableRow row_fecha = new TableRow();
                    TableCell cell_fecha = new TableCell();
                    cell_fecha.Text = "Fecha " + Convert.ToString(cantidad_fechas);
                    cell_fecha.Attributes["class"] = "cssFecha";
                    row_fecha.Cells.Add(cell_fecha);
                    Table_Fixture.Rows.Add(row_fecha);
                    //TITULOS
                    TableRow row_titulos = new TableRow();
                    TableCell cell_dia = new TableCell();
                    cell_dia.Text = "DIA";
                    cell_dia.Attributes["class"] = "h3dia";
                    TableCell cell_hora = new TableCell();
                    cell_hora.Text = "HORA";
                    cell_hora.Attributes["class"] = "h3hora";
                    TableCell cell_lugar = new TableCell();
                    cell_lugar.Text = "LUGAR";
                    cell_lugar.Attributes["class"] = "h3lugar";
                    TableCell cell_partido = new TableCell();
                    cell_partido.Text = "PARTIDO";
                    cell_partido.Attributes["class"] = "h3partido";
                    TableCell cell_arbitro = new TableCell();
                    cell_arbitro.Text = "ARBITRO";
                    cell_arbitro.Attributes["class"] = "h3arbitro";
                    row_titulos.Cells.Add(cell_dia);
                    row_titulos.Cells.Add(cell_hora);
                    row_titulos.Cells.Add(cell_lugar);
                    row_titulos.Cells.Add(cell_partido);
                    row_titulos.Cells.Add(cell_arbitro);
                    Table_Fixture.Rows.Add(row_titulos);

                    for (int j = 0; j < 6; j++)
                    {
                        if (dr.Read()) {
                            TableRow row = new TableRow();
                            TableCell cell1 = new TableCell();
                            TableCell cell2 = new TableCell();
                            TableCell cell3 = new TableCell();
                            TableCell cell4 = new TableCell();
                            TableCell cell5 = new TableCell();
                            TableCell cell6 = new TableCell();
                            cell1.Text = Convert.ToString(dr[1]);//Aca va la fecha del partido
                            cell2.Text = Convert.ToString(dr[2]); //Aca va la hora del partido
                            cell3.Text = Convert.ToString(dr[3]); //Aca va la cancha del partido
                            cell4.Text = Convert.ToString(dr[4]); //Aca va el NOMBRE del equipo 1
                            cell5.Text = Convert.ToString(dr[5]); //Aca va el NOMBRE del equipo 2
                            cell6.Text = Convert.ToString(dr[6]); //Aca va el NOMBRE y APELLIDO del arbitro
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                            row.Cells.Add(cell3);
                            row.Cells.Add(cell4);
                            row.Cells.Add(cell5);
                            row.Cells.Add(cell6);
                            row.Attributes["class"] = "cssFila";
                            Table_Fixture.Rows.Add(row);
                        }
                    }
                    cantidad_fechas++;
                    cantidad_partidos=cantidad_partidos-6;
                }
            }
        }
        public void borrar_partidos() {
            Table_Fixture.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();

                string query_BorroPartidos = "DELETE Partido";
                SqlCommand cmd_BorroPartidos = new SqlCommand(query_BorroPartidos, conn);
                cmd_BorroPartidos.ExecuteNonQuery();
                string query_reseteoIDPartido = "DBCC CHECKIDENT ('Partido', RESEED, 0)";
                SqlCommand cmd_reseteoIDPartido = new SqlCommand(query_reseteoIDPartido, conn);
                cmd_reseteoIDPartido.ExecuteNonQuery();
            }

        }
        public void borrar_puntos() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();

                string query_BorroPuntos = "update Equipo set puntos_equipo=0";
                SqlCommand cmd_BorroPuntos = new SqlCommand(query_BorroPuntos, conn);
                cmd_BorroPuntos.ExecuteNonQuery();
            }
        }
        public void borrar_datos_jug()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();

                string query_BorroJugadores = "update Jugador set goles_jugador=0, amarillas_jugador=0, rojas_jugador=0";
                SqlCommand cmd_BorroJugadores = new SqlCommand(query_BorroJugadores, conn);
                cmd_BorroJugadores.ExecuteNonQuery();
            }
        }
    }
}