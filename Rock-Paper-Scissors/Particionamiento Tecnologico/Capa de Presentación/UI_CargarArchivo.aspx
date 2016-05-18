<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UI_CargarArchivo.aspx.cs" Inherits="Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Presentación.UI_CargarArchivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label CssClass="lead" ID="lblSeleccioneArchivo" runat="server" Text="Seleccione el archivo que desea analizar"></asp:Label>
    <br />
    <br />
    <asp:FileUpload ID="fuSeleccioneArchivo" runat="server" />
    <br />
    <asp:Button CssClass="btn btn-success" ID="btnCargarArchivo" runat="server" Text="Cargar Archivo" OnClick="btnCargarArchivo_Click"/>
    <br />
    <br />
    <asp:TextBox ID="tbArchivoCargado" runat="server" Height="250px" TextMode="MultiLine" Width="935px" style="resize:none"></asp:TextBox>
    <br />
    <br />  
    <asp:Label CssClass="lead" ID="lblResultado" runat="server" Text=""></asp:Label>
</asp:Content>