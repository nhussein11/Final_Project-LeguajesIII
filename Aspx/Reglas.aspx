<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reglas.aspx.cs" Inherits="Torneos_Futbol.Aspx.Reglas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reglas</title>
    <link rel="stylesheet"  href="../CSS/Estilos_Reglas.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
</head>
<body>
    
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
    <form id="form1" runat="server">
        <div runat="server" id="div_Admin" visible="false">
            <asp:Button ID="Button_AgregarNuevaRegla" runat="server" Text="Agregar Nueva Regla" class="BotonAgregarRegla" OnClick="Button_AgregarNuevaRegla_Click"/>
            <asp:Button ID="Button_ModificarRegla" runat="server" Text="Modificar Regla" class="BotonModificarRegla" OnClick="Button_ModificarRegla_Click"/>
            <asp:Button ID="Button_EliminarRegla" runat="server" Text="Eliminar Regla" class="BotonEliminarRegla" OnClick="Button_EliminarRegla_Click"/>
            <div id="div_contenedor">
                <div id="div_Labels">
                    <asp:Label ID="Label_SeleccionRegla" runat="server" Text="Selecciona la regla" Visible="False" class="LabelRegla"></asp:Label>
                    <asp:Label ID="Label_TituloRegla" runat="server" Text="Ingrese el titulo de la nueva regla:" class="LabelRegla" ></asp:Label>
                    <asp:Label ID="Label_IngreseRegla" runat="server" Text="Ingrese el contenido de la nueva regla: " Visible="False" class="LabelRegla" ></asp:Label>
                </div>
                <div id="div_Texts">
                    <asp:DropDownList ID="DropDownList_Regla" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="DropDownList_Regla_SelectedIndexChanged" Visible="False" class="DropDown"></asp:DropDownList>
                    <asp:TextBox ID="TextBox_TituloRegla" runat="server"  class="TextBox"></asp:TextBox>
                    <textarea runat="server" id="TextArea_InfoRegla"  contenteditable="true"  name="S1" class="TextArea"></textarea>
                </div>
                <div id="div_boton_cargar">
                    <asp:Button ID="Button_CargarRegla" runat="server" Text="Cargar Regla" Class="BotonCargarRegla" OnClick="Button_CargarRegla_Click"/>    
                </div>
            </div>
            
        </div>
        <div id="div_Rules" runat="server">
            <img src="../Imagenes/Rules.png" />
            <h2>Nuestro Reglamento...</h2>
        </div>
        
        <div >
            <!-- <script src="../Javascript/Reglas.js"></script> --->
            <asp:Table ID="MyTable_Reglas" runat="server" class="MyTable_Reglas">
                <asp:TableRow>
                    
                </asp:TableRow>
            </asp:Table>
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
