<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReAbono.aspx.cs" Inherits="PrestaGz.Consulta.BuscarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <Triggers>

            <asp:PostBackTrigger ControlID="btnAgregar" />
            <asp:PostBackTrigger ControlID="btnGuardar" />

        </Triggers>

        <ContentTemplate>

            <div id="divCliente" runat="server" class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">

                <div style="text-align: center">
                    <!--PARA ABRIR EL DIALOGO   -->
                    <linkbutton type="button" id="btnBuscar" runat="server" class="btn btn-success navbar-btn" data-toggle="modal" data-target="#myModal"><span style="font-size: 200%; height:25%; width:45%"><strong>Buscar Cliente</strong></span></linkbutton>
                </div>

                <div id="divCliente2" runat="server">
                    <h2><strong>&nbsp; Registro de abono</strong></h2>
                    <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                        <br />
                        <div>
                            <label>Nombre cliente</label>
                            <strong>

                                <asp:TextBox ID="tbxNombre" CssClass="form-control" ReadOnly="true" runat="server" Style="font-weight: bold" />
                            </strong>
                        </div>
                        <div>
                            <label>Telefono</label>
                            <strong>
                                <asp:TextBox ID="tbxTelefono" CssClass="form-control" ReadOnly="true" runat="server" Style="font-weight: bold" />
                            </strong>
                        </div>

                        <div>
                            <label>Codigo cliente</label>
                            <strong>
                                <asp:TextBox ID="tbxCliente" CssClass="form-control" ReadOnly="true" runat="server" Width="94px" Style="font-weight: bold" />
                            </strong>
                        </div>

                    </article>
                    <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                        <br />
                        <div>
                            <label>Cedula</label>
                            <strong>
                                <asp:TextBox ID="tbxCedula" CssClass="form-control" ReadOnly="true" runat="server" Style="font-weight: bold" />
                            </strong>
                        </div>
                        <div>
                            <label>Direccion</label>
                            <strong>
                                <asp:TextBox ID="tbxDireccion" CssClass="form-control" ReadOnly="true" runat="server" Style="font-weight: bold" />

                            </strong>

                        </div>
                        <div>
                            <label>Codigo prestamo</label>
                            <strong>
                                <asp:TextBox ID="tbxPrestamo" CssClass="form-control" ReadOnly="true" runat="server" Width="94px" Style="font-weight: bold" />
                            </strong>
                        </div>

                        <br />
                    </article>
                </div>
            </div>
            <br />
            <div id="div1" visible="false" runat="server" class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
                <br />
                <article class="col-xs-6 col-sm-6 col-md-3 col-lg-3">

                    <label>Fecha de termino</label>
                    <asp:TextBox ID="tbxFecha" CssClass="form-control" ReadOnly="true" runat="server" Width="118px" Style="font-weight: bold" />


                </article>

                <article class="col-xs-6 col-sm-6 col-md-3 col-lg-3">

                    <label>Monto Total</label>

                    <asp:TextBox ID="tbxMontoTotal" CssClass="form-control" ReadOnly="true" runat="server" Width="118px" Style="font-weight: bold" />


                </article>

                <article class="col-xs-6 col-sm-6 col-md-3 col-lg-3">

                    <label>Monto Pendiente</label>

                    <asp:TextBox ID="tbxPendiente" CssClass="form-control" ReadOnly="true" runat="server" Width="177px" Style="font-weight: bold" />


                </article>

                <article class="col-xs-3 col-sm-3 col-md-3 col-lg-3">

                    <label>Cuota</label>

                    <asp:TextBox ID="tbxCuota" ReadOnly="true" CssClass="form-control" runat="server" Width="118px" Style="font-weight: bold" />

                </article>
                <br />
                <br />
                <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">


                    <div id="divGrdiAbono" runat="server">
                        <br />
                        <strong>
                            <asp:GridView ID="gridAbono" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Style="font-size: 100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>

                                    <asp:BoundField DataField="Cantidad" HeaderText="Abono" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#000065" />
                            </asp:GridView>
                            <br />
                        </strong>
                    </div>
                </article>

                <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                    <label id="lblAbono" runat="server" visible="false">Abono</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxAbono" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="vgroup" ControlToValidate="tbxAbono">*</asp:RegularExpressionValidator>


                    <asp:TextBox ID="tbxAbono" CssClass="form-control" Visible="false" runat="server" Width="118px" Style="font-weight: bold" />
                    <asp:Button Text="+Agregar" ID="btnAgregar" Visible="false" CssClass="btn btn-success" runat="server" Style="font-weight: bold" Width="103px" OnClick="btnAgregar_Click" ValidationGroup="vgroup" />

                </article>


                <div visible="false" runat="server" id="divMora" class="w3-justify" style="margin-left: 51.5%">
                    <!--PARA ABRIR EL DIALOGO   -->
                    <linkbutton style="width: 140px; height: 50px" type="button" id="Linkbutton1" runat="server" class="btn btn-danger navbar-btn" data-toggle="modal" data-target="#myModalMora"><span style="font-size: 90%; width:20px;height:50px"><strong >Mora acomulada<br />
                click aqui!</strong></span></linkbutton>


                </div>

            </div>

            <div style="text-align: center">

                <br />

                <asp:Button Visible="false" Text="&#9668;Guardar&#9658;" ID="btnGuardar" Style="font-weight: bold; font-size: x-large;" CssClass="btn btn-success" runat="server" Height="53px" Width="437px" OnClick="btnGuardar_Click" />
                <asp:Label ID="lblgrid" ForeColor="Transparent" runat="server" />
            </div>

            <div id="divImprimir" visible="false" runat="server" style="text-align: center">
                <strong>
                    <asp:Button Text="Imprimir" ID="Imprimir" CssClass="btn btn-success" runat="server" Style="font-size: xx-large; font-weight: bold" Width="367px" OnClick="Imprimir_Click" />
                </strong>
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

    <!--COMIENZA EL DIALOGO BUSCAR CLIENTE -->
    <ul class="nav navbar-nav" style="color: #93beed">

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #007bff">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h2 class="modal-title" id="myModalLabel"><b style="color: white">BUSCAR CLIENTE</b></h2>
                    </div>

                    <asp:UpdatePanel ID="PanelCliente" UpdateMode="Conditional" runat="server">
                        <Triggers>

                            <asp:PostBackTrigger ControlID="gridCliente" />
                        </Triggers>
                        <ContentTemplate>

                            <div style="margin-left: 25%">

                                <%-- <asp:Label ForeColor="black" Text="Buscar por" runat="server" />--%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo vacio" ForeColor="#CC3300" ControlToValidate="tbxBuscar" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxBuscar">Simbolos no permitidos</asp:RegularExpressionValidator>

                            </div>

                            <div style="margin-left: 7%; margin-bottom: 1%">

                                <asp:DropDownList ID="dropCliente" runat="server" CssClass="btn btn-primary" Width="184px">
                                    <asp:ListItem Value="0">Nombre</asp:ListItem>
                                    <asp:ListItem Value="1">Cedula</asp:ListItem>
                                    <asp:ListItem Value="2">Telefono</asp:ListItem>
                                    <asp:ListItem Value="3">Codigo</asp:ListItem>
                                </asp:DropDownList>

                            </div>

                            <article class="col-xs-9 col-sm-9 col-md-9 col-lg-9">

                                <div style="margin-left: 6%">

                                    <asp:TextBox ID="tbxBuscar" ValidationGroup="vgroup" CssClass="form-control" runat="server" />
                                </div>

                            </article>

                            <article class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                <div style="margin-left: -50%">
                                    <asp:Button ID="btnBuscarCliente" CssClass="btn btn-success" Width="90px" Text="&#9668;Buscar&#9658;" runat="server" OnClick="btnBuscarCliente_Click" Style="font-weight: bold" />
                                </div>
                                <br />
                            </article>

                            <div style="margin-left: 6%">

                                <div>
                                    <asp:Label ID="lblNoEncontrado" Visible="false" Style=" font-weight: bold" ForeColor="#cc0000" Text="Busqueda no encontrada.!!" runat="server" />
                                </div>
                                
                                <asp:GridView ID="gridCliente" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="gridCliente_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="ClienteId" ItemStyle-ForeColor="Transparent" HeaderStyle-BackColor="#156ab9" HeaderStyle-ForeColor="white" ItemStyle-BorderColor="Transparent" />

                                        <asp:BoundField DataField="PrestamoId" HeaderText="Codigo" HeaderStyle-BackColor="#156ab9" HeaderStyle-ForeColor="white" ItemStyle-BorderColor="Transparent" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-BackColor="#156ab9" HeaderStyle-ForeColor="white" ItemStyle-BorderColor="Transparent" />
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" HeaderStyle-BackColor="#156ab9" HeaderStyle-ForeColor="white" ItemStyle-BorderColor="Transparent" />
                                        <asp:BoundField DataField="Total" HeaderText="Prestamo" HeaderStyle-BackColor="#156ab9" HeaderStyle-ForeColor="white" ItemStyle-BorderColor="Transparent" />

                                        <asp:CommandField ButtonType="Image" ShowSelectButton="True"
                                            ItemStyle-BackColor="Transparent"
                                            ItemStyle-BorderColor="Transparent"
                                            HeaderStyle-BorderColor="Transparent"
                                            HeaderStyle-BackColor="#166ab9"
                                            SelectImageUrl="~/Imagenes/Button1.png">


                                            <ControlStyle BorderColor="Transparent"></ControlStyle>

                                            <HeaderStyle BorderColor="Transparent" BackColor="Transparent"></HeaderStyle>

                                            <ItemStyle BackColor="Transparent" BorderColor="Transparent"></ItemStyle>
                                        </asp:CommandField>
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                            </div>



                        </ContentTemplate>
                    </asp:UpdatePanel>



                    <asp:Label ForeColor="Transparent" ID="lblIdCliente" Text="0" runat="server" />
                </div>
                <div class="modal-footer" style="background-color: cornflowerblue">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>

    </ul>
    <!--TERMINA MODAL CLIENTE -->

    <!--COMIENZA MODAL MORA -->

    <ul class="nav navbar-nav" style="color: #93beed">

        <div class="modal fade" id="myModalMora" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #dc3545">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h2 class="modal-title" id="myModalLabel"><b style="color: white">REGISTRO MORA</b></h2>
                    </div>

                    <div class="row">
                        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                            <div id="divFondo" runat="server" style="background-color: #848484; height: 25%; width: 100%; text-align: center">

                                <br />
                                <br />
                                <h2 id="H2Mora" runat="server">AGREGAR UNA MORA.!</h2>
                                <br />
                                <br />

                            </div>

                        </article>

                        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                            <div>
                                <label style="color: black">Cantidad de atraso</label>
                                <asp:TextBox ID="tbxAtraso" ReadOnly="true" Width="125px" CssClass="form-control" runat="server" />
                            </div>

                            <label style="color: black" id="Label1">Mora</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxAgregarMora" Style="font-size: large" ValidationGroup="vgroupMora">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="vgroupMora" ControlToValidate="tbxAbono">*</asp:RegularExpressionValidator>


                            <asp:TextBox ID="tbxAgregarMora" CssClass="form-control" runat="server" Width="118px" Style="font-weight: bold" />
                            <asp:Button Text="+Agregar" ID="btnAgregarMora" CssClass="btn btn-success" runat="server" Style="font-weight: bold" Width="103px" ValidationGroup="vgroupMora" OnClick="btnAgregarMora_Click" />


                        </article>
                        <br />
                    </div>
                </div>
                <div class="modal-footer" style="background-color: #e48582">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>

    </ul>
    <!-- TERMINA MODAL MORA -->

    <br />


</asp:Content>
