<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlquilaConConfianza.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Iniciar Sesión - Alquila con Confianza</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 300px; margin: 50px auto; font-family: Arial;">
            <h2>Iniciar Sesión</h2>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label><br /><br />
            
            <label>Correo electrónico:</label><br />
            <asp:TextBox ID="txtCorreo" runat="server" Width="100%"></asp:TextBox><br /><br />
            
            <label>Contraseña:</label><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox><br /><br />
            
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" Width="100%" />
        </div>
    </form>
</body>
</html>