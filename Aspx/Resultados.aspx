<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="Torneos_Futbol.Aspx.Resultados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Resultados</title>
    <link rel="stylesheet"  href="../CSS/Estilos_Resultados.css" />
</head>
<body>
    <div>

    </div>
    <form id="form1" runat="server">
        <!-- Navegación entre páginas --->
        <div class="div_Nav">
            <nav class="Navegacion" >
                <ul >
                    <li><a href="Inicio.aspx">Inicio</a></li>
            
                    <li><a href="Novedades.aspx">Novedades</a></li>
                    <li><a href="Fixture.aspx">Fixture</a></li>
                    <li><a href="Resultados.aspx">Resultados</a></li>
                    <li><a href="Reglas.aspx">Reglas</a></li>
                    <li><a href="Contactanos.aspx">Contactanos</a></li>
                </ul>
          </nav>
        </div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" CssClass="LinkButton1">[PDF] Tabla de Posiciones</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="LinkButton1" >[PDF] Estadísticas Jugadores</asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="LinkButton1Admin" Visible="false">[PDF] Datos Jugadores</asp:LinkButton>
            
        <div id="div_ProxPartidos" runat="server" class="div_ProxPartidos">
            <h2>Resultados...</h2>
        </div>
        <div>
            <asp:Button ID="Button_CargarRdos" runat="server" Text="Cargar Resultados" OnClick="Button_CargarRdos_Click" Visible="False" class="ButtonCargarResultados"/>
        </div>
        <div>
            <asp:Label ID="Label_Fecha" runat="server" Text="Fecha:  " Visible="False" CssClass="Label_Fecha"></asp:Label><asp:DropDownList ID="DropDownList_Fecha" runat="server"  OnSelectedIndexChanged="DropDownList_Fecha_SelectedIndexChanged" class="DropDownFecha" AutoPostBack="True" Visible="False">
            </asp:DropDownList>
            <br />    
            
            <div runat="server" id="div_Partido">
                <asp:Label ID="Label_Partido" runat="server" Text="Partido:  " CssClass="Label_Fecha"></asp:Label> 
                <asp:DropDownList ID="DropDownList_Partido" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Partido_SelectedIndexChanged" class="DropDownFechaP">
                </asp:DropDownList>
                <br />
            </div>
            <div runat="server" id="div_Rdo">
                
                <asp:Label ID="Label_Resultado" runat="server" Text="Resultado:  " CssClass="Label_Fecha"></asp:Label>
                <br />
                <asp:Label ID="Label_RdoE1" runat="server" Text="Equipo 1:  " ></asp:Label><asp:TextBox ID="TextBox_Rdo1" runat="server"  class="TextBoxsRdo"></asp:TextBox>   <br />
                <asp:Label ID="Label_RdoE2" runat="server" Text="Equipo 2:  " ></asp:Label><asp:TextBox ID="TextBox_Rdo2" runat="server"  OnTextChanged="TextBox_Rdo2_TextChanged" class="TextBoxsRdo"></asp:TextBox><br />
                
            </div>
            <div runat="server" id="div_Goles">
                <br />
                <asp:Label ID="Label_Goles" runat="server" Text="GOLES:  " CssClass="Label_FechaN"></asp:Label>  <br />
                <asp:Label ID="Label_GolesE1" runat="server" Text="Equipo 1:  "></asp:Label> <asp:DropDownList ID="DropDownList_Goles1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Goles1_SelectedIndexChanged" CssClass="DropDownGoles"> </asp:DropDownList> 
                <asp:Label ID="LabelG1" runat="server" Text="Goles de:  " CssClass="Golesde"></asp:Label>
                <asp:Label ID="LabelGolesDe1" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label_GolesE2" runat="server" Text="Equipo 2:  "></asp:Label> <asp:DropDownList ID="DropDownList_Goles2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Goles2_SelectedIndexChanged" CssClass="DropDownGoles"></asp:DropDownList> 
                <asp:Label ID="LabelG2" runat="server" Text="Goles de:  " CssClass="Golesde"></asp:Label>
                <asp:Label ID="LabelGolesDe2" runat="server"></asp:Label>
                
                
            </div>
            <div  runat="server" id="div_Amarillas">
                <br />
                <asp:Label ID="Label_Amarillas" runat="server" Text="AMARILLAS:  " CssClass="Label_FechaN"></asp:Label> <br />
                <asp:Label ID="Label_AE1" runat="server" Text="Equipo 1:"></asp:Label><asp:DropDownList ID="DropDownList_A1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_A1_SelectedIndexChanged" CssClass="DropDownGoles"></asp:DropDownList> 
                <asp:Label ID="Label1" runat="server" Text="Amonestados:  " CssClass="Golesde"></asp:Label>
                <asp:Label ID="Label3" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label_AE2" runat="server" Text="Equipo 2"></asp:Label><asp:DropDownList ID="DropDownList_A2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_A2_SelectedIndexChanged" CssClass="DropDownGoles"></asp:DropDownList> 
                <asp:Label ID="Label2" runat="server" Text="Amonestados:  " CssClass="Golesde"></asp:Label>
                <asp:Label ID="Label4" runat="server"></asp:Label>
                
            </div>
            <div runat="server" id="div_Rojas">
                <br />
                <asp:Label ID="Label_Rojas" runat="server" Text="ROJAS:  " CssClass="Label_FechaN" ></asp:Label>  <br />
                <asp:Label ID="Label_RE1" runat="server" Text="Equipo 1:"></asp:Label><asp:DropDownList ID="DropDownList_R1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_R1_SelectedIndexChanged" CssClass="DropDownGoles"></asp:DropDownList> 
                <asp:Label ID="Label5" runat="server" Text="Expulsados:  " CssClass="Golesde"></asp:Label>
                <asp:Label ID="Label7" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label_RE2" runat="server" Text="Equipo 2"></asp:Label><asp:DropDownList ID="DropDownList_R2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_R2_SelectedIndexChanged" CssClass="DropDownGoles"></asp:DropDownList> 
                <asp:Label ID="Label6" runat="server" Text="Expulsados:  " CssClass="Golesde"></asp:Label>
                <asp:Label ID="Label8" runat="server"></asp:Label>
                
            </div>
            <br />
            <asp:Button ID="Button_CargarTablaDatos" runat="server" Text="Cargar datos del Partido" OnClick="Button_CargarTablaDatos_Click" Visible="False" />
             
         </div>
        <asp:Table ID="Table_Rdos" runat="server">
        </asp:Table>
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
