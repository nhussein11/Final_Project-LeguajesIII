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
    public partial class Reglas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizar_reglas();
                Label_IngreseRegla.Visible = false;
                Label_TituloRegla.Visible = false;
                TextBox_TituloRegla.Visible = false;
                TextArea_InfoRegla.Visible = false;
                Button_AgregarNuevaRegla.Visible = false;
                Button_CargarRegla.Visible = false;
                Button_ModificarRegla.Visible = false;
                Button_EliminarRegla.Visible = false;

                if (Administrador.administrador_conectado)
                {
                    div_Admin.Visible = true;
                    cargar_dropdownlist();//ACA TOQUE
                    Button_AgregarNuevaRegla.Visible = true;
                    Button_ModificarRegla.Visible = true;
                    Button_EliminarRegla.Visible = true;
                }
            }

        }
        
        //EVENTOS:
        protected void Button_AgregarNuevaRegla_Click(object sender, EventArgs e)
        {
            Label_TituloRegla.Visible = true;
            TextBox_TituloRegla.Visible = true;
            Label_IngreseRegla.Visible = true;
            TextArea_InfoRegla.Visible = true;
            Button_CargarRegla.Visible = true;
            MyTable_Reglas.Visible = true;
            Button_CargarRegla.Text = "Cargar Regla";

            div_Rules.Visible = false;

            DropDownList_Regla.Visible = false;
            Label_SeleccionRegla.Visible = false;

        }
        protected void Button_ModificarRegla_Click(object sender, EventArgs e)
        {
            Label_TituloRegla.Visible = true;
            TextBox_TituloRegla.Visible = true;
            Label_IngreseRegla.Visible = true;
            TextArea_InfoRegla.Visible = true;
            Button_CargarRegla.Visible = true;
            
            Label_TituloRegla.Text = "Titulo de la noticia";
            Label_IngreseRegla.Text = "Cuerpo noticia";
            Button_CargarRegla.Text = "Cambiar Regla";
            
            div_Rules.Visible = false;
            MyTable_Reglas.Visible = true;

            //Seleccion de regla
            Label_SeleccionRegla.Visible = true;
            DropDownList_Regla.Visible = true;
            DropDownList_Regla.Items.Clear();
            DropDownList_Regla.Items.Insert(0, "Elija una regla");
            DropDownList_Regla.Items[0].Attributes["disabled"] = "disabled";
            cargar_dropdownlist();
        }

        protected void Button_EliminarRegla_Click(object sender, EventArgs e)
        {
            Label_TituloRegla.Visible = false;
            TextBox_TituloRegla.Visible = false;
            Label_IngreseRegla.Visible = false;
            TextArea_InfoRegla.Visible = false;
            Button_CargarRegla.Visible = true;
            MyTable_Reglas.Visible = true;
            Button_CargarRegla.Text = "Borrar Regla";
            div_Rules.Visible = false;
            Label_SeleccionRegla.Visible = true;
            DropDownList_Regla.Visible = true;

            DropDownList_Regla.Items.Clear();
            DropDownList_Regla.Items.Insert(0, "Eliga una regla");
            DropDownList_Regla.Items[0].Attributes["disabled"] = "disabled";
            cargar_dropdownlist();
        }

        protected void Button_CargarRegla_Click(object sender, EventArgs e)
        {
            string titulo_regla = TextBox_TituloRegla.Text;
            string cuerpo_regla = TextArea_InfoRegla.Value;
            //Modificando regla:
            if (DropDownList_Regla.Visible == true && Button_CargarRegla.Text == "Cambiar Regla")
            {
                cambiar_regla(titulo_regla, cuerpo_regla);
                actualizar_reglas();
                
                
                Label_SeleccionRegla.Visible = false;
                Label_TituloRegla.Visible = false;
                Label_IngreseRegla.Visible = false;
                DropDownList_Regla.Visible = false;
                TextBox_TituloRegla.Visible = false;
                TextArea_InfoRegla.Visible = false;
                Button_CargarRegla.Visible = false;

                div_Rules.Visible = true;
            }
            //Eliminando regla:
            else if (DropDownList_Regla.Visible == true && Button_CargarRegla.Text == "Borrar Regla")
            {
                eliminar_regla();
                actualizar_reglas();

                Label_SeleccionRegla.Visible = false;
                Label_TituloRegla.Visible = false;
                Label_IngreseRegla.Visible = false;
                DropDownList_Regla.Visible = false;
                TextBox_TituloRegla.Visible = false;
                TextArea_InfoRegla.Visible = false;
                Button_CargarRegla.Visible = false;

                div_Rules.Visible = true;
            }
            //Agergando regla:
            else if (DropDownList_Regla.Visible == false)
            {
                insertar_reglas(titulo_regla, cuerpo_regla);
                actualizar_reglas();

                
                Label_TituloRegla.Visible = false;
                Label_IngreseRegla.Visible = false;
                TextBox_TituloRegla.Visible = false;
                TextArea_InfoRegla.Visible = false;
                Button_CargarRegla.Visible = false;

                div_Rules.Visible = true;
            }
            div_Rules.Visible = true;
            TextArea_InfoRegla.Value = "";
            TextBox_TituloRegla.Text = "";
        }
        protected void DropDownList_Regla_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label_IngreseRegla.Visible = true;
            TextArea_InfoRegla.Visible = true;
            Label_TituloRegla.Visible = true;
            TextBox_TituloRegla.Visible = true;
            Button_CargarRegla.Visible = true;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_cargar_regla = "SELECT * FROM Regla WHERE titulo_regla=@titulo";
                SqlCommand cmd_cargar_regla = new SqlCommand(query_cargar_regla, conn);
                cmd_cargar_regla.Parameters.AddWithValue("@titulo", DropDownList_Regla.SelectedItem.Value);
                SqlDataReader dr = cmd_cargar_regla.ExecuteReader();
                if (dr.Read())
                {
                    TextBox_TituloRegla.Text = Convert.ToString(dr[1]);//Cargo solo el titulo de la noticia selecionada
                    TextArea_InfoRegla.Value = Convert.ToString(dr[2]);//Cargo solo el cuerpo de la noticia selecionada
                }
            }
        }

        //FUNCIONES:
        public void actualizar_reglas() {
            
            MyTable_Reglas.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_TablaReglas_cantidad = "SELECT count(1) FROM Regla";
                SqlCommand cmd_Regla_cantidad = new SqlCommand(query_TablaReglas_cantidad, conn);
                int cantidad_regla = Convert.ToInt32(cmd_Regla_cantidad.ExecuteScalar());

                string query_TablaRegla = "SELECT * FROM Regla ORDER BY id_regla DESC";
                SqlCommand cmd_Regla = new SqlCommand(query_TablaRegla, conn);
                SqlDataReader dr = cmd_Regla.ExecuteReader();

                for (int i = 0; i < cantidad_regla; i++)
                {
                    while (dr.Read())
                    {
                        TableRow row = new TableRow();
                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        cell1.Text = Convert.ToString(dr[1]);//Aca va el titulo de la noticia
                        cell2.Text = Convert.ToString(dr[2]); ;//Aca va el cuerpo de la noticia
                        cell1.Attributes["class"] = "cssTitulos";
                        cell2.Attributes["class"] = "cssNoticia";
                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        MyTable_Reglas.Rows.Add(row);
                    }
                }
            }
        }          
        public void insertar_reglas(string titulo, string cuerpo)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                //titulo_noticia,cuerpo_noticia
                string query_AgregarRegla = "INSERT Regla (titulo_regla,cuerpo_regla) VALUES (@titulo,@cuerpo)";
                SqlCommand cmd_AgregarRegla = new SqlCommand(query_AgregarRegla, conn);
                cmd_AgregarRegla.Parameters.AddWithValue("@titulo", titulo);
                cmd_AgregarRegla.Parameters.AddWithValue("@cuerpo", cuerpo);
                cmd_AgregarRegla.ExecuteNonQuery();
            }
        }
        public void cambiar_regla(string titulo_regla, string cuerpo_regla) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();

                string query_CambiarNoticia = "UPDATE Regla set titulo_regla=@titulo, cuerpo_regla=@cuerpo WHERE titulo_regla=@titulo_dropdownlist";
                SqlCommand cmd_CambiarNoticia = new SqlCommand(query_CambiarNoticia, conn);
                cmd_CambiarNoticia.Parameters.AddWithValue("@titulo_dropdownlist", DropDownList_Regla.SelectedItem.Value);
                cmd_CambiarNoticia.Parameters.AddWithValue("@titulo", titulo_regla);
                cmd_CambiarNoticia.Parameters.AddWithValue("@cuerpo", cuerpo_regla);
                cmd_CambiarNoticia.ExecuteNonQuery();
            }
            DropDownList_Regla.Items.Clear();
            DropDownList_Regla.Items.Insert(0, "Elija una regla");
            DropDownList_Regla.Items[0].Attributes["disabled"] = "disabled";
            cargar_dropdownlist();

        }
        public void eliminar_regla() {
            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();

                string query_EliminarRegla = "DELETE FROM Regla WHERE titulo_regla=@titulo";
                SqlCommand cmd_EliminarRegla = new SqlCommand(query_EliminarRegla, conn);
                cmd_EliminarRegla.Parameters.AddWithValue("@titulo", DropDownList_Regla.SelectedItem.Value);

                cmd_EliminarRegla.ExecuteNonQuery();
            }
            DropDownList_Regla.Items.Clear();
            DropDownList_Regla.Items.Insert(0, "Elija una regla");
            DropDownList_Regla.Items[0].Attributes["disabled"] = "disabled";

            cargar_dropdownlist();

        }
        public void cargar_dropdownlist()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_TablaRegla_cantidad = "SELECT count(1) FROM Regla";
                SqlCommand cmd_Regla_cantidad = new SqlCommand(query_TablaRegla_cantidad, conn);
                int cantidad_reglas = Convert.ToInt32(cmd_Regla_cantidad.ExecuteScalar());

                string query_TablaRegla = "SELECT * FROM Regla ORDER BY id_regla DESC";
                SqlCommand cmd_Regla = new SqlCommand(query_TablaRegla, conn);
                SqlDataReader dr = cmd_Regla.ExecuteReader();

                for (int i = 0; i < cantidad_reglas; i++)
                {
                    while (dr.Read())
                    {
                        ListItem item = new ListItem(Convert.ToString(dr[1])); //Cargo solo los titulos de las noticias
                        DropDownList_Regla.Items.Add(item);
                    }
                }
            }
        }

       
    }
}