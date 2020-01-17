<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAdm.aspx.cs" Inherits="PrestaGz.Consulta.MenuAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>


            <div id="divConsultaPrestamo" runat="server" class="row" style="border-bottom: 6px solid #848484; text-align: center; margin-left: 15%; margin-right: 15%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
                <br />
                <h1><strong>Menu Administrativo</strong></h1>
            </div>


            <div class="row" style="text-align: center">



                <br />
                <br />

                <div style="text-align: center" class="text-left">
                    <asp:DropDownList CssClass="btn btn-primary" AutoPostBack="true" ID="dropConsulta" runat="server" Style="font-weight: bold; text-align: center; font-size: x-large;" Height="65px" Width="285px" OnSelectedIndexChanged="dropConsulta_SelectedIndexChanged">
                        <asp:ListItem>Consultas</asp:ListItem>
                        <asp:ListItem Value="0">Consulta Cuadre</asp:ListItem>
                        <asp:ListItem Value="1">Consulta Prestamo</asp:ListItem>
                        <asp:ListItem Value="2">Consulta Cliente</asp:ListItem>
                        <asp:ListItem Value="3">Consulta Usuario</asp:ListItem>

                    </asp:DropDownList>

                    <asp:Button ID="btnGestionarPrestamo" CssClass="btn btn-warning" Text="Gestionar Cobro" runat="server" Style="text-align: start; font-weight: bold; font-size: x-large;" Height="65px" Width="285px" OnClick="btnGestionarPrestamo_Click" />


                    <asp:DropDownList CssClass="btn btn-success" AutoPostBack="true" ID="dropRegistro" runat="server" Style="font-weight: bold; font-size: x-large;" Height="65px" Width="285px" OnSelectedIndexChanged="dropRegistro_SelectedIndexChanged">
                        <asp:ListItem>Registros</asp:ListItem>
                        <asp:ListItem Value="0">Crear Cliente</asp:ListItem>
                        <asp:ListItem Value="1">Registrar Prestador</asp:ListItem>
                    </asp:DropDownList>


                    <asp:DropDownList CssClass="btn btn-danger" AutoPostBack="true" ID="dropConfiguracion" runat="server" Style="font-weight: bold; font-size: x-large;" Height="65px" Width="285px" OnSelectedIndexChanged="dropConfiguracion_SelectedIndexChanged">
                        <asp:ListItem>Configuracion</asp:ListItem>
                        <asp:ListItem Value="0">Configuaracion Usuario</asp:ListItem>
                        <asp:ListItem Value="1">Configuaracion Empresa</asp:ListItem>
                        <asp:ListItem Value="2">Pagos de Servicio</asp:ListItem>
                    </asp:DropDownList>

                </div>

            </div>
            <br />


            <div id="divMenu" runat="server" class="row" style="border-bottom: 6px solid #848484; margin-left: 3%; margin-right: 3%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">

                <br />

                <article class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                    <div id="divGridPrestamo" runat="server">

                        <br />
                        <label style="font-size: medium">
                            Ultimos 5 Prestamos</label>

                        <div id="divInfo" visible="false" runat="server" style="text-align: center; border-bottom: 6px solid #848484; margin-left: 2%; height: 100%; width: 100%; border-right: 5px solid #848484; border-radius: 15px; background-color: #eeebeb; opacity: 0.93">
                            <br />
                            <br />
                            <h3 style="width: 363px; height: 100px; color: black"><strong><em>No hay registro aun</em></strong></h3>
                        </div>

                        <strong>
                            <asp:GridView ID="GridPrestamo" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Style="font-size: medium">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>

                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="PrestamoId" HeaderText="Codigo">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Nombre" HeaderText="Nombre Cliente">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>


                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="Total" HeaderText="Capital">
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






                </article>
                <br />

                <article class="col-xs-12 col-sm-12 col-md-6 col-lg-6">

                    <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                        <div>

                            <label style="font-size: medium">Historial</label>
                            <strong>
                                <asp:TextBox ID="tbxTotalPrestado" ReadOnly="true" CssClass="form-control" runat="server" Height="64px" Style="font-size: small; font-weight: bold;" Width="150px" />

                            </strong>

                        </div>

                        <div>
                            <label style="font-size: medium">Prestamo Hoy</label>
                            <strong>
                                <asp:TextBox ID="tbxPrestadoDiario" ReadOnly="true" CssClass="form-control" runat="server" Height="64px" Style="font-size: small; font-weight: bold;" Width="150px" />

                            </strong>

                            <br />

                        </div>
                    </article>
                    <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                        <div>

                            <label style="font-size: medium">Cobrado hoy</label>
                            <strong>
                                <asp:TextBox ID="tbxCobradoHoy" ReadOnly="true" CssClass="form-control" runat="server" Height="64px" Style="font-size: small; font-weight: bold;" Width="150px" />

                            </strong>

                        </div>
                    </article>


                </article>


            </div>

        </ContentTemplate>


    </asp:UpdatePanel>


    <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>

            <div style="width: 100%; height: 100%; text-align: center; top: 0; left: 0; right: 0; bottom: 0; margin: auto; position: absolute; position: fixed">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <img src="/Imagenes/loader2.gif" style="height: 200px; width: 290px" />


            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
