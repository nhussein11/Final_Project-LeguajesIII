<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fixture.aspx.cs" Inherits="Torneos_Futbol.Aspx.Fixture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Fixture</title>
    <link rel="stylesheet"  href="../CSS/Estilos_Fixture.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div  class="div_Nav">
            <!-- Navegación entre páginas --->
            <nav class="Navegacion">
                <ul>
                    <li><a href="Inicio.aspx">Inicio</a></li>
                    <li><a href="Novedades.aspx">Novedades</a></li>
                    <li><a href="Fixture.aspx">Fixture</a></li>
                    <li><a href="Resultados.aspx">Resultados</a></li>
                    <li><a href="Reglas.aspx">Reglas</a></li>
                    <li><a href="Contactanos.aspx">Contactanos</a></li>
                </ul>
            </nav>
        </div>
        <div id="div_ProxPartidos" runat="server" class="div_ProxPartidos">
            <h2>Proximos Partidos</h2>
        </div>
        <div>
            <asp:Button ID="Button_CrearFixture" runat="server" Text="Button_CrearFixture" OnClick="Button_CrearFixture_Click" Visible="False" class="CrearFixture" />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Cargar por defecto" Visible="False" class="CheckBox" />
            
        </div>
        <div id="crea_calendario" runat="server" visible="false">
            <asp:Label ID="Label_Fecha" runat="server" Text="Fecha" Visible="False" class="LabelFixtureF"></asp:Label>
            <asp:Label ID="Label_partido" runat="server" Text="Partido" class="LabelFixtureP"></asp:Label><asp:Label ID="Label_dia" runat="server" Text="Dia" class="LabelFixtureD"></asp:Label><asp:Label ID="Label_hora" runat="server" Text="Hora" class="LabelFixtureH"></asp:Label><asp:Label ID="Label_cancha" runat="server" Text="Cancha" class="LabelFixtureC"></asp:Label><asp:Label ID="Label_arbitro" runat="server" Text="Arbitro" class="LabelFixtureA"></asp:Label>
            <br />
            <div class="content_float">
                <asp:Label ID="Label1" runat="server" Text="Equipo 1:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox1" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_1_1" runat="server" Width="216px" class="TextBoxEquipo" ></asp:TextBox>
                <asp:TextBox ID="TextBox_dia1" runat="server" Width="45px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_hora1" runat="server" Width="52px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_cancha1" runat="server" Width="55px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_arbitro1" runat="server" class="TextBoxEquipo"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Equipo 2:  " class="LabelEquipo"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" Visible="False"  class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_1_2" runat="server" Width="216px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_dia2" runat="server" Width="45px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_hora2" runat="server" Width="52px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_cancha2" runat="server" Width="55px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_arbitro2" runat="server" class="TextBoxEquipo"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Equipo 3:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox3" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_1_3" runat="server" Width="216px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_dia3" runat="server" Width="45px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_hora3" runat="server" Width="52px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_cancha3" runat="server" Width="55px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_arbitro3" runat="server" class="TextBoxEquipo"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Equipo 4:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox4" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_1_4" runat="server" Width="216px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_dia4" runat="server" Width="45px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_hora4" runat="server" Width="52px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_cancha4" runat="server" Width="55px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_arbitro4" runat="server" class="TextBoxEquipo"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Equipo 5:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox5" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_1_5" runat="server" Width="216px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_dia5" runat="server" Width="45px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_hora5" runat="server" Width="52px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_cancha5" runat="server" Width="55px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_arbitro5" runat="server" class="TextBoxEquipo"></asp:TextBox>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Equipo 6:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox6" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_1_6" runat="server" Width="216px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_dia6" runat="server" Width="45px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_hora6" runat="server" Width="52px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_cancha6" runat="server" Width="55px" class="TextBoxEquipo"></asp:TextBox>
                <asp:TextBox ID="TextBox_arbitro6" runat="server" class="TextBoxEquipo"></asp:TextBox>
                <br />

            </div>

            <div class="content_float">

                <asp:Label ID="Label7" runat="server" Text="Equipo 7:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox7" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <asp:Button ID="Button_AgregarTabla" runat="server" OnClick="Click_Agregar_Tabla" Text="Agregar a la tabla" class="CrearFixtureFinal1" />
                <br>
                <asp:Label ID="Label8" runat="server" Text="Equipo 8:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox8" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <br>
                <asp:Label ID="Label9" runat="server" Text="Equipo 9:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox9" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <br>
                <asp:Label ID="Label10" runat="server" Text="Equipo 10:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox10" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <br>
                <asp:Label ID="Label11" runat="server" Text="Equipo 11:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox11" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <br>
                <asp:Label ID="Label12" runat="server" Text="Equipo 12:  " class="LabelEquipo"></asp:Label><asp:TextBox ID="TextBox12" runat="server" Visible="False" class="TextBoxEquipo"></asp:TextBox>
                <br>
            </div>
            <div>
                <asp:Button ID="Button_CrearFixtureFinal" runat="server" OnClick="Button_CrearFixtureFinal_Click" Text="Crear Fixture Final" class="CrearFixtureFinal" />
            </div>

        </div>
        
        <div >
            <asp:Table ID="Table_Fixture" runat="server" class="MyTable_Reglas"></asp:Table>
        </div>
    </form>
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
