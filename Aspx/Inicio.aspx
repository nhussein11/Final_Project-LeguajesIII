<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Torneos_Futbol.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
    <link rel="stylesheet"  href="../CSS/Estilos_Inicio.css" />
</head>
<body>
    
    <!-- Navegación entre páginas --->
    <div class="div_Nav">
        <nav class="Navegacion" >
            <div>
                <ul >
                    <li><a href="Inicio.aspx">Inicio</a></li>      
                    <li><a href="Novedades.aspx">Novedades</a></li>
                    <li><a href="Fixture.aspx">Fixture</a></li>
                    <li><a href="Resultados.aspx">Resultados</a></li>
                    <li><a href="Reglas.aspx">Reglas</a></li>
                    <li><a href="Contactanos.aspx">Contactanos</a></li>
                </ul>
            </div>
            
        </nav>
     </div>
    <div class="Presentacion">
        <img src="../Imagenes/trophy_2.png" alt=""/>
        <h1>Fanas F11<span>&#160;</span></h1>
    </div>
     
    
    
    
    <!-- 
        <section class="Pelota">
            <marquee behavior="alternate" direction="" scrollamount="35">
                <marquee behavior="alternate" direction="down" scrollamount="20">  
                    <img src="../Imagenes/football.png" alt="" class="ball">
                </marquee>
            </marquee>
        </section>
     --->
    <div runat="server" id="div_open_session" class="Login" visible="true">
        <form id="form1" runat="server" class="box">
            <!-- Tipo de Login --->
            <img src="../Imagenes/Login_User1.png" alt="Alternate Text" />
            <h2>Perfil</h2>
            <!--
            <h2>Usted es: </h2>
            Jugador (usuario) <input type="radio" name="tipo_login" value="Jugador">
            Empleado (admin) <input type="radio" name="tipo_login" value="Empleado">
             --->
            <div>
                <!-- Username -->
                <!--  <asp:TextBox ID="txtbox_username" runat="server" TextMode="SingleLine">Username</asp:TextBox>  -->
                <input type="text" name="USername" placeholder="Usuario" runat="server" id="txtbox_username1"/> 
            </div>
            <div>
                <!-- Password -->
                 <!-- <asp:TextBox ID="txtbox_password" runat="server" TextMode="Password" >Contraseña</asp:TextBox> -->
                 <input type="password" name="" placeholder="Contraseña" runat="server" id="txtbox_password1"/> 
                <!---
                <p><a href="#">Forgot your password?</a>
                    <div id="lower">
                        <input type="checkbox"><label class="check" for="checkbox">Keep me logged in</label>
                        -->
                    </div>
                    <div>
                        <!-- Submit Button -->
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="10px" OnClick="LinkButton1_Click">Si olvidaste tu contraseña, escribe tu nombre de usuario y haz click aqui</asp:LinkButton>
                        <asp:Button ID="ButtonIngresar" runat="server" Text="Ingresar" OnClick="Ingresar_Click" />
                        <asp:Label ID="Label_sesion" runat="server"></asp:Label>
                    </div>   
            </form>
        </div>
        <div runat="server" id="div_close_session" class="Login" visible="false">
            <form id="form2" runat="server" class="box">
                <h3 runat="server" id="h3_bienvenido">Bienvenido</h3>
                
                <asp:Label ID="Label_username" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="TextBox_username" runat="server" Enabled="False" EnableViewState="true" ></asp:TextBox>
                
                <asp:Label ID="Label_Password" runat="server" Text="Password: "></asp:Label>
                <asp:TextBox ID="TextBox_Password" runat="server" Enabled="False"></asp:TextBox>
                
                 <asp:Label ID="Label_Mail" runat="server" Text="Mail: "></asp:Label>
                 <asp:TextBox ID="TextBox_Mail" runat="server" Enabled="False"></asp:TextBox>
                
                <asp:Label ID="Label_Telefono" runat="server" Text="Telefono: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox_Telefono" runat="server" Visible="false" Enabled="False"></asp:TextBox>
                
                <asp:Label ID="Label_Direccion" runat="server" Text="Direccion: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox_Direccion" runat="server" Visible="false" Enabled="False"></asp:TextBox>
                
                <asp:Label ID="Label_Goles" runat="server" Text="Goles: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox_goles" runat="server" Visible="false" Enabled="False"></asp:TextBox>
                
                <asp:Label ID="Label_Amarillas" runat="server" Text="Amarillas: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox_Amarillas" runat="server" Visible="false" Enabled="False"></asp:TextBox>
                
                <asp:Label ID="Label_Rojas" runat="server" Text="Rojas: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox_Rojas" runat="server" Visible="false" Enabled="False"></asp:TextBox>
                
                    <asp:Label ID="Label_Equipo" runat="server" Text="Equipo: " Visible="false"></asp:Label>
                    <asp:TextBox ID="TextBox_Equipo" runat="server" Visible="false" Enabled="False"></asp:TextBox>
             
                <asp:Button ID="Button_ModificarPerfil" runat="server" Text="Modificar Perfil" OnClick="Button_ModificarPerfil_Click" />
                <asp:Button ID="Button_GuardarCambios" runat="server" Text="Guardar Cambios" Visible="false" OnClick="Button_GuardarCambios_Click"  />
                <asp:Button ID="Button_CerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="Button_CerrarSesion_Click" />
            </form>
        </div>
    <div class="imgSilueta">
        <img src="../Imagenes/Silueta.png" alt="" >
    </div>
        <div class="Pelota">
            <section >
                <marquee behavior="alternate" direction="" scrollamount="35">
                    <asp:Label id="lblMarquee" runat="server" ForeColor="ForestGreen" Font-Bold="True" ></asp:Label>
                    <marquee behavior="alternate" direction="down" scrollamount="20">  
                        <asp:Label id="Label1" runat="server" ForeColor="ForestGreen" Font-Bold="True" ></asp:Label>
                        <img src="../Imagenes/football.png" alt="" class="ball">
                    </marquee>
                </marquee>
            </section> 
        </div>
    <footer class="footer">    
        <div class="footer1">
            <h5> > Fanas F11</h5>
            <p >Campeonato de futbol libre, dedicado aquellas personas apasionadas por el deporte, con ganas de disfrutar sus tardes con amigos</p>
            <h5> > Ubicación</h5>
            <p> Campus Castañares, A4400 Salta</p>
            <h5> > Telefono</h5>
            <p>+54 9 387-404040</p>
        </div>
        <div class="footer2">
            <h2>Nuestras Redes</h2>
            <img src="../Imagenes/SN.jpg" alt="Alternate Text" />
            
        </div>
    </footer>
</body>
</html>
