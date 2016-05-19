<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UI_Top.aspx.cs" Inherits="Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Presentación.UI_Top" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label CssClass="lead" ID="lblSeleccioneTop" runat="server" Text="Top"></asp:Label>
    <asp:TextBox ID="tbTop" runat="server" Width="50px"></asp:TextBox>
    <asp:Button CssClass="btn btn-success" ID="btnCargarTop" runat="server" Text="Cargar"/>
    <br />
    <br />
    <asp:TextBox ID="tbTopCargado" runat="server" Height="250px" TextMode="MultiLine" Width="935px" style="resize:none"></asp:TextBox>
    <br />
    <br />  
    <asp:Button CssClass="btn btn-danger" ID="btnLimpiarBD" runat="server" Text="Limpiar BD"/>
</asp:Content>