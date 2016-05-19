<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UI_Solucion.aspx.cs" Inherits="Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Presentación.UI_Solucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label CssClass="lead" ID="lblTecnologia" runat="server" Text="Tecnología"></asp:Label>
    <br />
    <br />
    <p>
        Para resolver el problema del juego Rock-Paper-Scissors, se tomó la decisión de implementar una solución mediante el Framework .NET, 
        utilizando C# como lenguaje de programación. 
    </p>
    <br />
    <asp:Label CssClass="lead" ID="lblSolucion" runat="server" Text="Solución"></asp:Label>
    <br />
    <br />
    <p>
        La aplicación cuenta con una clase RockPaperScissors que se encarga de leer los archivos de texto donde se encuentran los jugadores, así mismo esta información es almacenada
        en una lista de tipo Jugador, que contiene el nombre del jugador y la jugada realizada.
        Esta clase además tiene los métodos de definir ganador, que consiste en recorrer la lista de jugadores que se cargaron previamente desde archivo, e irlos comparando unos con otro
        seleccionando de esta manera, los jugadores que tienen mejor jugada.
        Este método es recursivo, lo que recibe es la lista de jugadores y una lista vacía, donde se van almacenando los jugadores ganadores, que a su vez esta lista se va a utilizar cuando
        se llame nuevamente el método.
    </p>
</asp:Content>