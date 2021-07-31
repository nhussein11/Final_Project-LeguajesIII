<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="Torneos_Futbol.Aspx.Contactanos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Contactanos</title>
    <link rel="stylesheet"  href="../CSS/Estilos_Contactanos.css" />
</head>
<body>
    <form id="form1" runat="server">
        
            <!-- Navegación entre páginas --->
         <div class="div_Nav"> 
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
            <!-- Contacto: --->
            <div runat="server" id="div_usuario" visible="true">
                <div class="div1">
                    <img src="../Imagenes/message.png" alt=""  /> 
                </div>
                <div class="div2">
                    <h2>Comunicate con nosotros </h2>
                    <h3>¡Estamos a tu disposición!</h3>
                </div>
       
                    
                    <div>
                        <asp:Label ID="Label_Nombre" runat="server" Text="Nombre:  " class="LabelUsuario"></asp:Label>
                        <asp:TextBox ID="TextBox_Nombre" runat="server" class="TextBoxUsuarioNyA"></asp:TextBox>  
                    </div>
                    <div>
                        <asp:Label ID="Label_Apellido" runat="server" Text="Apellido:  " class="LabelUsuario"></asp:Label>
                        <asp:TextBox ID="TextBox_Apellido" runat="server" class="TextBoxUsuarioNyA"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label_Mail" runat="server" Text="Direccion de mail:  " class="LabelUsuario"></asp:Label>
                        <asp:TextBox ID="TextBox_Mail" runat="server" class="TextBoxUsuario"></asp:TextBox>
                    </div>
                     <div>
                        <asp:Label ID="Label_Titulo" runat="server" Text="Titulo Comentario:  " class="LabelUsuario"></asp:Label>
                        <asp:TextBox ID="TextBox_Titulo" runat="server" class="TextBoxUsuario"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label_Comentario" runat="server" Text="Comentario:  " class="LabelUsuario"></asp:Label>
                        
                    </div>
                    <div>
                        <textarea runat="server" id="TextArea_Cuerpo" contenteditable="true"  name="S1" class="TextBoxUsuarioA"></textarea>
                        <div>
                            <asp:Button ID="Button_enviar_us" runat="server" Text="Enviar" OnClick="Button_enviar_us_Click" class="BotonEnviar" />
                        </div>
                    </div>
                    
            </div>
            
            <div runat="server" id="div_Admin" visible="false">
                    <asp:DropDownList ID="DropDownList_Comentarios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Comentarios_SelectedIndexChanged" class="DropDown"></asp:DropDownList>
                <br />
                <asp:Button ID="Button_ResponderComentario" runat="server" Text="Responder Comentario" OnClick="Button_ResponderComentario_Click" class="ResponderComentario" />
                <asp:Button ID="Button_EliminarComentario" runat="server" Text="Eliminar Comentario" OnClick="Button_EliminarComentario_Click" class="EliminarComentario" />
                <br />
                <div runat="server" id="div_ResponderComentario" visible="false">
                    <br />
                    <asp:Label ID="Label_MailRta" runat="server" Text="Mail" CssClass="labelAdmin"></asp:Label>
                    <asp:TextBox ID="TextBox_MailRta" runat="server" CssClass="TextBoxMail_A"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label_Asunto" runat="server" Text="Asunto" CssClass="labelAdmin"></asp:Label>
                    <asp:TextBox ID="TextBox_Asunto" runat="server" CssClass="TextBoxAsunto_A"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label_Rta" runat="server" Text="Respuesta" CssClass="labelAdmin"></asp:Label>
                     <br />
                    <textarea id="TextArea_Rta" cols="20" rows="2" runat="server" class="TextAreaRta_A"></textarea>
                    <br />
                    <asp:Label ID="Label_Contaseña" runat="server" Text="Contraseña" CssClass="labelAdmin"></asp:Label>
                    <asp:TextBox ID="TextBox_Contraseña" runat="server" TextMode="Password" CssClass="TextBoxContraseña_A"></asp:TextBox>

                    <br />
                    <asp:Button ID="Button_EnviarRta" runat="server" Text="Enviar Respuesta" OnClick="Button_EnviarRta_Click" class="BotonEnviarRta"/>
                    <br />
                    <asp:Label ID="Label_MailEnviado" runat="server" Text="Mail enviado correctamente!" Visible="false" CssClass="labelAdmin"></asp:Label>
                </div>
                <div class="labeltabla">
                    <asp:Label ID="Label_NyA" runat="server" Text="Nombre y Apellido" class="LabelNyA"></asp:Label><asp:Label ID="LabelMail" runat="server" Text="Mail" class="LabelMail"></asp:Label><asp:Label ID="Label_Tematica" runat="server" Text="Asunto" class="LabelAsunto"></asp:Label><asp:Label ID="Labelcuerpo" runat="server" Text="Comentario" class="LabelCuerpo"></asp:Label>
                </div>
                <br />
                    <asp:Table ID="Table_Comentarios" runat="server" class="Table_Comentarios">
                    </asp:Table>
                <br />
            </div>
            <div runat="server" id="div_NuevoUsuario" class="NuevoUsuario" visible="false">
                <asp:Button ID="Button_NuevoPerfil" runat="server" Text="Agregar Perfil" CssClass="AgregarPerfilBoton" OnClick="Button_NuevoPerfil_Click" /><asp:TextBox ID="TextBox_NuevoUsuario" runat="server" Text="Nombre" CssClass="TextBoxNombre"></asp:TextBox><asp:TextBox ID="TextBox_NuevaPassword" runat="server" Text="Apellido" CssClass="TextBoxNombre"></asp:TextBox><asp:TextBox ID="TextBox_NuevoEquipo" runat="server" Text="Equipo" CssClass="TextBoxNombre"></asp:TextBox>
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
