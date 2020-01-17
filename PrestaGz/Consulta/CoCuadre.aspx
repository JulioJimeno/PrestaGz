<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoCuadre.aspx.cs" Inherits="PrestaGz.Consulta.CoCuadre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <br />
    <br />
    <div id="DivBuscar" runat="server" style="border-bottom: 6px solid #848484; text-align: start; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">

        <br />
       <div style="text-align:center">
           <h2><strong>&nbsp; Consulta de Cuadre</strong></h2>
       </div>
       
        <div style="text-align: center">
            <div style="margin-left: -5%">
                <strong>
                    <asp:Label Text="Buscar " runat="server" CssClass="w3-text-white" Style="font-size: large" /></strong>

            </div>
            <asp:DropDownList CssClass="btn btn-primary" ID="dropCuadre" AutoPostBack="true" runat="server" Style="font-weight: bold; font-size: large;" Width="271px" OnTextChanged="dropCuadre_TextChanged">
                <asp:ListItem Value="0">Hoy</asp:ListItem>
                <asp:ListItem Value="1">Fecha</asp:ListItem>

            </asp:DropDownList>

        </div>
        <div id="Divfecha" visible="false" style="margin-left: 22.5%" runat="server">


            <strong>
                <asp:TextBox ID="tbxFecha" runat="server" class="w3-btn btn-primary" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 15px; color: white; font-weight: bold;" type='date' Width="203px" />
                <asp:Button ID="btnBuscarFecha" CssClass="btn btn-success" Text="Buscar Fecha" runat="server" Style="font-weight: bold" Width="133px" Height="41px" OnClick="btnBuscarFecha_Click" />
            </strong>

        </div>
        <br />


    </div>

    <div id="DivGridCuadre" style="margin-left: 2%;" runat="server">
        <br />

        <strong>
            <div class="text-center" style="overflow-x:scroll; overflow-y:scroll; height:100%;width:100%">
            <asp:GridView ID="GridPrestamo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Style="font-size: small" OnSelectedIndexChanged="GridPrestamo_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField ButtonType="Image" HeaderText="Print" SelectImageUrl="~/Imagenes/Printer.png" ShowSelectButton="True" />


                    <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="CuadreId" HeaderText="Codigo">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>

                       <asp:BoundField ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" DataField="UsuarioCoId" HeaderText="UsuarioId">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Nombre" HeaderText="Usuario">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                   
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
    <div style="text-align: center">
    </div>
</asp:Content>
