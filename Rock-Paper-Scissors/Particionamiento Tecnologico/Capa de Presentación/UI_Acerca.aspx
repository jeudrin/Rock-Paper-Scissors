<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UI_Acerca.aspx.cs" Inherits="Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Presentación.UI_Acerca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Image ID="Image1" Width="125px" Height="220px" ImageUrl="~/Images/Resources/Perfil.jpg" runat="server" />
    <br />
    <br />
    <p>
        Mi nombre es Jeudrin Alí Marchena Sánchez, soy de Siquirres, Limón, actualmente vivo en Santa Clara, San Carlos, donde me encuentro estudiando
        Ingeniería en Computación en el Instituto Tecnológico de Costa Rica, actualmente cursando el último semestre de la carrera, me gusta aprender nuevas tecnologías 
        y acompañar a otros en su aprendizaje. Me considero una persona responsable con capacidad de trabajar en equipo y bajo presión.
        Me gusta desarrollar aplicaciones móviles y trabajar con personas de diferentes áreas para conocer y tener una idea más clara de lo que sería un ambiente laboral.
    </p>
    <br />
    <asp:ImageButton ID="Image2" Width="50px" Height="50px" ImageUrl="~/Images/Resources/github.png" runat="server" PostBackUrl="https://github.com/jeudrin"/>
    <asp:ImageButton ID="Image3" Width="50px" Height="50px" ImageUrl="~/Images/Resources/linkedin.png" runat="server" PostBackUrl="https://www.linkedin.com/in/jeudrin" />
    <asp:ImageButton ID="Image4" Width="50px" Height="50px" ImageUrl="~/Images/Resources/facebook.png" runat="server" PostBackUrl="https://www.facebook.com/jeudrin"/>
    <asp:ImageButton ID="Image5" Width="50px" Height="50px" ImageUrl="~/Images/Resources/twitter.png" runat="server" PostBackUrl="https://twitter.com/JeudrinMarchena"/>
</asp:Content>