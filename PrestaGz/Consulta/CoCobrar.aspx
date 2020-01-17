<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CoCobrar.aspx.cs" Inherits="PrestaGz.Consulta.CoCobrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div id="div1" runat="server" class="row" style="border-bottom: 6px solid #848484; text-align: center; margin-left: 15%; margin-right: 15%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
        <br />
        <h1><strong>Gestion de Cobro</strong></h1>
    </div>


    <br />
    <div id="divConsultaPrestamo" runat="server" class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxBuscar">Simbolos no permitidos</asp:RegularExpressionValidator>

        <br />
        <div style="margin-left: 6%; margin-bottom: 1%">

            <asp:DropDownList ID="dropCliente" runat="server" AutoPostBack="true" CssClass="btn btn-primary" Width="184px" Style="font-weight: bold" OnTextChanged="dropCliente_TextChanged">

                <asp:ListItem Value="0">Abono o Mora</asp:ListItem>
                <asp:ListItem Value="1">Abono</asp:ListItem>
                <asp:ListItem Value="2">Mora</asp:ListItem>
                <asp:ListItem Value="3">Nombre</asp:ListItem>
                <asp:ListItem Value="4">Cedula</asp:ListItem>
                <asp:ListItem Value="5">Telefono</asp:ListItem>
                <asp:ListItem Value="6">Codigo Prestamo</asp:ListItem>

            </asp:DropDownList>


        </div>

        <article class="col-xs-9 col-sm-9 col-md-9 col-lg-9">

            <div style="margin-left: 6%">

                <asp:TextBox ID="tbxBuscar" ReadOnly="true" ValidationGroup="vgroup" CssClass="form-control" runat="server" />
            </div>

        </article>

        <article class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
            <div id="divBuscar" runat="server" style="margin-left: -40%">
                <asp:Button ID="btnBuscarCliente" CssClass="btn btn-success" ValidationGroup="vgroup" Width="109px" Text="&#9668;Buscar&#9658;" runat="server" Style="font-weight: bold" OnClick="btnBuscarCliente_Click" />
            </div>
            <br />
        </article>

        <%--  <div style="text-align:center" runat="server" id="divMovilGiro" visible="false"> 
            <asp:Image ImageUrl="~/Imagenes/girar2.png" runat="server" /> <h2><strong>Girar el dispositivo.!!</strong></h2>
        </div>--%>
    </div>
    <div id="divGridPrestamo" runat="server" style="overflow-x:scroll; overflow-y:scroll; height:100%;width:100%">

        <strong>
            <br />
            <div>

                <strong>
                    <asp:GridView ID="GridPrestamo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Style="font-size: small" OnSelectedIndexChanged="GridPrestamo_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>


                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Maps.png" ShowSelectButton="True" />


                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="PrestamoId" HeaderText="Codigo">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Nombre" HeaderText="Nombre Cliente">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>




                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="CantidadCuota" HeaderText="Cuota">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>


                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Total" HeaderText="Capital">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>

                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Lugar" HeaderText="Lugar">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>

                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Latitude" HeaderText="Latitude">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>

                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Longitude" HeaderText="Longitude">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>

                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Estado" HeaderText="Estado">
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
                </strong>

            </div>
            <br />
        </strong>

    </div>

    <div style="text-align: center">
        <strong>
            <asp:Button Text="&#9660;Descargar Excel&#9660;" Visible="false" CssClass="btn btn-success" ID="btnDescargar" runat="server" Height="66px" Style="font-weight: bold; font-size: large;" Width="280px" OnClick="btnDescargar_Click1" />
        </strong>
    </div>

</asp:Content>
