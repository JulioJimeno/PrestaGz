<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoPrestamo.aspx.cs" Inherits="PrestaGz.Consulta.CoPrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div id="divConsultaPrestamo" runat="server" class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
        <br />
        <div style="margin-left: 6%; margin-bottom: 1%">
            <h2><strong>Consulta de Prestamo</strong></h2>
            <div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxBuscar">Simbolos no permitidos</asp:RegularExpressionValidator>
            </div>
            <asp:DropDownList ID="dropCliente" runat="server" CssClass="btn btn-primary" Width="184px">
                <asp:ListItem Value="0">Hoy</asp:ListItem>
                <asp:ListItem Value="1">Nombre</asp:ListItem>
                <asp:ListItem Value="2">Cedula</asp:ListItem>
                <asp:ListItem Value="3">Telefono</asp:ListItem>
                <asp:ListItem Value="4">Codigo</asp:ListItem>
                <asp:ListItem Value="5">Todos</asp:ListItem>
            </asp:DropDownList>

        </div>

        <article class="col-xs-9 col-sm-9 col-md-9 col-lg-9">

            <div style="margin-left: 5%">

                <asp:TextBox ID="tbxBuscar" ValidationGroup="vgroup" CssClass="form-control" runat="server" />
            </div>

        </article>

        <article class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
            <div id="divBuscar" runat="server" style="margin-left: -20%">
                <asp:Button ID="btnBuscarCliente" CssClass="btn btn-success" Width="96px" ValidationGroup="vgroup" Text="&#9668;Buscar&#9658;" runat="server" Style="font-weight: bold" OnClick="btnBuscarCliente_Click" />
            </div>
            <br />
        </article>
        <%-- <div style="text-align:center" runat="server" id="divMovilGiro" visible="false"> 
            <asp:Image ImageUrl="~/Imagenes/girar2.png" runat="server" /> <h2><strong>Girar el dispositivo.!!</strong></h2>
        </div>--%>
    </div>
    <div id="divGridPrestamo" runat="server">

        <strong>
            <br />
            <div>
                <asp:Label Text="" ID="LblClienteId" ForeColor="Transparent" runat="server" />
                <asp:Label Text="" ID="lblId" ForeColor="Transparent" runat="server" />
                <strong>
                    <div class="text-center"  style="overflow-x:scroll; overflow-y:scroll; height:100%;width:100%">
                        <asp:GridView ID="GridPrestamo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Style="font-size: medium" OnSelectedIndexChanged="GridPrestamo_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Abono" SelectImageUrl="~/Imagenes/dinero.png" ShowSelectButton="True" />
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="PrestamoId" HeaderText="Codigo">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Nombre" HeaderText="Nombre Cliente">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="FechaInicio" HeaderText="Inicio Prestamo">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="FechaTermino" HeaderText="Fin Prestamo">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Taza" HeaderText="Taza">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Total" HeaderText="Capital">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Interes" HeaderText="Interes">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Estado" HeaderText="Estado">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="CantidadCuota" HeaderText="Abono">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="NombreUsuario" HeaderText="Prestador">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>

                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#1569b8" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                    </div>
                </strong>

            </div>
            <br />
        </strong>

    </div>

    <div class="row" id="divAbono" runat="server" visible="false" style="border-bottom: 2.5px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 2px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
        <article class="col-xs-12 col-sm-12 col-md-6 col-lg-6">

            <div id="divGridAbono" style="margin-left: 3%" runat="server">

                <br />
                <div>
                    <h4><strong style="color: #5cb85c">Abono</strong></h4>


                </div>
                <asp:GridView ID="GridVAbono" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Style="font-size: larger" OnSelectedIndexChanged="GridPrestamo_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>

                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Cantidad" HeaderText="Cantidad"></asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Fecha" HeaderText="Fecha"></asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#5cb85c" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#67bd67" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </div>
        </article>

        <article class="col-xs-12 col-sm-12 col-md-6 col-lg-6">


            <article class="col-xs-12 col-sm-12 col-md-6 col-lg-6">

                <div>
                    <h4>

                        <strong style="color: #5cb85c">NOTA</strong>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxNota">Simbolos no permitidos</asp:RegularExpressionValidator>


                    </h4>


                </div>
                <div>
                    <strong>
                        <textarea id="tbxNota" runat="server" style="width: 200px; height: 83px; font-weight: bold;"></textarea></strong>
                </div>
                <div>
                    <strong>
                        <asp:Button Text="+Agregar" CssClass="btn btn-success" ID="btnNota" runat="server" Style="font-weight: bold" Width="95px" ValidationGroup="vgroup" OnClick="btnNota_Click" />
                        <asp:Button Text="Guardar" Visible="false" CssClass="btn btn-danger" ID="btnGuardarNonta" runat="server" Style="font-weight: bold" Width="94px" ValidationGroup="vgroup" OnClick="btnGuardarNonta_Click" />

                        <br />
                    </strong>
                </div>
                <br />
            </article>

            <article class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                <br />
                <br />
                <br />
                <asp:GridView ID="GridComentario" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="240px">
                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Comentario" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    </Columns>
                    <FooterStyle BackColor="#33cc33" ForeColor="#003399" />
                    <HeaderStyle BackColor="#33cc339" Font-Bold="True" ForeColor="white" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#33cc33" />
                    <SortedDescendingCellStyle BackColor="#33cc33" />
                    <SortedDescendingHeaderStyle BackColor="#33cc33" />
                </asp:GridView>
                <br />
            </article>



        </article>


    </div>
    <br />


    <div style="text-align: center">
        <strong>
            <asp:Button Text="&#9660;Imprimir&#9660;" Visible="false" CssClass="btn btn-success" ID="btnImprimir" runat="server" Height="66px" Style="font-weight: bold; font-size: large;" Width="280px" OnClick="btnImprimir_Click" />
        </strong>
    </div>


</asp:Content>
