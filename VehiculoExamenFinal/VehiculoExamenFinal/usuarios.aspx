<%@ Page Title="" Language="C#" MasterPageFile="~/inicio.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="VehiculoExamenFinal.usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
            text-decoration: underline;
            font-size: x-large;
            background-color: #0099FF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2"><strong>GESTIÓN DE USUARIOS</strong></td>
            <td class="auto-style2"><strong>DATOS DE USUARIOS EN SISTEMA</strong></td>
        </tr>
        <tr>
            <td>
                <br />
                Usuario Login:<br />
                <asp:TextBox ID="Tusuario" runat="server"></asp:TextBox>
                <br />
                <br />
                Clave:<br />
                <asp:TextBox ID="Tclave" runat="server"></asp:TextBox>
                <br />
                <br />
                Nombre:<br />
                <asp:TextBox ID="Tnombre" runat="server"></asp:TextBox>
                <br />
                <br />
                Apellido:<br />
                <asp:TextBox ID="Tapellido" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Bingresar" runat="server" Height="30px" OnClick="Bingresar_Click" Text="Ingresar" Width="90px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Bmodificar" runat="server" Height="30px" OnClick="Bmodificar_Click" Text="Modificar" Width="90px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Bborrar" runat="server" Height="30px" OnClick="Bborrar_Click" Text="Borrar" Width="90px" />
                <br />
            </td>
            <td>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
