<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoCliente.aspx.cs" Inherits="PrestaGz.Consulta.CoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <div id="divConsultaCliente" runat="server" class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
        <br />


        <div style="margin-left: 6.3%; margin-bottom: 1%">
            <h2><strong>Consulta Cliente</strong></h2>
            <div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxBuscar">Simbolos no permitidos</asp:RegularExpressionValidator>
            </div>
            <asp:DropDownList ID="dropCliente" runat="server" CssClass="btn btn-primary" Width="184px">
                <asp:ListItem Value="0">Nombre</asp:ListItem>
                <asp:ListItem Value="1">Cedula</asp:ListItem>
                <asp:ListItem Value="2">Telefono</asp:ListItem>
                <asp:ListItem Value="3">Codigo</asp:ListItem>
                <asp:ListItem Value="4">Todos</asp:ListItem>
            </asp:DropDownList>

        </div>

        <article class="col-xs-9 col-sm-9 col-md-9 col-lg-9">

            <div style="margin-left: 6%">

                <asp:TextBox ID="tbxBuscar" ValidationGroup="vgroup" CssClass="form-control" runat="server" />
            </div>

        </article>

        <article class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
            <div id="divBuscar" runat="server" style="margin-left: -50%">
                <asp:Button ID="btnBuscarCliente" CssClass="btn btn-success" Width="95px" ValidationGroup="vgroup" Text="&#9668;Buscar&#9658;" runat="server" Style="font-weight: bold" OnClick="btnBuscarCliente_Click" />
            </div>
            <br />
        </article>

       <%-- <div style="text-align: center" runat="server" id="divMovilGiro" visible="false">
            <asp:Image ImageUrl="~/Imagenes/girar2.png" runat="server" />
            <h2><strong>Girar el dispositivo.!!</strong></h2>
        </div>--%>

    </div>
    <div id="divGridCliente" runat="server" style="overflow-x:scroll; overflow-y:scroll; height:100%;width:100%">

        <strong>
            <br />
            <div translate="no">
                <asp:GridView ID="GridCliente" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Style="font-size: larger" OnSelectedIndexChanged="GridCliente_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Editar.png" ShowSelectButton="True" HeaderText="Edit" />
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="ClienteId" HeaderText="Codigo">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Nombre" HeaderText="Nombre">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Telefono" HeaderText="Telefono">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Cedula" HeaderText="Cedula">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Direccion" HeaderText="Direccion">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="FechaRegistro" HeaderText="Registro">
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
            </div>
            <br />
        </strong>



    </div>
</asp:Content>
