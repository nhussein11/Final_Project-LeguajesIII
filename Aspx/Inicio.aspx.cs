using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Torneos_Futbol.Clases;
using System.Net.Mail;

namespace Torneos_Futbol
{

    public partial class Inicio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Administrador.administrador_conectado)
                {
                    div_open_session.Visible = false;
                    div_close_session.Visible = true;
                    h3_bienvenido.InnerText = "Hola " + Administrador.nombre_administrador + " " + Administrador.apellido_administrador;
                    TextBox_username.Text = Administrador.username_administrador;
                    TextBox_Password.Text = Administrador.password_administrador;
                    TextBox_Mail.Text = Administrador.mail_administrador;
                }
                else if (Jugador.jugador_conectado)
                {
                    div_open_session.Visible = false;
                    div_close_session.Visible = true;
                    h3_bienvenido.InnerText = "Hola " + Jugador.nombre_jugador + " " + Jugador.apellido_jugador;
                    TextBox_username.Text = Jugador.username_jugador;
                    TextBox_Password.Text = Jugador.password_jugador;
                    TextBox_Mail.Text = Jugador.mail_jugador;
                    Label_Telefono.Visible = true;
                    TextBox_Telefono.Visible = true;
                    TextBox_Telefono.Text = Jugador.telefono_jugador;
                    Label_Direccion.Visible = true;
                    TextBox_Direccion.Visible = true;
                    TextBox_Direccion.Text = Jugador.direccion_jugador;
                    Label_Goles.Visible = true;
                    TextBox_goles.Visible = true;
                    TextBox_goles.Text = Jugador.goles_jugador.ToString();
                    Label_Amarillas.Visible = true;
                    TextBox_Amarillas.Visible = true;
                    TextBox_Amarillas.Text = Jugador.amarillas_jugador.ToString();
                    Label_Rojas.Visible = true;
                    TextBox_Rojas.Visible = true;
                    TextBox_Rojas.Text = Jugador.rojas_jugador.ToString();
                    Label_Equipo.Visible = true;
                    TextBox_Equipo.Visible = true;
                    TextBox_Equipo.Text = Jugador.equipo_jugador;
                }
                else if (Arbitro.arbitro_conectado)
                {
                    div_open_session.Visible = false;
                    div_close_session.Visible = true;
                    h3_bienvenido.InnerText = "Hola " + Arbitro.nombre_arbitro + " " + Arbitro.apellido_arbitro;
                    TextBox_username.Text = Arbitro.username_arbitro;
                    TextBox_Password.Text = Arbitro.password_arbitro;
                    Label_Mail.Visible = false;
                    TextBox_Mail.Visible = false;
                }
            }            
        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {
            string username = txtbox_username1.Value;
            string password = txtbox_password1.Value;
            if (Login(username, password)) {
                if (Administrador.administrador_conectado)
                {
                    h3_bienvenido.InnerText = "Hola " + Administrador.nombre_administrador + " " + Administrador.apellido_administrador;
                    TextBox_username.Text = Administrador.username_administrador;
                    TextBox_Password.Text = Administrador.password_administrador;
                    TextBox_Mail.Text = Administrador.mail_administrador;
                    Label_Mail.Visible = true;
                    TextBox_Mail.Visible = true;
                    Label_Direccion.Visible = false;
                    TextBox_Direccion.Visible = false;
                    Label_Telefono.Visible = false;
                    TextBox_Telefono.Visible = false;
                    Label_Goles.Visible = false;
                    TextBox_goles.Visible = false;
                    Label_Amarillas.Visible = false;
                    TextBox_Amarillas.Visible = false;
                    Label_Rojas.Visible = false;
                    TextBox_Rojas.Visible = false;
                    Label_Equipo.Visible = false;
                    TextBox_Equipo.Visible = false;
                }
                else if (Jugador.jugador_conectado)
                {
                    h3_bienvenido.InnerText = "Hola " + Jugador.nombre_jugador+ " " + Jugador.apellido_jugador;
                    TextBox_username.Text = Jugador.username_jugador;
                    TextBox_Password.Text = Jugador.password_jugador;
                    TextBox_Mail.Text = Jugador.mail_jugador;
                    Label_Telefono.Visible = true;
                    TextBox_Telefono.Visible = true;
                    TextBox_Telefono.Text = Jugador.telefono_jugador;
                    Label_Direccion.Visible = true;
                    TextBox_Direccion.Visible = true;
                    TextBox_Direccion.Text = Jugador.direccion_jugador;
                    Label_Goles.Visible = true;
                    TextBox_goles.Visible = true;
                    TextBox_goles.Text = Jugador.goles_jugador.ToString();
                    Label_Amarillas.Visible = true;
                    TextBox_Amarillas.Visible = true;
                    TextBox_Amarillas.Text = Jugador.amarillas_jugador.ToString();
                    Label_Rojas.Visible = true;
                    TextBox_Rojas.Visible = true;
                    TextBox_Rojas.Text = Jugador.rojas_jugador.ToString();
                    Label_Equipo.Visible = true;
                    TextBox_Equipo.Visible = true;
                    TextBox_Equipo.Text = Jugador.equipo_jugador;
                }
                else if (Arbitro.arbitro_conectado)
                {
                    h3_bienvenido.InnerText = "Hola " + Arbitro.nombre_arbitro + " " + Arbitro.apellido_arbitro;
                    TextBox_username.Text = Arbitro.username_arbitro;
                    TextBox_Password.Text = Arbitro.password_arbitro;
                    Label_Mail.Visible = false;
                    TextBox_Mail.Visible = false;
                    Label_Direccion.Visible = false;
                    TextBox_Direccion.Visible = false;
                    Label_Telefono.Visible = false;
                    TextBox_Telefono.Visible = false;
                    Label_Goles.Visible = false;
                    TextBox_goles.Visible = false;
                    Label_Amarillas.Visible = false;
                    TextBox_Amarillas.Visible = false;
                    Label_Rojas.Visible = false;
                    TextBox_Rojas.Visible = false;
                    Label_Equipo.Visible = false;
                    TextBox_Equipo.Visible = false;
                
                }
                div_close_session.Visible = true;
                div_open_session.Visible = false;
            }
            else {
                Label_sesion.Visible = true;
                Label_sesion.Text = "El usuario "+username+" no está registrado";
            }
            TextBox[] textBoxes = new TextBox[] { TextBox_username, TextBox_Password, TextBox_Mail, TextBox_Telefono, TextBox_Direccion, TextBox_goles, TextBox_Amarillas, TextBox_Rojas, TextBox_Equipo };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Enabled = false;
            }
            
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (existe_usuario(txtbox_username1.Value))
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    //Destino
                    msg.From = new MailAddress("torneolenguajes3@gmail.com");
                    msg.To.Add(mail_usuario(txtbox_username1.Value));
                    msg.Subject = "Recuperacion de contraseña";
                    msg.Body = "Hola "+txtbox_username1.Value+ ", su contraseña es: "+contraseña_usuario(txtbox_username1.Value);
                    msg.IsBodyHtml = true;
                    //Origen
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential();
                    networkCredential.UserName = "torneolenguajes3@gmail.com";
                    networkCredential.Password = "20lenguajes3_21";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(msg);
                    
                    
                }
                catch (Exception ex)
                {
                    
                    Label_sesion.Text = "No se pudo enviar el mail.Error: " + ex.ToString();
                }
                Label_sesion.Text = "Contraseña enviada a " + mail_usuario(txtbox_username1.Value);
            }
            else {
                Label_sesion.Text = "El usuario " + TextBox_username.Text + " no está registrado";
            }
        }
        protected void Button_CerrarSesion_Click(object sender, EventArgs e)
        {
            div_close_session.Visible = false;
            div_open_session.Visible = true;
            TextBox_username.Text = "";
            Label_sesion.Visible = false;
            Administrador.administrador_conectado = false;
            Jugador.jugador_conectado = false;
            Arbitro.arbitro_conectado = false;
        }
        protected void Button_ModificarPerfil_Click(object sender, EventArgs e)
        {
            //Enabled=true
            TextBox[] textBoxes = new TextBox[] { TextBox_username, TextBox_Password, TextBox_Mail , TextBox_Telefono, TextBox_Direccion};
            for (int i=0; i<textBoxes.Length; i++) {
                textBoxes[i].Enabled = true;
            }

           
            //Escondo el boton de modificar perfil
            Button_ModificarPerfil.Visible = false;
            Button_GuardarCambios.Visible = true;
        }
        protected void Button_GuardarCambios_Click(object sender, EventArgs e)
        {
            string texto = TextBox_username.Text;
            //Actualizo la bdd
            if (Administrador.administrador_conectado) {
                actualizar_cambios(Administrador.username_administrador, Administrador.password_administrador);
            }
            else if (Jugador.jugador_conectado) {
                actualizar_cambios(Jugador.username_jugador, Jugador.password_jugador);
            }
            else if(Arbitro.arbitro_conectado){
                actualizar_cambios(Arbitro.username_arbitro,Arbitro.password_arbitro);
            }
            
            //Escondo el boton de modificar perfil
            Button_ModificarPerfil.Visible = true;
            Button_GuardarCambios.Visible = false;
            //Enabled=false
            TextBox[] textBoxes = new TextBox[] { TextBox_username, TextBox_Password, TextBox_Mail, TextBox_Telefono, TextBox_Direccion, TextBox_goles, TextBox_Amarillas, TextBox_Rojas, TextBox_Equipo };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Enabled = false;
            }
        }
        public bool Login(string username, string password) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString)) {

                conn.Open();
                //QUERY PARA JUGADORES
                string query_jugador = "SELECT COUNT(1) FROM Jugador WHERE username_jugador=@username_jugador AND password_jugador=@password_jugador";
                SqlCommand cmd_jugador = new SqlCommand(query_jugador, conn);
                cmd_jugador.Parameters.AddWithValue("@username_jugador", username.Trim());
                cmd_jugador.Parameters.AddWithValue("@password_jugador", password.Trim());
                int count = Convert.ToInt32(cmd_jugador.ExecuteScalar());
                if (count == 1)
                {
                    //QUERY PARA JUGADORES con todos los datos necesarios
                    string query_jugador_final = "select nombre_jugador,apellido_jugador,username_jugador,password_jugador,mail_jugador,telefono_jugador,direccion_jugador,goles_jugador,amarillas_jugador,rojas_jugador, nombre_equipo from Jugador inner join Equipo on Jugador.id_equipo=Equipo.id_equipo where username_jugador=@username_jugador AND password_jugador=@password_jugador";
                    SqlCommand cmd_jugador_final = new SqlCommand(query_jugador_final, conn);
                    cmd_jugador_final.Parameters.AddWithValue("@username_jugador", username.Trim());
                    cmd_jugador_final.Parameters.AddWithValue("@password_jugador", password.Trim());
                    SqlDataReader dr = cmd_jugador_final.ExecuteReader();
                    if (dr.Read())
                    {
                        Jugador.nombre_jugador = Convert.ToString(dr[0]);
                        Jugador.apellido_jugador = Convert.ToString(dr[1]);
                        Jugador.username_jugador = Convert.ToString(dr[2]);
                        Jugador.password_jugador = Convert.ToString(dr[3]);
                        Jugador.mail_jugador = Convert.ToString(dr[4]);
                        Jugador.telefono_jugador= Convert.ToString(dr[5]);
                        Jugador.direccion_jugador = Convert.ToString(dr[6]);
                        Jugador.goles_jugador = Convert.ToInt32(dr[7]);
                        Jugador.amarillas_jugador = Convert.ToInt32(dr[8]);
                        Jugador.rojas_jugador = Convert.ToInt32(dr[9]);
                        Jugador.equipo_jugador= Convert.ToString(dr[10]);
                    }
                    Jugador.jugador_conectado = true;
                    return true;
                }
                else {
                    //QUERY PARA ARBITROS
                    string query_arbitro = "SELECT COUNT(1) FROM Arbitro WHERE username_arbitro=@username_arbitro AND password_arbitro=@password_arbitro";
                    SqlCommand cmd_arbitro = new SqlCommand(query_arbitro, conn);
                    cmd_arbitro.Parameters.AddWithValue("@username_arbitro", username.Trim());
                    cmd_arbitro.Parameters.AddWithValue("@password_arbitro", password.Trim());
                    count = Convert.ToInt32(cmd_arbitro.ExecuteScalar());
                    if (count == 1)
                    {
                        //QUERY PARA ARBITROS con todos los datos necesarios
                        string query_arbitro_final = "select * from Arbitro where username_arbitro=@username_arbitro AND password_arbitro=@password_arbitro";
                        SqlCommand cmd_arbitro_final = new SqlCommand(query_arbitro_final, conn);
                        cmd_arbitro_final.Parameters.AddWithValue("@username_arbitro", username.Trim());
                        cmd_arbitro_final.Parameters.AddWithValue("@password_arbitro", password.Trim());
                        SqlDataReader dr = cmd_arbitro_final.ExecuteReader();
                        if (dr.Read())
                        {
                            Arbitro.nombre_arbitro = Convert.ToString(dr[1]);
                            Arbitro.apellido_arbitro = Convert.ToString(dr[2]);
                            Arbitro.username_arbitro = Convert.ToString(dr[3]);
                            Arbitro.password_arbitro = Convert.ToString(dr[4]);
                            
                        }
                        Arbitro.arbitro_conectado = true;
                        return true;
                    }
                    else
                    {
                        //QUERY PARA ADMINS
                        string query_administrador = "SELECT COUNT(1) FROM Administrador WHERE username_administrador=@username_administrador AND password_administrador=@password_administrador";
                        SqlCommand cmd_administrador = new SqlCommand(query_administrador, conn);
                        cmd_administrador.Parameters.AddWithValue("@username_administrador", username.Trim());
                        cmd_administrador.Parameters.AddWithValue("@password_administrador", password.Trim());
                        count = Convert.ToInt32(cmd_administrador.ExecuteScalar());
                        if (count == 1)
                        {
                             
                            //QUERY PARA ADMINS con todos los datos necesarios
                            string query_administrador_final = "SELECT nombre_administrador, apellido_administrador, username_administrador, password_administrador, mail_administrador FROM Administrador WHERE username_administrador=@username_administrador AND password_administrador=@password_administrador";
                            SqlCommand cmd_administrador_final = new SqlCommand(query_administrador_final, conn);
                            cmd_administrador_final.Parameters.AddWithValue("@username_administrador", username.Trim());
                            cmd_administrador_final.Parameters.AddWithValue("@password_administrador", password.Trim());
                            SqlDataReader dr = cmd_administrador_final.ExecuteReader();
                            if (dr.Read()) {
                                Administrador.nombre_administrador = Convert.ToString(dr[0]);
                                Administrador.apellido_administrador= Convert.ToString(dr[1]);
                                Administrador.username_administrador = Convert.ToString(dr[2]);
                                Administrador.password_administrador = Convert.ToString(dr[3]);
                                Administrador.mail_administrador = Convert.ToString(dr[4]);
                            }
                            Administrador.administrador_conectado = true;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }                    
            }
        }
        public void actualizar_cambios(string user_viejo, string password_vieja) {
            
            if (Administrador.administrador_conectado) {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
                {
                    conn.Open();
                    //titulo_noticia,cuerpo_noticia
                    string query_ActualizarAdmin = "update Administrador set  username_administrador=@user_admin, password_administrador=@password_admin, mail_administrador=@mail_admin where username_administrador=@user_admin_viejo and password_administrador=@password_admin_vieja";
                    SqlCommand cmd_ActualizarAdmin = new SqlCommand(query_ActualizarAdmin, conn);
                    cmd_ActualizarAdmin.Parameters.AddWithValue("@user_admin", TextBox_username.Text);
                    cmd_ActualizarAdmin.Parameters.AddWithValue("@password_admin", TextBox_Password.Text);
                    cmd_ActualizarAdmin.Parameters.AddWithValue("@mail_admin", TextBox_Mail.Text);
                    cmd_ActualizarAdmin.Parameters.AddWithValue("@user_admin_viejo", user_viejo);
                    cmd_ActualizarAdmin.Parameters.AddWithValue("@password_admin_vieja", password_vieja);
                    cmd_ActualizarAdmin.ExecuteNonQuery();
                }
                Administrador.username_administrador = TextBox_username.Text;
                Administrador.password_administrador = TextBox_Password.Text;
                Administrador.mail_administrador = TextBox_Mail.Text;
                
            }
            else if (Jugador.jugador_conectado) {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
                {
                    conn.Open();
                    //titulo_noticia,cuerpo_noticia
                    string query_ActualizarJug = "update Jugador set username_jugador=@user_jug, password_jugador=@password_jug, telefono_jugador=@telefono_jug, direccion_jugador=@direccion_jug, mail_jugador=@mail_jug where username_jugador=@user_jug_viejo and password_jugador=@password_jug_vieja";
                    SqlCommand cmd_ActualizarJug = new SqlCommand(query_ActualizarJug, conn);
                    cmd_ActualizarJug.Parameters.AddWithValue("@user_jug", TextBox_username.Text);
                    cmd_ActualizarJug.Parameters.AddWithValue("@password_jug", TextBox_Password.Text);
                    cmd_ActualizarJug.Parameters.AddWithValue("@telefono_jug", TextBox_Telefono.Text);
                    cmd_ActualizarJug.Parameters.AddWithValue("@direccion_jug", TextBox_Direccion.Text);
                    cmd_ActualizarJug.Parameters.AddWithValue("@mail_jug", TextBox_Mail.Text);
                    cmd_ActualizarJug.Parameters.AddWithValue("@user_jug_viejo", user_viejo);
                    cmd_ActualizarJug.Parameters.AddWithValue("@password_jug_vieja", password_vieja);
                    cmd_ActualizarJug.ExecuteNonQuery();
                }
                Jugador.username_jugador = TextBox_username.Text;
                Jugador.password_jugador = TextBox_Password.Text;
                Jugador.telefono_jugador = TextBox_Telefono.Text;
                Jugador.direccion_jugador = TextBox_Direccion.Text;
                Jugador.mail_jugador= TextBox_Mail.Text;
            }
            else if (Arbitro.arbitro_conectado) {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
                {
                    conn.Open();
                    //titulo_noticia,cuerpo_noticia
                    string query_ActualizarAdmin = "update Arbitro set username_arbitro=@user_arb, password_arbitro=@password_arb where username_arbitro=@user_arb_viejo and password_arbitro=@password_arb_vieja";
                    SqlCommand cmd_ActualizarAdmin = new SqlCommand(query_ActualizarAdmin, conn);
                    cmd_ActualizarAdmin.Parameters.AddWithValue("@user_arb", TextBox_username.Text);
                    cmd_ActualizarAdmin.Parameters.AddWithValue("@password_arb", TextBox_Password.Text);
                    cmd_ActualizarAdmin.Parameters.AddWithValue("@user_arb_viejo", user_viejo);
                    cmd_ActualizarAdmin.Parameters.AddWithValue("@password_arb_vieja", password_vieja);
                    cmd_ActualizarAdmin.ExecuteNonQuery();
                }
                Arbitro.username_arbitro = TextBox_username.Text;
                Arbitro.password_arbitro= TextBox_Password.Text;
            }
        }
        public bool existe_usuario(string us)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {

                conn.Open();
                //QUERY PARA JUGADORES
                string query_jugador = "SELECT COUNT(1) FROM Jugador WHERE username_jugador=@username_jugador ";
                SqlCommand cmd_jugador = new SqlCommand(query_jugador, conn);
                cmd_jugador.Parameters.AddWithValue("@username_jugador", us.Trim());
                int count1 = Convert.ToInt32(cmd_jugador.ExecuteScalar());
                if (count1 == 1)
                {
                    return true;
                }
                else
                {
                    string query_arbitro = "SELECT COUNT(1) FROM Arbitro WHERE username_arbitro=@username_arbitro";
                    SqlCommand cmd_arbitro = new SqlCommand(query_arbitro, conn);
                    cmd_arbitro.Parameters.AddWithValue("@username_arbitro", us.Trim());
                    int count2 = Convert.ToInt32(cmd_arbitro.ExecuteScalar());
                    if (count2 == 1)
                    {
                        return true;
                    }
                    else {
                        string query_administrador_final = "SELECT COUNT(1) FROM Administrador WHERE username_administrador=@username_administrador";
                        SqlCommand cmd_administrador_final = new SqlCommand(query_administrador_final, conn);
                        cmd_administrador_final.Parameters.AddWithValue("@username_administrador", us.Trim());
                        int count3 = Convert.ToInt32(cmd_administrador_final.ExecuteScalar());
                        if (count3 == 1)
                        {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                }
            }
        }
        public string mail_usuario(string us)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_mail = "select mail_administrador from Administrador where username_administrador=@us";
                SqlCommand cmd_mail = new SqlCommand(query_mail, conn);
                cmd_mail.Parameters.AddWithValue("@us", us.Trim());
              
                SqlDataReader dr = cmd_mail.ExecuteReader();
                if (dr.Read())
                {
                    return Convert.ToString(dr[0]);
                }
                else {
                    string query_jug = "select mail_jugador from Jugador where username_jugador=@us";
                    SqlCommand cmdjug = new SqlCommand(query_jug, conn);
                    cmdjug.Parameters.AddWithValue("@us", us.Trim());

                    SqlDataReader dr1 = cmdjug.ExecuteReader();
                    if (dr1.Read())
                    {
                        return Convert.ToString(dr1[0]);
                    }
                    else {
                        return "";
                    }
                }
            }
        }
        public string contraseña_usuario(string us) {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionT_F"].ConnectionString))
            {
                conn.Open();
                string query_pass = "select password_administrador from Administrador where username_administrador=@us";
                SqlCommand cmd_pass = new SqlCommand(query_pass, conn);
                cmd_pass.Parameters.AddWithValue("@us", us.Trim());

                SqlDataReader dr = cmd_pass.ExecuteReader();
                if (dr.Read())
                {
                    return Convert.ToString(dr[0]);
                }
                else
                {
                    string query_jug = "select password_jugador from Jugador where username_jugador=@us";
                    SqlCommand cmdjug = new SqlCommand(query_jug, conn);
                    cmdjug.Parameters.AddWithValue("@us", us.Trim());

                    SqlDataReader dr1 = cmdjug.ExecuteReader();
                    if (dr1.Read())
                    {
                        return Convert.ToString(dr1[0]);
                    }
                    else
                    {
                        return "";
                    }
                }

            }
        }
    }
}