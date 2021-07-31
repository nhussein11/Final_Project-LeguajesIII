using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Torneos_Futbol.Clases;

namespace Torneos_Futbol.Aspx
{
    public partial class Contactanos : System.Web.UI.Page
    {
        //EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack) {
                //Si entro como us, div_us visible
                //Si entro como admin, div_admin visible
                cargar_dropdownlist();
                
                if (Administrador.administrador_conectado)
                {
                    Table_Comentarios.Visible = true;
                    div_NuevoUsuario.Visible = true;
                }
            }
            if (Administrador.administrador_conectado) {
                div_usuario.Visible = false;
                div_Admin.Visible = true;
                Table_Comentarios.Visible = true;
                cargar_comentarios();
            }
            
        }
        protected void Button_enviar_us_Click(object sender, EventArgs e)
        {
            if (TextBox_Nombre.Text == "" || TextBox_Apellido.Text == "" || TextBox_Mail.Text == "" || TextBox_Titulo.Text == "" || TextArea_Cuerpo.Value =="")
            {
                Response.Write("<script>alert('Debe llenar todos los campos');</script>");
            }
            else {
                insertar_comentario(TextBox_Nombre.Text, TextBox_Apellido.Text, TextBox_Mail.Text, TextBox_Titulo.Text, TextArea_Cuerpo.Value);
                cargar_comentarios();
                cargar_dropdownlist();

                TextBox_Nombre.Text = "";
                TextBox_Apellido.Text = "";
                TextBox_Mail.Text = "";
                TextBox_Titulo.Text = "";
                TextArea_Cuerpo.Value = "";
            }    
        }
        protected void Button_ResponderComentario_Click(object sender, EventArgs e)
        {
            div_ResponderComentario.Visible = true;
            cargar_comentarios();
        }
        protected void Button_EliminarComentario_Click(object sender, EventArgs e)
        {
            eliminar_comentario(DropDownList_Comentarios.SelectedValue);
            cargar_comentarios();
            cargar_dropdownlist();
            Table_Comentarios.Visible = true;
        }
        protected void Button_EnviarRta_Click(object sender, EventArgs e)
        {
            if (TextBox_MailRta.Text == "" || TextBox_Asunto.Text == "" || TextArea_Rta.Value == "" || TextBox_Contraseña.Text == "")
            {
                Response.Write("<script>alert('Debe llenar todos los campos');</script>");
            }
            else {
                try
                {
                    MailMessage msg = new MailMessage();
                    //Destino
                    msg.From = new MailAddress(TextBox_MailRta.Text);
                    msg.To.Add(mail_comentario(DropDownList_Comentarios.SelectedValue));
                    msg.Subject = TextBox_Asunto.Text;
                    msg.Body = "Hola " + buscar_Nya(DropDownList_Comentarios.SelectedValue) + ": " + TextArea_Rta.Value;
                    msg.IsBodyHtml = true;
                    //Origen
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential();
                    networkCredential.UserName = TextBox_MailRta.Text;
                    networkCredential.Password = TextBox_Contraseña.Text;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(msg);
                    Label_MailEnviado.Visible = true;
                    Table_Comentarios.Visible = true;
                }
                catch (Exception ex)
                {
                    Label_MailEnviado.Visible = true;
                    Label_MailEnviado.Text = "No se pudo enviar el mail.Error: " + ex.ToString();
                }
                eliminar_comentario(DropDownList_Comentarios.SelectedValue);
                div_ResponderComentario.Visible = false;
                TextBox_MailRta.Text = "";
                TextBox_Asunto.Text = "";
                TextArea_Rta.Value = "";
                TextBox_Contraseña.Text = "";
                cargar_comentarios();
                cargar_dropdownlist();
            }
        }
        protected void DropDownList_Comentarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_comentarios();
            Table_Comentarios.Visible = true;
        }
        protected void Button_NuevoPerfil_Click(object sender, EventArgs e)
        {
            if (TextBox_NuevoUsuario.Text == "" || TextBox_NuevaPassword.Text == "" || TextBox_NuevoEquipo.Text == "" || TextBox_NuevoUsuario.Text == "Nombre" || TextBox_NuevaPassword.Text == "Apellido" || TextBox_NuevoEquipo.Text == "Equipo")
            {
                Response.Write("<script>alert('Debe llenar todos los campos');</script>");
            }
            else {
                crear_nuevo_jugador(TextBox_NuevoUsuario.Text, TextBox_NuevaPassword.Text, TextBox_NuevoEquipo.Text);
                TextBox_NuevoUsuario.Text = "Nombre";
                TextBox_NuevaPassword.Text = "Apellido";
                TextBox_NuevoEquipo.Text = "Equipo";
            }
        }
        //FUNCIONES
        public void insertar_comentario(string nombre, string apellido, string mail, string titulo,string cuerpo) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_InsertarComentario = "insert Comentario(nombre_comentario,apellido_comentario,mail_comentario,titulo_comentario,cuerpo_comentario) values (@nombre_comentario,@apellido_comentario,@mail_comentario,@titulo_comentario,@cuerpo_comentario)";
                SqlCommand cmd_InsertarComentario = new SqlCommand(query_InsertarComentario, conn);
                cmd_InsertarComentario.Parameters.AddWithValue("@nombre_comentario", nombre);
                cmd_InsertarComentario.Parameters.AddWithValue("@apellido_comentario", apellido);
                cmd_InsertarComentario.Parameters.AddWithValue("@mail_comentario", mail);
                cmd_InsertarComentario.Parameters.AddWithValue("@titulo_comentario", titulo);
                cmd_InsertarComentario.Parameters.AddWithValue("@cuerpo_comentario", cuerpo);

                cmd_InsertarComentario.ExecuteNonQuery();
            }
        }
        public void cargar_comentarios() {
            Table_Comentarios.Controls.Clear();
            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                
                string query_CargarComentarios = "select * from Comentario";
                SqlCommand cmd_CargarComentarios = new SqlCommand(query_CargarComentarios, conn);
                SqlDataReader dr = cmd_CargarComentarios.ExecuteReader();

                while (dr.Read())
                {
                    
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    TableCell cell5 = new TableCell();

                    cell1.Text = Convert.ToString(dr[1]);//Aca va nombre de quien envio el comentario
                    cell2.Text = Convert.ToString(dr[2]); //Aca va apellido de quien envio el comentario
                    cell3.Text = Convert.ToString(dr[3]); //Aca va mail de quien envio el comentario
                    cell4.Text = Convert.ToString(dr[4]); //Aca va titulo del comentario
                    cell5.Text = Convert.ToString(dr[5]); //Aca va cuerpo del comentario

                    cell1.Attributes["class"] = "cssCelda";
                    cell2.Attributes["class"] = "cssCelda";
                    cell3.Attributes["class"] = "cssCelda";
                    cell4.Attributes["class"] = "cssCelda";
                    cell5.Attributes["class"] = "cssCelda";

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    row.Attributes["class"] = "cssNoticia";
                    Table_Comentarios.Rows.Add(row);
                }
            }

        }
        public void cargar_dropdownlist() {
            DropDownList_Comentarios.Items.Clear();
            DropDownList_Comentarios.Items.Insert(0, "Elija un comentario");
            DropDownList_Comentarios.Items[0].Attributes["disabled"] = "disabled";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_CargarComentarios = "select * from Comentario";
                SqlCommand cmd_CargarComentarios = new SqlCommand(query_CargarComentarios, conn);
                SqlDataReader dr = cmd_CargarComentarios.ExecuteReader();
                while (dr.Read())
                {
                    DropDownList_Comentarios.Items.Add(Convert.ToString(dr[4]));
                }
            }
        }
        public void eliminar_comentario(string titulo) {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_EliminarComentario = "delete from Comentario where titulo_comentario=@titulo_comentario";
                SqlCommand cmd_EliminarComentario = new SqlCommand(query_EliminarComentario, conn);
                cmd_EliminarComentario.Parameters.AddWithValue("@titulo_comentario", titulo);

                cmd_EliminarComentario.ExecuteNonQuery();
            }
        }
        public string buscar_Nya(string titulo_comentario) {
            string Nya = "";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_NyaComentario = "select * from Comentario where titulo_comentario=@titulo_comentario";
                SqlCommand cmd_NyaComentario = new SqlCommand(query_NyaComentario, conn);
                cmd_NyaComentario.Parameters.AddWithValue("@titulo_comentario", titulo_comentario);
                SqlDataReader dr = cmd_NyaComentario.ExecuteReader();
                if (dr.Read())
                {
                    Nya = Convert.ToString(dr[1])+" "+ Convert.ToString(dr[2]);
                }
                return Nya;
            }
        }
        public string mail_comentario(string titulo_comentario) {
            string mail = "";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_MailComentario = "select * from Comentario where titulo_comentario=@titulo_comentario";
                SqlCommand cmd_MailComentario = new SqlCommand(query_MailComentario, conn);
                cmd_MailComentario.Parameters.AddWithValue("@titulo_comentario", titulo_comentario);
                SqlDataReader dr = cmd_MailComentario.ExecuteReader();
                if (dr.Read()) {
                    mail = Convert.ToString(dr[3]);
                }
                return mail;
            }

        }
        public void crear_nuevo_jugador(string nombre,string apellido, string equipo) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_InsertarJug = "insert Jugador(nombre_jugador,apellido_jugador,username_jugador,password_jugador,goles_jugador,rojas_jugador,amarillas_jugador,id_equipo) values (@nombre_jug,@apellido_jug,@user_jug,@pass_jug,'0','0','0',@id_Eq)";
                SqlCommand cmd_InsertarJug = new SqlCommand(query_InsertarJug, conn);
                cmd_InsertarJug.Parameters.AddWithValue("@nombre_jug", nombre);
                cmd_InsertarJug.Parameters.AddWithValue("@apellido_jug", apellido);
                cmd_InsertarJug.Parameters.AddWithValue("@user_jug", (nombre.Substring(0,1))+(apellido));
                cmd_InsertarJug.Parameters.AddWithValue("@pass_jug", (nombre.Substring(0, 1)) + (apellido)+"123");
                cmd_InsertarJug.Parameters.AddWithValue("@id_Eq", buscar_Equipo(equipo));

                cmd_InsertarJug.ExecuteNonQuery();
            }
        }
        public int buscar_Equipo(string nombre_eq) {
            int id_e = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_idE = "select id_equipo from Equipo where nombre_equipo=@nombre_eq";
                SqlCommand cmd_idE = new SqlCommand(query_idE, conn);
                cmd_idE.Parameters.AddWithValue("@nombre_eq", nombre_eq);
                SqlDataReader dr = cmd_idE.ExecuteReader();
                if (dr.Read())
                {
                    id_e =Convert.ToInt32( dr[0]);
                }
                return id_e;
            }
        }



    }
}

