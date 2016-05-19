<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UI_Ejemplos.aspx.cs" Inherits="Rock_Paper_Scissors.Particionamiento_Tecnologico.Capa_de_Presentación.UI_Ejemplos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div class="panel-group" id="accordion">

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Ejemplo 1</a>
                </h4>
            </div>
            <div id="collapseOne" class="panel-collapse collapse in">
                <textarea class="form-control" rows="6" style="resize:none">
                    [
                        [ "Armando", "P" ], [ "Dave", "S" ]
                    ]
                    
                    Ganador: Dave
                </textarea>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Ejemplo 2</a>
                </h4>
            </div>
            <div id="collapseTwo" class="panel-collapse collapse">
                <textarea class="form-control" rows="6" style="resize:none">
                    [
	                    [ "Dave", "P" ], [ "Armando", "S" ]
                    ]

                    Ganador: Armando
                </textarea>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">Ejemplo 3</a>
                </h4>
            </div>
            <div id="collapseThree" class="panel-collapse collapse">
                <textarea class="form-control" rows="6" style="resize:none">
                    [
	                    [ "Dave", "P" ], [ "Armando", "P" ]
                    ]

                    Ganador: Dave
                </textarea>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour">Ejemplo 4</a>
                </h4>
            </div>
            <div id="collapseFour" class="panel-collapse collapse">
                <textarea class="form-control" rows="14" style="resize:none">
                    [
	                    [
		                    [["Armando", "P"], ["Dave", "S"]],
		                    [["Richard", "R"], ["Michael", "S"]],
 
	                    ],
	                    [
		                    [["Allen", "S"], ["Omer", "P"]],
		                    [["John", "R"], ["Robert", "P"]]
	                    ]
                    ]

                    Ganador: Richard
                </textarea>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive">Ejemplo 5</a>
                </h4>
            </div>
            <div id="collapseFive" class="panel-collapse collapse">
                <textarea class="form-control" rows="17" style="resize:none">
                    [[
 	                    [	 [ ["Armando", "P"], ["Dave", "S"] ],
 	 	                     [ ["Jeudrin", "R"], ["Michael", "S"] ]
	                    ], 
 
 	                    [ 	 [ ["Allen", "S"], ["Omer", "P"] ], 
 	 	                     [ ["John", "R"], ["Robert", "P"] ]
	                    ] 
                     ], [
 	                    [	 [ ["Carlos", "P"], ["Dante", "S"] ],
 	 	                     [ ["Peter", "R"], ["Richard", "S"] ]
	                    ], 
 
 	                    [ 	 [ ["Allan", "S"], ["Homer", "P"] ], 
 	 	                     [ ["Johnny", "R"], ["Ronald", "P"] ]
	                    ] 
                     ]]

                    Ganador: Jeudrin
                </textarea>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix">Ejemplo 6</a>
                </h4>
            </div>
            <div id="collapseSix" class="panel-collapse collapse">
                <textarea class="form-control" rows="17" style="resize:none">
                    [[
 	                    [	 [ ["Carlos", "P"], ["Dante", "S"] ],
 	 	                     [ ["Ali", "R"], ["Peter", "S"] ]
	                    ], 
 
 	                    [ 	 [ ["Allan", "S"], ["Homer", "P"] ], 
 	 	                     [ ["Johnny", "R"], ["Ronald", "P"] ]
	                    ] 
                     ],[
 	                    [	 [ ["Armando", "P"], ["Dave", "S"] ],
 	 	                     [ ["Richard", "R"], ["Michael", "S"] ]
	                    ], 
 
 	                    [ 	 [ ["Allen", "S"], ["Omer", "P"] ], 
 	 	                     [ ["John", "R"], ["Robert", "P"] ]
	                    ] 
                     ]]

                    Ganador: Alí
                </textarea>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">Ejemplo 7</a>
                </h4>
            </div>
            <div id="collapseSeven" class="panel-collapse collapse">
                <textarea class="form-control" rows="14" style="resize:none">
                    [[
 	                    [	 [ ["Carlos", "S"], ["Dante", "S"] ],
 	 	                     [ ["Peter", "R"], ["Tonny", "S"] ]
	                    ], 
 
 	                    [ 	 [ ["David", "P"], ["Homer", "P"] ], 
 	 	                     [ ["Johnny", "P"], ["Ronald", "R"] ]
	                    ] 
                     ],[
 	                    [	 [ ["Armando", "P"], ["Dave", "S"] ],
 	 	                     [ ["Richard", "R"], ["Michael", "S"] ]
	                    ], 
 
 	                    [ 	 [ ["Allen", "S"], ["Omer", "P"] ], 
 	 	                     [ ["John", "R"], ["Robert", "P"] ]
	                    ] 
                     ]]

                    Ganador: David
                </textarea>
            </div>
        </div>

    </div>

    <br />

</asp:Content>