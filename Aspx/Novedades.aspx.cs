using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Torneos_Futbol.Clases;
using Torneos_Futbol.Aspx;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Torneos_Futbol.Aspx
{
    public partial class Novedades : System.Web.UI.Page
    {   
        //EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizar_noticias();
                Label_IngreseNoticia.Visible = false;
                Label_TituloNoticia.Visible = false;
                TextBox_TituloNoticia.Visible = false;
                TextArea_InfoNoticia.Visible = false;
                Button_AgregarNoticia.Visible = false;
                Button_CargarNoticia.Visible = false;
                Button_ModificarNoticia.Visible = false;
                Button_EliminarNoticia.Visible = false;
                if (Administrador.administrador_conectado)
                {
                    div_Admin.Visible = true;
                    Button_AgregarNoticia.Visible = true;
                    Button_ModificarNoticia.Visible = true;
                    Button_EliminarNoticia.Visible = true;

                }
            }         
        }

        protected void AgregarNoticia(object sender, EventArgs e)
        {
            Label_IngreseNoticia.Visible = true;
            TextArea_InfoNoticia.Visible = true;
            TextArea_InfoNoticia.Value = "";
            Label_TituloNoticia.Visible = true;
            TextBox_TituloNoticia.Visible = true;
            TextBox_TituloNoticia.Text = "";
            Button_CargarNoticia.Visible = true;
            Button_CargarNoticia.Text = "Cargar Noticia";

            div_News.Visible = false;
            myTable.Visible = true;
            
            DropDownList1.Visible = false;
            Label_SeleccionNoticia.Visible = false;
        }
        protected void Button_CargarNoticia_Click1(object sender, EventArgs e)
        {
            string titulo_noticia = TextBox_TituloNoticia.Text;
            string cuerpo_noticia = TextArea_InfoNoticia.Value;
            myTable.Visible = true;
            //Si estoy modificando una noticia entonces:
            if (DropDownList1.Visible == true && Button_CargarNoticia.Text=="Cambiar Noticia")
            {
                cambiar_noticia(titulo_noticia, cuerpo_noticia);
                actualizar_noticias();
                DropDownList1.Visible = false;
                Label_SeleccionNoticia.Visible = false;
                Label_TituloNoticia.Visible = false;
                Label_IngreseNoticia.Visible = false;
                TextBox_TituloNoticia.Visible = false;
                TextArea_InfoNoticia.Visible = false;
                Button_CargarNoticia.Visible = false;

                div_News.Visible = true;
            }
            //Sino estoy eliminando una noticia:-
            else if (DropDownList1.Visible == true && Button_CargarNoticia.Text == "Borrar Noticia") {
                eliminar_noticia();
                actualizar_noticias();
                DropDownList1.Visible = false;
                Label_SeleccionNoticia.Visible = false;
                Label_TituloNoticia.Visible = false;
                Label_IngreseNoticia.Visible = false;
                TextBox_TituloNoticia.Visible = false;
                TextArea_InfoNoticia.Visible = false;
                Button_CargarNoticia.Visible = false;
                
                div_News.Visible = true;
            }
            //Sino estoy agregando una noticia:-
            else if(DropDownList1.Visible == false)
            {
                insertar_noticias(titulo_noticia, cuerpo_noticia);
                actualizar_noticias();
                Label_TituloNoticia.Visible = false;
                Label_IngreseNoticia.Visible = false;
                TextBox_TituloNoticia.Visible = false;
                TextArea_InfoNoticia.Visible = false;
                Button_CargarNoticia.Visible = false;

                div_News.Visible = true;
            }
            
            

        }
        protected void Button_ModificarNoticia_Click(object sender, EventArgs e)
        {
            Label_IngreseNoticia.Visible = true;
            TextArea_InfoNoticia.Visible = true;
            Label_TituloNoticia.Visible = true;
            TextBox_TituloNoticia.Visible = true;
            Button_CargarNoticia.Visible = true;
            Label_TituloNoticia.Text = "Titulo de la noticia";
            Label_IngreseNoticia.Text = "Cuerpo noticia";
            Button_CargarNoticia.Text = "Cambiar Noticia";

            div_News.Visible = false;
            myTable.Visible = true;

            //Selección de noticia
            Label_SeleccionNoticia.Visible = true;
            DropDownList1.Visible = true;
            
            cargar_dropdownlist();
        }

        protected void Button_EliminarNoticia_Click(object sender, EventArgs e)
        {
            Label_IngreseNoticia.Visible = true;
            TextArea_InfoNoticia.Visible = true;
            Label_TituloNoticia.Visible = true;
            TextBox_TituloNoticia.Visible = true;
            Button_CargarNoticia.Visible = true;
            Label_TituloNoticia.Text = "Titulo de la noticia";
            Label_IngreseNoticia.Text = "Cuerpo noticia";
            Button_CargarNoticia.Text = "Borrar Noticia";

            div_News.Visible = false;
            myTable.Visible = true;

            Label_SeleccionNoticia.Visible = true;
            DropDownList1.Visible = true;
            
            cargar_dropdownlist();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label_IngreseNoticia.Visible = true;
            TextArea_InfoNoticia.Visible = true;
            Label_TituloNoticia.Visible = true;
            TextBox_TituloNoticia.Visible = true;
            Button_CargarNoticia.Visible = true;
            myTable.Visible = true;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_cargar_noticia = "SELECT * FROM Noticia WHERE titulo_noticia=@titulo";
                SqlCommand cmd_cargar_noticia = new SqlCommand(query_cargar_noticia, conn);
                cmd_cargar_noticia.Parameters.AddWithValue("@titulo", DropDownList1.SelectedItem.Value);
                SqlDataReader dr = cmd_cargar_noticia.ExecuteReader();
                if (dr.Read())
                {
                    TextBox_TituloNoticia.Text = Convert.ToString(dr[1]);//Cargo solo el titulo de la noticia selecionada
                    TextArea_InfoNoticia.Value = Convert.ToString(dr[2]);//Cargo solo el cuerpo de la noticia selecionada
                }
            }
        }
        //FUNCIONES
        public void actualizar_noticias()
        {
            myTable.Controls.Clear();
            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                
                conn.Open();
                string query_TablaNoticias_cantidad = "SELECT count(1) FROM Noticia";
                SqlCommand cmd_Noticias_cantidad = new SqlCommand(query_TablaNoticias_cantidad, conn);
                int cantidad_noticias = Convert.ToInt32(cmd_Noticias_cantidad.ExecuteScalar());
                
                string query_TablaNoticias = "SELECT * FROM Noticia ORDER BY id_noticia DESC";
                SqlCommand cmd_Noticias = new SqlCommand(query_TablaNoticias, conn);
                SqlDataReader dr = cmd_Noticias.ExecuteReader();
                
                for (int i = 0; i<cantidad_noticias; i++)
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
                        
                        myTable.Rows.Add(row);
                    }                    
                }

            }
        }
        public void insertar_noticias(string titulo,string cuerpo) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString)) 
            { 
                conn.Open();
                //titulo_noticia,cuerpo_noticia
                string query_AgregarNoticias = "INSERT Noticia (titulo_noticia, cuerpo_noticia) VALUES (@titulo, @cuerpo)";
                SqlCommand cmd_AgregarNoticias = new SqlCommand(query_AgregarNoticias, conn);
                cmd_AgregarNoticias.Parameters.AddWithValue("@titulo", titulo);
                cmd_AgregarNoticias.Parameters.AddWithValue("@cuerpo", cuerpo);
                cmd_AgregarNoticias.ExecuteNonQuery();
            }
        }


        public void cargar_dropdownlist() {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Insert(0, "Elija una noticia");
            DropDownList1.Items[0].Attributes["disabled"] = "disabled";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_TablaNoticias_cantidad = "SELECT count(1) FROM Noticia";
                SqlCommand cmd_Noticias_cantidad = new SqlCommand(query_TablaNoticias_cantidad, conn);
                int cantidad_noticias = Convert.ToInt32(cmd_Noticias_cantidad.ExecuteScalar());

                string query_TablaNoticias = "SELECT * FROM Noticia ORDER BY id_noticia DESC";
                SqlCommand cmd_Noticias = new SqlCommand(query_TablaNoticias, conn);
                SqlDataReader dr = cmd_Noticias.ExecuteReader();

                for (int i = 0; i < cantidad_noticias; i++)
                {
                    while (dr.Read())
                    {
                        ListItem item = new ListItem(Convert.ToString(dr[1])); //Cargo solo los titulos de las noticias
                        DropDownList1.Items.Add(item);                          
                    }
                }
            }
        }
        public void cambiar_noticia( string titulo, string cuerpo) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                
                string query_CambiarNoticia = "UPDATE Noticia set titulo_noticia=@titulo, cuerpo_noticia=@cuerpo WHERE titulo_noticia=@titulo_dropdownlist";
                SqlCommand cmd_CambiarNoticia = new SqlCommand(query_CambiarNoticia, conn);
                cmd_CambiarNoticia.Parameters.AddWithValue("@titulo_dropdownlist", DropDownList1.SelectedItem.Value);
                cmd_CambiarNoticia.Parameters.AddWithValue("@titulo",titulo );
                cmd_CambiarNoticia.Parameters.AddWithValue("@cuerpo", cuerpo );
                cmd_CambiarNoticia.ExecuteNonQuery();
            }
            
            cargar_dropdownlist();

        }
        public void eliminar_noticia() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();

                string query_CambiarNoticia = "DELETE FROM Noticia WHERE titulo_noticia=@titulo_dropdownlist";
                SqlCommand cmd_CambiarNoticia = new SqlCommand(query_CambiarNoticia, conn);
                cmd_CambiarNoticia.Parameters.AddWithValue("@titulo_dropdownlist", DropDownList1.SelectedItem.Value);
                
                cmd_CambiarNoticia.ExecuteNonQuery();
            }
            
            cargar_dropdownlist();
        }
    }
}