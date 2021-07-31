<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Novedades.aspx.cs" Inherits="Torneos_Futbol.Aspx.Novedades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Novedades</title>
    <link rel="stylesheet"  href="../CSS/Estilos_Novedades.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
    
</head>
<body>
    
        <div class="div_Nav">
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
    <form id="form1" runat="server">
        <div runat="server" id="div_Admin" visible="false">
            
            <asp:Button ID="Button_AgregarNoticia" runat="server" OnClick="AgregarNoticia" Text="Agregar Noticia" class="BotonAgregarNoticias" /> 
            <asp:Button ID="Button_ModificarNoticia" runat="server" Text="Modificar Noticia" class="BotonModificarNoticias" OnClick="Button_ModificarNoticia_Click" />
            <asp:Button ID="Button_EliminarNoticia" runat="server"  Text="Eliminar Noticia" class="BotonEliminarNoticias" OnClick="Button_EliminarNoticia_Click"/>
            <div id="div_contenedor">
                <div id="div_Labels">
                    <asp:Label ID="Label_SeleccionNoticia" runat="server" Text="Seleccione que noticia desea modificar" Visible="False" class="LabelNoticias"></asp:Label>
                    <asp:Label ID="Label_TituloNoticia" runat="server" Text="Ingrese el Titulo de la noticia:" class="LabelNoticias" ></asp:Label>
                    <asp:Label ID="Label_IngreseNoticia" runat="server" Text="Ingrese el contenido de la noticia: " Visible="False" class="LabelNoticias" ></asp:Label>
                </div>
                <div id="div_Texts" >
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False" AutoPostBack="True" class="DropDown">   </asp:DropDownList>
                    <asp:TextBox ID="TextBox_TituloNoticia" runat="server" class="TextBox"></asp:TextBox>
                    <textarea runat="server" id="TextArea_InfoNoticia" contenteditable="true"  name="S1" class="TextArea"></textarea>
                </div>
                <div id="div_boton_cargar">
                    <asp:Button ID="Button_CargarNoticia" runat="server" Text="Cargar Noticia" Class="BotonCargarNoticias" OnClick="Button_CargarNoticia_Click1" /> 
                </div>
            </div>
        </div>

        <div id="div_News" runat="server">
            <img src="../Imagenes/News.png" />
            <h2>Ultimas Novedades...</h2>
        </div>

        <div>
            <asp:Table ID="myTable" runat="server" class="myTable"> 
                
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
