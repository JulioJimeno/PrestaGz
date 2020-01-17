<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RePrestamo.aspx.cs" Inherits="PrestaGz.Registro.RePrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <div id="divBuscarCliente" runat="server" class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">

        <div style="text-align: center">
            <!--PARA ABRIR EL DIALOGO   -->
            <linkbutton type="button" id="btnBuscar" runat="server" class="btn btn-success navbar-btn" data-toggle="modal" data-target="#myModal"><span style="font-size: 200%; height:25%; width:45%"><strong>Buscar Cliente</strong></span></linkbutton>
        </div>

    </div>


    <div id="divCliente" runat="server" class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
        <h2><strong>&nbsp; Registro de prestamo</strong></h2>
        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
            <br />
            <div>
                <label>Nombre cliente</label>

                <asp:TextBox ID="tbxNombre" CssClass="form-control" ReadOnly="true" runat="server" />
            </div>
            <div>
                <label>Telefono</label>
                <asp:TextBox ID="tbxTelefono" CssClass="form-control" ReadOnly="true" runat="server" />
            </div>

        </article>
        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
            <br />
            <div>
                <label>Cedula</label>
                <asp:TextBox ID="tbxCedula" CssClass="form-control" ReadOnly="true" runat="server" />
            </div>
            <div>
                <label>Direccion</label>
                <asp:TextBox ID="tbxDireccion" CssClass="form-control" ReadOnly="true" runat="server" />

            </div>
            <br />
        </article>

        <div style="margin-left: 2%">
            <label>Codigo cliente</label>
            <asp:TextBox ID="tbxCodigoCliente" CssClass="form-control" ReadOnly="true" runat="server" Width="128px" />
            <br />

        </div>


    </div>

    <div id="divPreta" visible="false" runat="server" class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
            <br />
            <div id="divMonto" runat="server">
                <label>Monto a prestar</label>

                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxMonto" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="vgroup" ControlToValidate="tbxMonto">*</asp:RegularExpressionValidator>

                    <asp:TextBox ID="tbxMonto" CssClass="form-control" runat="server" Width="160px" Style="font-weight: bold" />


                </strong>

            </div>
            <div id="divFecha" runat="server">

                <%-- <div>
                     <label><strong>Asignar tiempo por:</strong></label>

                </div>--%>
                <div style="margin-top:2%;margin-bottom:-2.5%">
                    <asp:RadioButton ID="radbNumeroCuota"  ForeColor="#68bd68" AutoPostBack="true" Checked="true"  Text="_# Cuota" runat="server" Height="30px" OnCheckedChanged="radbNumeroCuota_CheckedChanged" style="text-decoration: underline; color: #68BD68; font-size:10px;" />
                    <asp:RadioButton ID="radbFecha"  ForeColor="#ff5050" AutoPostBack="true" Checked="false" Text="_Fecha Termino" runat="server" Height="30px" OnCheckedChanged="radbFecha_CheckedChanged" style="text-decoration: underline; font-size: 10px" />
                </div>


                <div id="divFinalSaldo" visible="false" runat="server">
                    <strong>
                        <%--<asp:Label ForeColor="White"  Text="Fecha final de saldo" ID="lblEdad" runat="server" CssClass="w3-text-white" />--%>
                        <asp:TextBox ID="tbxFecha"  runat="server" class="w3-btn btn-primary" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 15px; color: white; font-weight: bold; font-size: small;" type='date' Width="185px" />

                    </strong>

                </div>
                <div id="divCantidadCuota" runat="server">
                    <asp:TextBox ID="tbxCantidadCuota" placeholder="# de cuotas.." CssClass="form-control" runat="server" Width="160px"  />
                </div>


            </div>

        </article>
        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
            <div>
                <br />
                <div>
                    <label>Cuota</label>

                </div>
                <strong>
                    <asp:DropDownList ID="dropCuota" CssClass="btn btn-primary" AutoPostBack="true" runat="server" Height="33px" Width="142px" Style="font-weight: bold" OnTextChanged="dropCuota_TextChanged">
                        <asp:ListItem Text="Mensual" Value="0" />
                        <asp:ListItem Text="Quincenal" Value="1" />
                        <asp:ListItem Value="2">Diario</asp:ListItem>

                    </asp:DropDownList>
                    &nbsp;
                    
                </strong>
            </div>
            <div>
                <div>
                    <div>
                        <label>Taza %</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxTaza" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo campos numericos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="vgroup" ControlToValidate="tbxTaza">*</asp:RegularExpressionValidator>

                        </strong>

                    </div>
                    <asp:TextBox ID="tbxTaza" runat="server" Width="63px" Style="font-weight: bold; border-radius: 5px;" Height="35px" />

                    <asp:Button Text="Calcular" CssClass="btn btn-success" ID="btnCalcular" runat="server" Style="font-weight: bold" Width="77px" OnClick="btnCalcular_Click" ValidationGroup="vgroup" />


                </div>

            </div>
            <br />



        </article>

        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
            <div id="divTotal" runat="server">
                <label>
                    &nbsp;&nbsp;&nbsp; $ Cuotas</label>
                <div class="text-center">
                    <strong>
                        <asp:TextBox ID="tbxCuotaPrestar" ReadOnly="true" Style="border-bottom: 2.5px solid #848484; text-align: center; margin-left: 1%; margin-right: 1%; border-right: 2.5px solid #848484; border-radius: 10px; background-color: #f7f7f7; opacity: 2; font-size: large; font-weight: bold;" CssClass="form-control" runat="server" Height="44px" Width="180px" />

                    </strong>
                </div>


                <label>&nbsp;&nbsp;&nbsp; Capital + Interes</label>
                <div class="text-center">
                    <strong>
                        <asp:TextBox ID="tbxtotal" ReadOnly="true" Style="border-bottom: 2.5px solid #848484; text-align: center; margin-left: 1%; margin-right: 1%; border-right: 2.5px solid #848484; border-radius: 10px; background-color: #f7f7f7; opacity: 2; font-size: large; font-weight: bold;" CssClass="form-control" runat="server" Height="44px" Width="180px" />

                    </strong>
                </div>
            </div>
            <br />
        </article>

        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

            <label id="lblInteres" runat="server" translate="no">&nbsp;&nbsp;&nbsp;Interes</label>
            <div class="text-center">
                <strong>
                    <asp:TextBox ID="tbxInteres" ReadOnly="true" Style="border-bottom: 2.5px solid #848484; text-align: center; margin-left: 1%; margin-right: 1%; border-right: 2.5px solid #848484; border-radius: 10px; background-color: #f7f7f7; opacity: 2; font-size: large; font-weight: bold;" CssClass="form-control" runat="server" Height="44px" Width="180px" />

                </strong>
            </div>

        </article>
        <br />
    </div>
    <br />
    <div id="divNota" runat="server" visible="false" class="row" style="border-bottom: 2.5px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 2px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">

        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
            <div>
                <h4><strong>NOTA</strong>  <strong>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: small" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxNota">Simbolos no permitidos</asp:RegularExpressionValidator>

                </strong></h4>

            </div>
            <div>
                <strong>
                    <textarea id="tbxNota" runat="server" style="width: 90%; height: 140px; font-weight: bold;"></textarea></strong>
            </div>
            <div>
                <strong>
                    <asp:Button Text="+Agregar Nota" CssClass="btn btn-success" ID="btnNota" runat="server" Style="font-weight: bold" Width="160px" OnClick="btnNota_Click" ValidationGroup="vgroup" />
                    <br />
                </strong>
            </div>
            <br />
        </article>

        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
            <div style="margin-left: -13%">
                <br />
                <br />

                <asp:GridView ID="GridComentario" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="180px" Style="font-size: small">
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


            </div>
        </article>

    </div>



    <div style="text-align: center; opacity: 0.93">
        <br />
        <asp:Button ID="btnGuardar" Visible="false" CssClass="btn btn-success" Text="&#9668; GUARDAR &#9658;" runat="server" Height="63px" Width="369px" Style="font-size: x-large" OnClick="btnGuardar_Click" ValidationGroup="vgroup" />
    </div>

    <div id="divImprimir" visible="false" runat="server" style="text-align: center">
        <strong>
            <asp:Button Text="Imprimir" ID="Imprimir" CssClass="btn btn-success" runat="server" OnClick="Imprimir_Click" Style="font-size: xx-large; font-weight: bold" Width="367px" />
        </strong>
    </div>


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

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo vacio" ForeColor="#CC3300" ControlToValidate="tbxBuscar" Style="font-size: large" ValidationGroup="vgroupCliente">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroupCliente" ControlToValidate="tbxBuscar">Simbolos no permitidos</asp:RegularExpressionValidator>


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

                                    <asp:TextBox ID="tbxBuscar" ValidationGroup="vgroupCliente" CssClass="form-control" runat="server" />
                                </div>

                            </article>

                            <article class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                <div style="margin-left: -35%">
                                    <asp:Button ID="btnBuscarCliente" ValidationGroup="vgroupCliente" CssClass="btn btn-success" Width="109px" Text="&#9668;Buscar&#9658;" runat="server" Style="font-weight: bold" OnClick="btnBuscarCliente_Click" />
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
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-BackColor="#156ab9" HeaderStyle-ForeColor="white" ItemStyle-BorderColor="Transparent" />
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" HeaderStyle-BackColor="#156ab9" HeaderStyle-ForeColor="white" ItemStyle-BorderColor="Transparent" />
                                        <asp:BoundField DataField="Cedula" HeaderText="Cedula" HeaderStyle-BackColor="#156ab9" HeaderStyle-ForeColor="white" ItemStyle-BorderColor="Transparent" />
                                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" HeaderStyle-BackColor="#156ab9" HeaderStyle-ForeColor="white" ItemStyle-BorderColor="Transparent" />

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

</asp:Content>
