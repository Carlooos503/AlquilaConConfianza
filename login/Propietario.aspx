<%@ Page Title="Mis Propiedades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Propietario.aspx.cs" Inherits="AlquilaConConfianza.Propietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Panel del Propietario - Mis Propiedades</h3>
    <hr style="border-color: #222c55;" />

    <asp:GridView ID="gvCasas" runat="server" AutoGenerateColumns="False" CssClass="table"
        GridLines="None" CellPadding="10" Style="width:100%; background-color:#0f1630; border-radius:8px; margin-top:20px; color:#e8edfb;">
        <Columns>
            <asp:BoundField DataField="Titulo" HeaderText="Título Inmueble" />
            <asp:BoundField DataField="Zona" HeaderText="Zona / Ubicación" />
            <asp:BoundField DataField="Precio" HeaderText="Precio ($/mes)" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Habitaciones" HeaderText="Habitaciones" />
            <asp:BoundField DataField="EstadoVerificacion" HeaderText="Estado" />
        </Columns>
        <EmptyDataTemplate>
            No tienes propiedades registradas todavía.
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
