using iText.Kernel.Colors;
using iTextSharp.text;

using iTextSharp.text.pdf;
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
    public partial class Resultados : System.Web.UI.Page
    {
        //EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Administrador.administrador_conectado) {
                Button_CargarRdos.Visible = true;
                LinkButton3.Visible=true;
            }
            if (!Page.IsPostBack) {
                //Cargo el listBox con las fechas posibles
                DropDownList_Fecha.Items.Insert(0, "Elija una fecha");
                DropDownList_Fecha.Items[0].Attributes["disabled"] = "disabled";
                
                for (int i = 0; i < cantidad_equipos() - 1; i++)
                {
                    DropDownList_Fecha.Items.Add((i + 1).ToString());
                    DropDownList_Fecha.Items[i].Enabled = true;
                    DropDownList_Fecha.Items[i].Selected = false;
                }
            }
            //Oculto los otros divs
            div_Partido.Visible = false;
            div_Rdo.Visible = false;
            div_Goles.Visible = false;
            div_Amarillas.Visible = false;
            div_Rojas.Visible = false;
            cargar_tabla_resultados();
        }
        protected void Button_CargarRdos_Click(object sender, EventArgs e)
        {
            Label_Fecha.Visible = true;
            DropDownList_Fecha.Visible = true;
        }

        protected void DropDownList_Fecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_Rdo.Visible = true;
            Label_Fecha.Visible = true;
            cargar_partidos(Convert.ToInt32(DropDownList_Fecha.SelectedValue));
            div_Partido.Visible = true;
        }
        protected void DropDownList_Partido_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label_Fecha.Visible = true;
            DropDownList_Fecha.Visible = true;
            div_Rdo.Visible = true;
            div_Partido.Visible = true;
            Label_RdoE1.Visible = true;
            Label_RdoE2.Visible = true;
            string partido = Convert.ToString(DropDownList_Partido.SelectedValue);
            Label_GolesE1.Text= partido.Substring(0, (partido.IndexOf(" vs. "))).Trim();
            Label_GolesE2.Text= (partido.Substring(partido.LastIndexOf("vs. ") + 3, partido.Length - (partido.IndexOf("vs. ") + 3))).Trim();
            Label_RdoE1.Text = partido.Substring(0,(partido.IndexOf(" vs. "))).Trim();
            Label_RdoE2.Text = (partido.Substring(partido.LastIndexOf("vs. ") + 3, partido.Length - (partido.IndexOf("vs. ") + 3))).Trim();
            Label_AE1.Text = (partido.Substring(0, (partido.IndexOf(" vs. ")))).Trim();
            Label_AE2.Text = (partido.Substring(partido.LastIndexOf("vs. ") + 3, partido.Length - (partido.IndexOf("vs. ") + 3))).Trim();
            Label_RE1.Text = (partido.Substring(0, (partido.IndexOf(" vs. ")))).Trim();
            Label_RE2.Text = (partido.Substring(partido.LastIndexOf("vs. ") + 3, partido.Length - (partido.IndexOf("vs. ") + 3))).Trim();
            TextBox_Rdo1.Text = "";
            TextBox_Rdo2.Text = "";

            //Equipo 1=(Convert.ToString(DropDownList_Partido.SelectedValue)).Substring(0, ((Convert.ToString(DropDownList_Partido.SelectedValue)).IndexOf(" vs. "))).Trim()
            //Equipo 2= (Convert.ToString(DropDownList_Partido.SelectedValue)).Substring((Convert.ToString(DropDownList_Partido.SelectedValue)).LastIndexOf("vs. ") + 3, (Convert.ToString(DropDownList_Partido.SelectedValue)).Length - ((Convert.ToString(DropDownList_Partido.SelectedValue)).IndexOf("vs. ") + 3))).Trim()

        }
        protected void TextBox_Rdo2_TextChanged(object sender, EventArgs e)
        {

            if (!(TextBox_Rdo1.Text == ""))
            {
                div_Partido.Visible = true;
                
                div_Rdo.Visible = true;
                div_Amarillas.Visible = true;
                div_Rojas.Visible = true;
                Button_CargarTablaDatos.Visible = true;
                
                cargar_apellidos_nombres_equipo(Label_RdoE1.Text, DropDownList_Goles1);
                cargar_apellidos_nombres_equipo(Label_RdoE2.Text, DropDownList_Goles2);
                cargar_apellidos_nombres_equipo(Label_AE1.Text, DropDownList_A1);
                cargar_apellidos_nombres_equipo(Label_AE2.Text, DropDownList_A2);
                cargar_apellidos_nombres_equipo(Label_RE1.Text, DropDownList_R1);
                cargar_apellidos_nombres_equipo(Label_RE2.Text, DropDownList_R2);
                if (!(TextBox_Rdo1.Text=="0" && TextBox_Rdo2.Text == "0")) {
                    div_Goles.Visible = true;
                }
            }
        }
        protected void DropDownList_Goles1_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_Rdo.Visible = true;
            div_Partido.Visible = true;
            div_Goles.Visible = true;
            div_Amarillas.Visible = true;
            div_Rojas.Visible = true;
            Button_CargarTablaDatos.Visible = true;
            if (!(TextBox_Rdo1.Text == "0" && TextBox_Rdo2.Text == "0"))
            {
                div_Goles.Visible = true;
            }
            //LabelGolesDe1.Text = LabelGolesDe1.Text + (((DropDownList_Goles1.SelectedValue).Substring(((DropDownList_Goles1.SelectedValue).IndexOf(",") + 2), ((DropDownList_Goles1.SelectedValue).Length) - ((DropDownList_Goles1.SelectedValue).IndexOf(",") + 2)))) +" ";
            LabelGolesDe1.Text = LabelGolesDe1.Text + ((DropDownList_Goles1.SelectedValue).Substring(0, (DropDownList_Goles1.SelectedValue).IndexOf(",")))+", ";

            actualizar_goles((((DropDownList_Goles1.SelectedValue).Substring(((DropDownList_Goles1.SelectedValue).IndexOf(",") + 2), ((DropDownList_Goles1.SelectedValue).Length) - ((DropDownList_Goles1.SelectedValue).IndexOf(",") + 2)))), ((DropDownList_Goles1.SelectedValue).Substring(0, (DropDownList_Goles1.SelectedValue).IndexOf(","))));

            DropDownList_Goles1.SelectedIndex = 0;
        }
        protected void DropDownList_Goles2_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_Rdo.Visible = true;
            div_Partido.Visible = true;
            div_Goles.Visible = true;
            div_Amarillas.Visible = true;
            div_Rojas.Visible = true;
            Button_CargarTablaDatos.Visible = true;
            if (!(TextBox_Rdo1.Text == "0" && TextBox_Rdo2.Text == "0"))
            {
                div_Goles.Visible = true;
            }
            LabelGolesDe2.Text = LabelGolesDe2.Text + ((DropDownList_Goles2.SelectedValue).Substring(0, (DropDownList_Goles2.SelectedValue).IndexOf(","))) + ", ";
            actualizar_goles((((DropDownList_Goles2.SelectedValue).Substring(((DropDownList_Goles2.SelectedValue).IndexOf(",") + 2), ((DropDownList_Goles2.SelectedValue).Length) - ((DropDownList_Goles2.SelectedValue).IndexOf(",") + 2)))), ((DropDownList_Goles2.SelectedValue).Substring(0, (DropDownList_Goles2.SelectedValue).IndexOf(","))));

            DropDownList_Goles2.SelectedIndex = 0;
        }
        protected void DropDownList_A1_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_Rdo.Visible = true;
            div_Partido.Visible = true;
            div_Goles.Visible = true;
            div_Amarillas.Visible = true;
            div_Rojas.Visible = true;
            Button_CargarTablaDatos.Visible = true;
            if (!(TextBox_Rdo1.Text == "0" && TextBox_Rdo2.Text == "0"))
            {
                div_Goles.Visible = true;
            }
            Label3.Text = Label3.Text + ((DropDownList_A1.SelectedValue).Substring(0, (DropDownList_A1.SelectedValue).IndexOf(","))) + ", ";
            actualizar_amarillas((((DropDownList_A1.SelectedValue).Substring(((DropDownList_A1.SelectedValue).IndexOf(",") + 2), ((DropDownList_A1.SelectedValue).Length) - ((DropDownList_A1.SelectedValue).IndexOf(",") + 2)))), ((DropDownList_A1.SelectedValue).Substring(0, (DropDownList_A1.SelectedValue).IndexOf(","))));

            DropDownList_A1.SelectedIndex = 0;
        }
        protected void DropDownList_A2_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_Rdo.Visible = true;
            div_Partido.Visible = true;
            div_Goles.Visible = true;
            div_Amarillas.Visible = true;
            div_Rojas.Visible = true;
            Button_CargarTablaDatos.Visible = true;
            if (!(TextBox_Rdo1.Text == "0" && TextBox_Rdo2.Text == "0"))
            {
                div_Goles.Visible = true;
            }
            Label4.Text = Label4.Text + ((DropDownList_A2.SelectedValue).Substring(0, (DropDownList_A2.SelectedValue).IndexOf(","))) + ", ";
            actualizar_amarillas((((DropDownList_A2.SelectedValue).Substring(((DropDownList_A2.SelectedValue).IndexOf(",") + 2), ((DropDownList_A2.SelectedValue).Length) - ((DropDownList_A2.SelectedValue).IndexOf(",") + 2)))), ((DropDownList_A2.SelectedValue).Substring(0, (DropDownList_A2.SelectedValue).IndexOf(","))));

            DropDownList_A2.SelectedIndex = 0;
        }
        protected void DropDownList_R1_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_Rdo.Visible = true;
            div_Partido.Visible = true;
            div_Goles.Visible = true;
            div_Amarillas.Visible = true;
            div_Rojas.Visible = true;
            Button_CargarTablaDatos.Visible = true;
            if (!(TextBox_Rdo1.Text == "0" && TextBox_Rdo2.Text == "0"))
            {
                div_Goles.Visible = true;
            }
            Label7.Text = Label7.Text + ((DropDownList_R1.SelectedValue).Substring(0, (DropDownList_R1.SelectedValue).IndexOf(","))) + ", ";
            actualizar_rojas((((DropDownList_R1.SelectedValue).Substring(((DropDownList_R1.SelectedValue).IndexOf(",") + 2), ((DropDownList_R1.SelectedValue).Length) - ((DropDownList_R1.SelectedValue).IndexOf(",") + 2)))), ((DropDownList_R1.SelectedValue).Substring(0, (DropDownList_R1.SelectedValue).IndexOf(","))));

            DropDownList_R1.SelectedIndex = 0; 
        }
        protected void DropDownList_R2_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_Rdo.Visible = true;
            div_Partido.Visible = true;
            div_Goles.Visible = true;
            div_Amarillas.Visible = true;
            div_Rojas.Visible = true;
            Button_CargarTablaDatos.Visible = true;
            if (!(TextBox_Rdo1.Text == "0" && TextBox_Rdo2.Text == "0"))
            {
                div_Goles.Visible = true;
            }
            Label8.Text = Label8.Text + ((DropDownList_R2.SelectedValue).Substring(0, (DropDownList_R2.SelectedValue).IndexOf(","))) + ", ";
            actualizar_rojas((((DropDownList_R2.SelectedValue).Substring(((DropDownList_R2.SelectedValue).IndexOf(",") + 2), ((DropDownList_R2.SelectedValue).Length) - ((DropDownList_R2.SelectedValue).IndexOf(",") + 2)))), ((DropDownList_R2.SelectedValue).Substring(0, (DropDownList_R2.SelectedValue).IndexOf(","))));

            DropDownList_R2.SelectedIndex = 0;
        }
        protected void Button_CargarTablaDatos_Click(object sender, EventArgs e)
        {
            div_Partido.Visible = true;
            
            Button_CargarTablaDatos.Visible = true;
            guardar_rdos();
            cargar_tabla_resultados();

            LabelGolesDe1.Text = "";
            LabelGolesDe2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label7.Text = "";
            Label8.Text = "";

            
            
            
        }

        //FUNCIONES
        //Función que retorna la cantidad de equipos cargados en la Bdd
        public int cantidad_equipos()
        {
            int cantidad_equipos = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();
                string query_cantidad_equipos = "SELECT count(1) FROM Equipo";
                SqlCommand cmd_quipos_cantidad = new SqlCommand(query_cantidad_equipos, conn);
                cantidad_equipos= Convert.ToInt32(cmd_quipos_cantidad.ExecuteScalar());
            }
            return cantidad_equipos;
        }
        //Procedimiento para cargar los partidos que correspondan a la fecha "i"
        public void cargar_partidos(int fecha) {

            DropDownList_Partido.Items.Clear();
            DropDownList_Partido.Items.Insert(0, "Seleccione un partido de la fecha ");
            DropDownList_Partido.Items[0].Attributes["disabled"] = "disabled";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                
                switch (fecha)
                {
                    
                    case 1:
                        string query_enfrentamientos_equipos_1 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido<7  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_1 = new SqlCommand(query_enfrentamientos_equipos_1, conn);
                        SqlDataReader dr_1 = cmd_enfrentamientos_equipos_1.ExecuteReader();
                        while (dr_1.Read()) {
                            DropDownList_Partido.Items.Add(dr_1[0].ToString() + " vs. " + dr_1[1].ToString());
                        }
                        break;
                    
                    case 2:
                        string query_enfrentamientos_equipos_2 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>6 and id_partido<13  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_2 = new SqlCommand(query_enfrentamientos_equipos_2, conn);
                        SqlDataReader dr_2 = cmd_enfrentamientos_equipos_2.ExecuteReader();
                        while (dr_2.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_2[0].ToString() + " vs. " + dr_2[1].ToString());
                        }
                        break;
                    case 3:
                        string query_enfrentamientos_equipos_3 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>18 and id_partido<25  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_3 = new SqlCommand(query_enfrentamientos_equipos_3, conn);
                        SqlDataReader dr_3 = cmd_enfrentamientos_equipos_3.ExecuteReader();
                        while (dr_3.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_3[0].ToString() + " vs. " + dr_3[1].ToString());
                        }
                        break;
                    case 4:
                        string query_enfrentamientos_equipos_4 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>24 and id_partido<31  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_4 = new SqlCommand(query_enfrentamientos_equipos_4, conn);
                        SqlDataReader dr_4 = cmd_enfrentamientos_equipos_4.ExecuteReader();
                        while (dr_4.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_4[0].ToString() + " vs. " + dr_4[1].ToString());
                        }
                        break;
                    case 5:
                        string query_enfrentamientos_equipos_5 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>24 and id_partido<31  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_5 = new SqlCommand(query_enfrentamientos_equipos_5, conn);
                        SqlDataReader dr_5 = cmd_enfrentamientos_equipos_5.ExecuteReader();
                        while (dr_5.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_5[0].ToString() + " vs. " + dr_5[1].ToString());
                        }
                        break;
                    case 6:
                        string query_enfrentamientos_equipos_6 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>30 and id_partido<37  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_6 = new SqlCommand(query_enfrentamientos_equipos_6, conn);
                        SqlDataReader dr_6 = cmd_enfrentamientos_equipos_6.ExecuteReader();
                        while (dr_6.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_6[0].ToString() + " vs. " + dr_6[1].ToString());
                        }
                        break;
                    case 7:
                        string query_enfrentamientos_equipos_7 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>36 and id_partido<43  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_7 = new SqlCommand(query_enfrentamientos_equipos_7, conn);
                        SqlDataReader dr_7 = cmd_enfrentamientos_equipos_7.ExecuteReader();
                        while (dr_7.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_7[0].ToString() + " vs. " + dr_7[1].ToString());
                        }
                        break;
                    case 8:
                        string query_enfrentamientos_equipos_8 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>42 and id_partido<49  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_8 = new SqlCommand(query_enfrentamientos_equipos_8, conn);
                        SqlDataReader dr_8 = cmd_enfrentamientos_equipos_8.ExecuteReader();
                        while (dr_8.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_8[0].ToString() + " vs. " + dr_8[1].ToString());
                        }
                        break;
                    case 9:
                        string query_enfrentamientos_equipos_9 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>48 and id_partido<55  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_9 = new SqlCommand(query_enfrentamientos_equipos_9, conn);
                        SqlDataReader dr_9 = cmd_enfrentamientos_equipos_9.ExecuteReader();
                        while (dr_9.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_9[0].ToString() + " vs. " + dr_9[1].ToString());
                        }
                        break;
                    case 10:
                        string query_enfrentamientos_equipos_10 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>54 and id_partido<61  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_10 = new SqlCommand(query_enfrentamientos_equipos_10, conn);
                        SqlDataReader dr_10 = cmd_enfrentamientos_equipos_10.ExecuteReader();
                        while (dr_10.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_10[0].ToString() + " vs. " + dr_10[1].ToString());
                        }
                        break;
                    case 11:
                        string query_enfrentamientos_equipos_11 = "select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>60  order by id_partido asc";
                        SqlCommand cmd_enfrentamientos_equipos_11 = new SqlCommand(query_enfrentamientos_equipos_11, conn);
                        SqlDataReader dr_11 = cmd_enfrentamientos_equipos_11.ExecuteReader();
                        while (dr_11.Read())
                        {
                            DropDownList_Partido.Items.Add(dr_11[0].ToString() + " vs. " + dr_11[1].ToString());
                        }
                        break;
                }
            }
        }
        //Funcion para cargar los apellidos y los nombres de los jugadores del equipo en cuestion
        public void cargar_apellidos_nombres_equipo(string equipo, DropDownList dropDownList) {
            dropDownList.Items.Clear();
            dropDownList.Items.Insert(0, "Seleccione jugador/es de "+equipo);
            dropDownList.Items[0].Attributes["disabled"] = "disabled";
            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();
                string query_apellido_nombre = "select apellido_jugador, nombre_jugador from Jugador inner join Equipo on Jugador.id_equipo=Equipo.id_equipo where nombre_equipo=@nombre_equipo";
                SqlCommand cmd_apellido_nombre = new SqlCommand(query_apellido_nombre, conn);
                cmd_apellido_nombre.Parameters.AddWithValue("@nombre_equipo", equipo);
                SqlDataReader dr = cmd_apellido_nombre.ExecuteReader();
                while (dr.Read()) {
                    dropDownList.Items.Add(dr[0]+", "+dr[1]);
                }
            }
        }
        public void guardar_rdos() {
            //Resultado
            string resultado = Convert.ToString(DropDownList_Partido.SelectedValue).Substring(0, (Convert.ToString(DropDownList_Partido.SelectedValue).IndexOf(" vs. "))).Trim() +"  "+ TextBox_Rdo1.Text + " - " + TextBox_Rdo2.Text +"  "+ (Convert.ToString(DropDownList_Partido.SelectedValue).Substring(Convert.ToString(DropDownList_Partido.SelectedValue).LastIndexOf("vs. ") + 3, Convert.ToString(DropDownList_Partido.SelectedValue).Length - (Convert.ToString(DropDownList_Partido.SelectedValue).IndexOf("vs. ") + 3))).Trim(); ;
            //Goles
            //String goles_realizados = chequear_string_vacio_f(LabelGolesDe1.Text, LabelGolesDe2.Text);
            string goles_realizados1 = eliminar_ultima_coma(LabelGolesDe1.Text);
            string goles_realizados2 = eliminar_ultima_coma(LabelGolesDe2.Text);
            //Amonestados
            string amonestados1 = eliminar_ultima_coma(Label3.Text);
            string amonesados2 = eliminar_ultima_coma(Label4.Text);
            //Expulsados
            string expulsados1 = eliminar_ultima_coma(Label7.Text);
            string expulsados2 = eliminar_ultima_coma(Label8.Text);

            //string nombre_equipo_1= Convert.ToString(DropDownList_Partido.SelectedValue).Substring(0, (Convert.ToString(DropDownList_Partido.SelectedValue).IndexOf(" vs. "))).Trim();
            //string nombre_equipo_2 = (Convert.ToString(DropDownList_Partido.SelectedValue).Substring(Convert.ToString(DropDownList_Partido.SelectedValue).LastIndexOf("vs. ") + 3, Convert.ToString(DropDownList_Partido.SelectedValue).Length - (Convert.ToString(DropDownList_Partido.SelectedValue).IndexOf("vs. ") + 3))).Trim();
                       
            //Los cargo en la base de datos
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_InsertarRDO_Partidos = "UPDATE Partido SET resultado_partido=@rdo_partido , Amonestados=@amonestados , Expulsados=@expulsados , GolesRealizados=@goles_realizados WHERE id_equipo1=@id_equipo1 AND id_equipo2=@id_equipo2";
                SqlCommand cmd_InsertarRDO_Partidos = new SqlCommand(query_InsertarRDO_Partidos, conn);
                cmd_InsertarRDO_Partidos.Parameters.AddWithValue("@rdo_partido", resultado);
                cmd_InsertarRDO_Partidos.Parameters.AddWithValue("@amonestados", (string_vacio(amonestados1) + " - " + string_vacio(amonesados2)).ToString());
                cmd_InsertarRDO_Partidos.Parameters.AddWithValue("@expulsados", (string_vacio(expulsados1) + " - " + string_vacio(expulsados2)).ToString());
                cmd_InsertarRDO_Partidos.Parameters.AddWithValue("@goles_realizados", (string_vacio(goles_realizados1) + " - "+ string_vacio(goles_realizados2)).ToString());
                cmd_InsertarRDO_Partidos.Parameters.AddWithValue("@id_equipo1", buscar_id_equipo(Convert.ToString(DropDownList_Partido.SelectedValue).Substring(0, (Convert.ToString(DropDownList_Partido.SelectedValue).IndexOf(" vs. "))).Trim()));
                cmd_InsertarRDO_Partidos.Parameters.AddWithValue("@id_equipo2", buscar_id_equipo((Convert.ToString(DropDownList_Partido.SelectedValue).Substring(Convert.ToString(DropDownList_Partido.SelectedValue).LastIndexOf("vs. ") + 3, Convert.ToString(DropDownList_Partido.SelectedValue).Length - (Convert.ToString(DropDownList_Partido.SelectedValue).IndexOf("vs. ") + 3))).Trim()));
                
                cmd_InsertarRDO_Partidos.ExecuteNonQuery();
            }
            //Cargo en la bdd los puntos del equipo ganador
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                if (Convert.ToInt32(TextBox_Rdo1.Text) > Convert.ToInt32(TextBox_Rdo2.Text)) {
                    string query_InsertarPuntos = "update Equipo set puntos_equipo=puntos_equipo+3 where nombre_equipo=@nombre_equipo";
                    SqlCommand cmd_InsertarPuntos = new SqlCommand(query_InsertarPuntos, conn);
                    cmd_InsertarPuntos.Parameters.AddWithValue("@nombre_equipo", (Convert.ToString(DropDownList_Partido.SelectedValue)).Substring(0, ((Convert.ToString(DropDownList_Partido.SelectedValue)).IndexOf(" vs. "))).Trim());
                    cmd_InsertarPuntos.ExecuteNonQuery();
                }
                else if (Convert.ToInt32(TextBox_Rdo1.Text) < Convert.ToInt32(TextBox_Rdo2.Text)) {
                    string query_InsertarPuntos = "update Equipo set puntos_equipo=puntos_equipo+3 where nombre_equipo=@nombre_equipo";
                    SqlCommand cmd_InsertarPuntos = new SqlCommand(query_InsertarPuntos, conn);
                    cmd_InsertarPuntos.Parameters.AddWithValue("@nombre_equipo", (Convert.ToString(DropDownList_Partido.SelectedValue)).Substring((Convert.ToString(DropDownList_Partido.SelectedValue)).LastIndexOf("vs. ") + 3, (Convert.ToString(DropDownList_Partido.SelectedValue)).Length - ((Convert.ToString(DropDownList_Partido.SelectedValue)).IndexOf("vs. ") + 3)).Trim());
                    cmd_InsertarPuntos.ExecuteNonQuery();
                }
                else if(Convert.ToInt32(TextBox_Rdo1.Text) == Convert.ToInt32(TextBox_Rdo2.Text))
                {
                    string query_InsertarPuntos = "update Equipo set puntos_equipo=puntos_equipo+1 where nombre_equipo=@nombre_equipo or nombre_equipo=@nombre_equip";
                    SqlCommand cmd_InsertarPuntos = new SqlCommand(query_InsertarPuntos, conn);
                    cmd_InsertarPuntos.Parameters.AddWithValue("@nombre_equipo", (Convert.ToString(DropDownList_Partido.SelectedValue)).Substring(0, ((Convert.ToString(DropDownList_Partido.SelectedValue)).IndexOf(" vs. "))).Trim());
                    cmd_InsertarPuntos.Parameters.AddWithValue("@nombre_equip", (Convert.ToString(DropDownList_Partido.SelectedValue)).Substring((Convert.ToString(DropDownList_Partido.SelectedValue)).LastIndexOf("vs. ") + 3, (Convert.ToString(DropDownList_Partido.SelectedValue)).Length - ((Convert.ToString(DropDownList_Partido.SelectedValue)).IndexOf("vs. ") + 3)).Trim());
                    cmd_InsertarPuntos.ExecuteNonQuery();
                }
               
            }
        }
        
        public string eliminar_ultima_coma(string string_guion) {
            if (string_guion == "")
            {
                return string_guion;
            }
            else {
                return string_guion.Substring(0, (string_guion.Length - 2));
            }    
        }
        public string string_vacio(string s) {
            if (s == "")
            {
                return ".";
            }
            else {
                return s;
            }
        }
        
        /*
        public string chequear_string_vacio_f(string s1, string s2) {
            if (s1 == "" && s2 == "") {
                return "";
            }
            else if (s1 == "" && s2 != "") {
                return s2;
            }
            else if (s1 != "" && s2== "") {
                return s1;
            }
            else{
                return s1+", "+s2;
            }
        }
        */
        public int buscar_id_equipo(string nombre_equipo) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();

                string query_BuscoIDequipo = "SELECT * FROM Equipo WHERE nombre_equipo=@nombre_equipo";
                SqlCommand cmd_BusoIDequipo = new SqlCommand(query_BuscoIDequipo, conn);
                cmd_BusoIDequipo.Parameters.AddWithValue("@nombre_equipo", nombre_equipo);
                SqlDataReader dr = cmd_BusoIDequipo.ExecuteReader();
                int id_equipo = 0;
                while (dr.Read())
                {
                    id_equipo = Convert.ToInt32(dr[0]);
                }
                return id_equipo;
            }
        }
        public void cargar_tabla_resultados() {
    
            Table_Rdos.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_TablaPartidos_cantidad = "SELECT count(1) FROM Partido";
                SqlCommand cmd_TablaPartidos_cantidad = new SqlCommand(query_TablaPartidos_cantidad, conn);
                int cantidad_partidos = Convert.ToInt32(cmd_TablaPartidos_cantidad.ExecuteScalar());
                
                string query_Rdo_Partidos = "select id_partido, resultado_partido, GolesRealizados, Amonestados, Expulsados from Partido where resultado_partido is not null order by id_partido asc";
                SqlCommand cmd_RdoPartidos = new SqlCommand(query_Rdo_Partidos, conn);
                SqlDataReader dr = cmd_RdoPartidos.ExecuteReader();

                while(dr.Read()){
                    if (dr[0].ToString()=="1" || dr[0].ToString() == "7" || dr[0].ToString() == "13" || dr[0].ToString() == "19" || dr[0].ToString() == "25" || dr[0].ToString() == "31" || dr[0].ToString() == "37" || dr[0].ToString() == "43" || dr[0].ToString() == "49" || dr[0].ToString() == "55" || dr[0].ToString() == "61") {
                        TableRow row_fecha = new TableRow();
                        TableCell cell_fecha = new TableCell();
                        switch (dr[0].ToString()) {
                            case "1":
                                cell_fecha.Text = "Fecha 1";
                                break;
                            case "7":
                                cell_fecha.Text = "Fecha 2";
                                break;
                            case "13":
                                cell_fecha.Text = "Fecha 3";
                                break;
                            case "19":
                                cell_fecha.Text = "Fecha 4";
                                break;
                            case "25":
                                cell_fecha.Text = "Fecha 5";
                                break;
                            case "31":
                                cell_fecha.Text = "Fecha 6";
                                break;
                            case "37":
                                cell_fecha.Text = "Fecha 7";
                                break;
                            case "43":
                                cell_fecha.Text = "Fecha 8";
                                break;
                            case "49":
                                cell_fecha.Text = "Fecha 9";
                                break;
                            case "55":
                                cell_fecha.Text = "Fecha 10";
                                break;
                            case "61":
                                cell_fecha.Text = "Fecha 11";
                                break;
                        }
                        
                        cell_fecha.Attributes["class"]="cellfecha";
                        row_fecha.Cells.Add(cell_fecha);
                        Table_Rdos.Rows.Add(row_fecha);

                        TableRow row_titulos = new TableRow();
                        TableCell cell_resultado = new TableCell();
                        TableCell cell_goles = new TableCell();
                        TableCell cell_amarillas = new TableCell();
                        TableCell cell_expulsados = new TableCell();
                        cell_resultado.Text = "RESULTADO";
                        cell_goles.Text = "GOLES";
                        cell_amarillas.Text = "AMONESTADOS";
                        cell_expulsados.Text = "EXPULSADOS";
                        row_titulos.Cells.Add(cell_resultado);
                        row_titulos.Cells.Add(cell_goles);
                        row_titulos.Cells.Add(cell_amarillas);
                        row_titulos.Cells.Add(cell_expulsados);
                        row_titulos.Attributes["class"] = "cssNoticiaT";
                        Table_Rdos.Rows.Add(row_titulos);
                    }
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    TableCell cell5 = new TableCell();
                    cell1.Text = Convert.ToString(dr[1]);//Aca va el resultado del partido
                    cell2.Text = Convert.ToString(dr[2]); //Aca van los apellidos de los jugadores que hicieron los goles en los partidos
                    cell3.Text = Convert.ToString(dr[3]); //Aca van los apellidos de los jugadores que fueron amonestados en los partidos
                    cell4.Text = Convert.ToString(dr[4]); //Aca van los apellidos de los jugadores expulsados
                    cell1.Attributes["class"]= "cssCelda";
                    cell2.Attributes["class"] = "cssCelda";
                    cell3.Attributes["class"] = "cssCelda";
                    cell4.Attributes["class"] = "cssCelda";
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Attributes["class"] = "cssNoticia";
                    Table_Rdos.Rows.Add(row);
                }
            }
        }
        public void actualizar_goles(string nombre,string apellido) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();

                string query_ActualizoGoles = "update Jugador set goles_jugador=goles_jugador+1 where nombre_jugador=@nombre_jugador and apellido_jugador=@apellido_jugador";
                SqlCommand cmd_ActualizoGoles = new SqlCommand(query_ActualizoGoles, conn);
                cmd_ActualizoGoles.Parameters.AddWithValue("@nombre_jugador", nombre);
                cmd_ActualizoGoles.Parameters.AddWithValue("@apellido_jugador", apellido);
                cmd_ActualizoGoles.ExecuteNonQuery();

                string query_goles = "Select goles_jugador from Jugador where nombre_jugador=@nombre_jugador and apellido_jugador=@apellido_jugador ";
                SqlCommand cmd_Goles = new SqlCommand(query_goles, conn);
                cmd_Goles.Parameters.AddWithValue("@nombre_jugador", nombre);
                cmd_Goles.Parameters.AddWithValue("@apellido_jugador", apellido);
                SqlDataReader dr = cmd_Goles.ExecuteReader();
                if (dr.Read()) {
                    Jugador.goles_jugador = Convert.ToInt32( dr[0]);
                }
            }
        }
        public void actualizar_amarillas(string nombre, string apellido)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();

                string query_ActualizoAm = "update Jugador set amarillas_jugador=amarillas_jugador+1 where nombre_jugador=@nombre_jugador and apellido_jugador=@apellido_jugador";
                SqlCommand cmd_ActualizoAm = new SqlCommand(query_ActualizoAm, conn);
                cmd_ActualizoAm.Parameters.AddWithValue("@nombre_jugador", nombre);
                cmd_ActualizoAm.Parameters.AddWithValue("@apellido_jugador", apellido);
                cmd_ActualizoAm.ExecuteNonQuery();

                string query_am = "Select amarillas_jugador from Jugador where nombre_jugador=@nombre_jugador and apellido_jugador=@apellido_jugador ";
                SqlCommand cmd_am = new SqlCommand(query_am, conn);
                cmd_am.Parameters.AddWithValue("@nombre_jugador", nombre);
                cmd_am.Parameters.AddWithValue("@apellido_jugador", apellido);
                SqlDataReader dr = cmd_am.ExecuteReader();
                if (dr.Read())
                {
                    Jugador.amarillas_jugador = Convert.ToInt32(dr[0]);
                }
            }
        }
        public void actualizar_rojas(string nombre, string apellido)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();

                string query_ActualizoRojas = "update Jugador set rojas_jugador=rojas_jugador+1 where nombre_jugador=@nombre_jugador and apellido_jugador=@apellido_jugador";
                SqlCommand cmd_ActualizoRojas = new SqlCommand(query_ActualizoRojas, conn);
                cmd_ActualizoRojas.Parameters.AddWithValue("@nombre_jugador", nombre);
                cmd_ActualizoRojas.Parameters.AddWithValue("@apellido_jugador", apellido);
                cmd_ActualizoRojas.ExecuteNonQuery();

                string query_rojas = "Select rojas_jugador from Jugador where nombre_jugador=@nombre_jugador and apellido_jugador=@apellido_jugador ";
                SqlCommand cmd_rojas = new SqlCommand(query_rojas, conn);
                cmd_rojas.Parameters.AddWithValue("@nombre_jugador", nombre);
                cmd_rojas.Parameters.AddWithValue("@apellido_jugador", apellido);
                SqlDataReader dr = cmd_rojas.ExecuteReader();
                if (dr.Read())
                {
                    Jugador.rojas_jugador = Convert.ToInt32(dr[0]);
                }
            }
        }

        /* ----------LINK BUTTONS Y SUS RESPECTIVAS FUNCIONES PARA CREAR PDFs---------- */
        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            crear_tablaposiciones();
        }
        public  void crear_tablaposiciones() 
        {
           
            /*Creating iTextSharp’s Document & Writer*/
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            Paragraph para = new Paragraph("Tabla de posiciones del torneo Fanas F11'", new Font(Font.FontFamily.HELVETICA, 22, Font.BOLD));
            
            para.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(para);

            /*Se crea la tabla*/
            
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage =50f;
            table.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.SpacingBefore = 50f;
            table.SpacingAfter = 10f;           
            table.HeaderRows = 1;
            

            Paragraph para_E = new Paragraph("Equipo", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            //para_E.IndentationLeft =80;
            para_E.Alignment = Element.ALIGN_CENTER;
            PdfPCell cell_E = new PdfPCell();

            //cell_E.Border = 0;
            cell_E.BorderWidthTop = 0;
            //cell_E .HorizontalAlignment = 0;
            cell_E.AddElement(para_E);
            cell_E.PaddingTop = 15f;
            cell_E.PaddingBottom = 15f;
            cell_E.BorderColorTop = BaseColor.WHITE;
            cell_E.BorderColorLeft = BaseColor.WHITE;
            cell_E.BorderColorRight = BaseColor.WHITE;
            table.AddCell(cell_E);

            Paragraph para_P = new Paragraph("Puntos", FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            //para_E.IndentationLeft =80;
            para_P.Alignment = Element.ALIGN_CENTER;
            PdfPCell cell_P= new PdfPCell();

            //cell_E.Border = 0;
            cell_P.BorderWidthTop = 0;
            //cell_E .HorizontalAlignment = 0;
            cell_P.AddElement(para_P);
            cell_P.PaddingTop = 15f;
            cell_P.PaddingBottom = 15f;
            cell_P.BorderColorTop = BaseColor.WHITE;
            cell_P.BorderColorLeft = BaseColor.WHITE;
            cell_P.BorderColorRight = BaseColor.WHITE;
            table.AddCell(cell_P);


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                
                string query_eq = "select * from Equipo order by puntos_equipo desc, nombre_equipo asc";
                SqlCommand cmd_eq = new SqlCommand(query_eq, conn);

                SqlDataReader dr = cmd_eq.ExecuteReader();
                while (dr.Read())
                {
                    Paragraph para1 = new Paragraph(Convert.ToString(dr[1]));
                    para1.Alignment = Element.ALIGN_CENTER;
                    Paragraph para2 = new Paragraph(Convert.ToString(dr[2]));
                    para2.Alignment = Element.ALIGN_CENTER;
                    PdfPCell cell1 = new PdfPCell();
                    PdfPCell cell2 = new PdfPCell();
                    cell1.Border = 0;
                    
                    cell2.Border = 0;
                    
                    cell1.AddElement(para1);
                    cell2.AddElement(para2);
                    table.AddCell(cell1);
                    table.AddCell(cell2);
                }
                pdfDoc.Add(table);
            }
            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Tabla de Posiciones.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            crear_estadisticas();
        }
        public void crear_estadisticas()
        {
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            Paragraph para = new Paragraph("Estadísticas de los jugadores del torneo Fanas F11", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));

            para.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(para);


            //Tabla
            float[] widths = new float[] { 60f, 20f, 20f, 20f };
            PdfPTable table = new PdfPTable(widths);
            //table.TotalWidth = 200f;
            //table.LockedWidth = true;
            /*
            table.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.SpacingBefore = 50f;
            table.SpacingAfter = 10f;
            table.HeaderRows = 1;
            */
            

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();

                string query_jug = "select id_jugador, apellido_jugador, nombre_jugador,goles_jugador,amarillas_jugador,rojas_jugador, nombre_equipo from Jugador inner join Equipo on Jugador.id_equipo=Equipo.id_equipo  order by  Equipo.id_equipo";
                SqlCommand cmd_jug = new SqlCommand(query_jug, conn);

                SqlDataReader dr = cmd_jug.ExecuteReader();


                while (dr.Read())
                {
                    if (Convert.ToString(dr[0])=="1" || Convert.ToString(dr[0]) == "12" || Convert.ToString(dr[0]) == "23" || Convert.ToString(dr[0]) == "34" || Convert.ToString(dr[0]) == "45" || Convert.ToString(dr[0]) == "56" || Convert.ToString(dr[0]) == "67" || Convert.ToString(dr[0]) == "78" || Convert.ToString(dr[0]) == "89" || Convert.ToString(dr[0]) == "100" || Convert.ToString(dr[0]) == "111" || Convert.ToString(dr[0]) == "122") {
                        Paragraph para_E = new Paragraph(Convert.ToString(dr[6]), FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        //para_E.IndentationLeft =80;
                        para_E.Alignment = Element.ALIGN_CENTER;
                        PdfPCell cell_E = new PdfPCell();

                        //cell_E.Border = 0;
                        cell_E.BorderWidthTop = 0;
                        //cell_E .HorizontalAlignment = 0;
                        cell_E.AddElement(para_E);
                        cell_E.PaddingTop=15f;
                        cell_E.PaddingBottom = 15f;
                        cell_E.BorderColorTop=BaseColor.WHITE;
                        cell_E.BorderColorLeft = BaseColor.WHITE;
                        cell_E.BorderColorRight = BaseColor.WHITE;
                        table.AddCell(cell_E);

                        PdfPCell cell_G = new PdfPCell();
                        cell_G.BorderWidthTop = 0;
                        cell_G.AddElement(new Paragraph("Goles", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD)));
                        cell_G.PaddingTop = 15f;
                        cell_G.PaddingBottom = 15f;
                        cell_G.PaddingLeft = 20f;
                        cell_G.BorderColorTop = BaseColor.WHITE;
                        cell_G.BorderColorLeft = BaseColor.WHITE;
                        cell_G.BorderColorRight = BaseColor.WHITE;
                        table.AddCell(cell_G);

                        PdfPCell cell_A = new PdfPCell();
                        cell_A.BorderWidthTop = 0;
                        cell_A.AddElement(new Paragraph("Amarillas", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD)));
                        cell_A.PaddingTop = 15f;
                        cell_A.PaddingBottom = 15f;
                        cell_A.PaddingLeft = 15f;
                        cell_A.BorderColorTop = BaseColor.WHITE;
                        cell_A.BorderColorLeft = BaseColor.WHITE;
                        cell_A.BorderColorRight = BaseColor.WHITE;
                        table.AddCell(cell_A);

                        PdfPCell cell_R = new PdfPCell();
                        cell_R.BorderWidthTop = 0;
                        cell_R.AddElement(new Paragraph("Rojas", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD)));
                        cell_R.PaddingTop = 15f;
                        cell_R.PaddingBottom = 15f;
                        cell_R.PaddingLeft = 20f;
                        cell_R.BorderColorTop = BaseColor.WHITE;
                        cell_R.BorderColorLeft = BaseColor.WHITE;
                        cell_R.BorderColorRight = BaseColor.WHITE;
                        table.AddCell(cell_R);

                    }
                    Paragraph para1 = new Paragraph(Convert.ToString(dr[1])+", "+ Convert.ToString(dr[2]));
                    para1.Alignment = Element.ALIGN_CENTER;


                    Paragraph para3 = new Paragraph(Convert.ToString(dr[3]));
                    para3.Alignment = Element.ALIGN_CENTER;
                    Paragraph para4 = new Paragraph(Convert.ToString(dr[4]));
                    para4.Alignment = Element.ALIGN_CENTER;
                    Paragraph para5 = new Paragraph(Convert.ToString(dr[5]));
                    para5.Alignment = Element.ALIGN_CENTER;
                    //para2.IndentationLeft = 5;
                    PdfPCell cell1 = new PdfPCell();
                    cell1.Border = 0;
                    PdfPCell cell3 = new PdfPCell();
                    cell3.Border = 0;
                    PdfPCell cell4 = new PdfPCell();
                    cell4.Border = 0;
                    PdfPCell cell5 = new PdfPCell();
                    cell5.Border = 0;
                    /*
                    
                    cell1.HorizontalAlignment = 0;
                    
                    cell2.HorizontalAlignment = 0;
                    
                    cell3.HorizontalAlignment = 0;
                    
                    cell4.HorizontalAlignment = 0;
                    
                    cell5.HorizontalAlignment = 0;
                    */

                    cell1.AddElement(para1);
                    
                    cell3.AddElement(para3);
                    cell4.AddElement(para4);
                    cell5.AddElement(para5);
                    table.AddCell(cell1);
                    
                    table.AddCell(cell3);
                    table.AddCell(cell4);
                    table.AddCell(cell5);
                }
                pdfDoc.Add(table);
            }
            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Estadisticas de Jugadores.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            datos_personales();
        }
        public void datos_personales() {
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            Paragraph para = new Paragraph("Estadísticas de los jugadores del torneo Fanas F11", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));

            para.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(para);


            //Tabla
            float[] widths = new float[] { 50f, 30f, 30f, 50f };
            PdfPTable table = new PdfPTable(widths);
            //table.TotalWidth = 200f;
            //table.LockedWidth = true;
            /*
            table.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.SpacingBefore = 50f;
            table.SpacingAfter = 10f;
            table.HeaderRows = 1;
            */


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();

                string query_jug = "select id_jugador, apellido_jugador, nombre_jugador, direccion_jugador, telefono_jugador, mail_jugador, nombre_equipo from Jugador inner join Equipo on Jugador.id_equipo=Equipo.id_equipo  order by  Equipo.id_equipo";
                SqlCommand cmd_jug = new SqlCommand(query_jug, conn);

                SqlDataReader dr = cmd_jug.ExecuteReader();


                while (dr.Read())
                {
                    if (Convert.ToString(dr[0]) == "1" || Convert.ToString(dr[0]) == "12" || Convert.ToString(dr[0]) == "23" || Convert.ToString(dr[0]) == "34" || Convert.ToString(dr[0]) == "45" || Convert.ToString(dr[0]) == "56" || Convert.ToString(dr[0]) == "67" || Convert.ToString(dr[0]) == "78" || Convert.ToString(dr[0]) == "89" || Convert.ToString(dr[0]) == "100" || Convert.ToString(dr[0]) == "111" || Convert.ToString(dr[0]) == "122")
                    {
                        Paragraph para_E = new Paragraph(Convert.ToString(dr[6]), FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD));
                        //para_E.IndentationLeft =80;
                        para_E.Alignment = Element.ALIGN_CENTER;
                        PdfPCell cell_E = new PdfPCell();

                        //cell_E.Border = 0;
                        cell_E.BorderWidthTop = 0;
                        //cell_E .HorizontalAlignment = 0;
                        cell_E.AddElement(para_E);
                        cell_E.PaddingTop = 15f;
                        cell_E.PaddingBottom = 15f;
                        cell_E.BorderColorTop = BaseColor.WHITE;
                        cell_E.BorderColorLeft = BaseColor.WHITE;
                        cell_E.BorderColorRight = BaseColor.WHITE;
                        table.AddCell(cell_E);

                        PdfPCell cell_G = new PdfPCell();
                        cell_G.BorderWidthTop = 0;
                        cell_G.AddElement(new Paragraph("Direccion", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD)));
                        cell_G.PaddingTop = 15f;
                        cell_G.PaddingBottom = 15f;
                        cell_G.PaddingLeft = 20f;
                        cell_G.BorderColorTop = BaseColor.WHITE;
                        cell_G.BorderColorLeft = BaseColor.WHITE;
                        cell_G.BorderColorRight = BaseColor.WHITE;
                        table.AddCell(cell_G);

                        PdfPCell cell_A = new PdfPCell();
                        cell_A.BorderWidthTop = 0;
                        cell_A.AddElement(new Paragraph("Teléfono", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD)));
                        cell_A.PaddingTop = 15f;
                        cell_A.PaddingBottom = 15f;
                        cell_A.PaddingLeft = 15f;
                        cell_A.BorderColorTop = BaseColor.WHITE;
                        cell_A.BorderColorLeft = BaseColor.WHITE;
                        cell_A.BorderColorRight = BaseColor.WHITE;
                        table.AddCell(cell_A);

                        PdfPCell cell_R = new PdfPCell();
                        cell_R.BorderWidthTop = 0;
                        cell_R.AddElement(new Paragraph("Mail", FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD)));
                        cell_R.PaddingTop = 15f;
                        cell_R.PaddingBottom = 15f;
                        cell_R.PaddingLeft = 50f;
                        cell_R.BorderColorTop = BaseColor.WHITE;
                        cell_R.BorderColorLeft = BaseColor.WHITE;
                        cell_R.BorderColorRight = BaseColor.WHITE;
                        table.AddCell(cell_R);

                    }
                    Paragraph para1 = new Paragraph(Convert.ToString(dr[1]) + ", " + Convert.ToString(dr[2]));
                    para1.Alignment = Element.ALIGN_CENTER;


                    Paragraph para3 = new Paragraph(Convert.ToString(dr[3]));
                    para3.Alignment = Element.ALIGN_CENTER;
                    Paragraph para4 = new Paragraph(Convert.ToString(dr[4]));
                    para4.Alignment = Element.ALIGN_CENTER;
                    Paragraph para5 = new Paragraph(Convert.ToString(dr[5]));
                    para5.Alignment = Element.ALIGN_CENTER;
                    //para2.IndentationLeft = 5;
                    PdfPCell cell1 = new PdfPCell();
                    cell1.Border = 0;
                    PdfPCell cell3 = new PdfPCell();
                    cell3.Border = 0;
                    PdfPCell cell4 = new PdfPCell();
                    cell4.Border = 0;
                    PdfPCell cell5 = new PdfPCell();
                    cell5.Border = 0;
                    /*
                    
                    cell1.HorizontalAlignment = 0;
                    
                    cell2.HorizontalAlignment = 0;
                    
                    cell3.HorizontalAlignment = 0;
                    
                    cell4.HorizontalAlignment = 0;
                    
                    cell5.HorizontalAlignment = 0;
                    */

                    cell1.AddElement(para1);

                    cell3.AddElement(para3);
                    cell4.AddElement(para4);
                    cell5.AddElement(para5);
                    table.AddCell(cell1);

                    table.AddCell(cell3);
                    table.AddCell(cell4);
                    table.AddCell(cell5);
                }
                pdfDoc.Add(table);
            }
            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Estadisticas de Jugadores.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}
