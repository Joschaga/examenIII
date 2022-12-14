<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="VehiculoExamenFinal.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            USUARIO:<br />
            <asp:TextBox ID="Tusuario" runat="server"></asp:TextBox>
            <br />
            <br />
            CLAVE:<br />
            <asp:TextBox ID="Tclave" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Lmensaje" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Bingresar" runat="server" OnClick="Bingresar_Click" Text="Ingresar" />
            <br />
        </div>
    </form>
</body>
</html>
