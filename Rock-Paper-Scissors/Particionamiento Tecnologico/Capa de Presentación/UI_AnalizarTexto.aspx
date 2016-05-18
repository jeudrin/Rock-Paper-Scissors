<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UI_AnalizarTexto.aspx.cs" Inherits="Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Presentación.UI_AnalizarTexto" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label CssClass="lead" ID="lblIngreseTexto" runat="server" Text="Ingrese el texto que desea analizar"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="tbTextoIngresado" runat="server" Height="200px" TextMode="MultiLine" Width="935px" style="resize:none"></asp:TextBox>
    <br />
    <br />
    <asp:Button CssClass="btn btn-warning" ID="btnLimpiarTextoIngresado" runat="server" Text="Limpiar" OnClick="btnLimpiarTextoIngresado_Click"/>
    <asp:Button CssClass="btn btn-primary" ID="btnAnalizarIngreseTexto" runat="server" Text="Analizar" OnClick="btnAnalizarTextoIngresado_Click"/>
    <br />
    <br />  
</asp:Content>
