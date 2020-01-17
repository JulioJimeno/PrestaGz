<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReCliente.aspx.cs" Inherits="PrestaGz.Registro.ReCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />
    <div class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">

        <h2><strong>&nbsp; Registro de cliente</strong></h2>

        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
            <br />
            <div>
                <label>Nombre</label>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxNombre" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxNombre">*</asp:RegularExpressionValidator>

                </strong>

                <asp:TextBox ID="tbxNombre" CssClass="form-control" runat="server" />

            </div>

            <div>
                <label>Cedula</label>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxCedula" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxCedula">*</asp:RegularExpressionValidator>

                </strong>

                <asp:TextBox ID="tbxCedula" CssClass="form-control" runat="server" />

            </div>

            <div>
                <label>Telefono</label>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxTelefono" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxTelefono">*</asp:RegularExpressionValidator>

                </strong>

                <asp:TextBox ID="tbxTelefono" CssClass="form-control" runat="server" />

            </div>

            <div>

                <div>
                    <strong>
                        <asp:Label Style="color: white" Text="Fecha de nacimiento" ID="lblEdad" runat="server" CssClass="w3-text-white" />
                    </strong>
                </div>
                <strong>
                    <asp:TextBox ID="tbxFecha" runat="server" class="w3-btn btn-primary" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 15px; color: white; font-size: small; font-weight: bold;" type='date' Height="37px" Width="173px" />

                </strong>

                <asp:TextBox ID="tbxFecha2" ReadOnly="true" Visible="false" CssClass="form-control" runat="server" Width="108px" />


            </div>

            <div>
                <label>Direccion</label>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxDireccion" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                   <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxDireccion">*</asp:RegularExpressionValidator>--%>

                </strong>

                <asp:TextBox ID="tbxDireccion" CssClass="form-control" runat="server" />

            </div>

            <div>
                <label>Cantidad vehiculo</label>
                <strong>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="Solo campos numericos" ForeColor="#CC0000" Style="font-size: small" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="vgroup" ControlToValidate="tbxVehiculo">*</asp:RegularExpressionValidator>

                </strong>

                <asp:TextBox ID="tbxVehiculo" CssClass="form-control" runat="server" />

            </div>


            <div>
                <!--PARA ABRIR EL DIALOGO   -->
                <strong>
                    <linkbutton type="button" id="btnUbicacion" runat="server" class="btn btn-success navbar-btn" data-toggle="modal" data-target="#myModal"><span style="font-size: 11pt"><strong>+Agregar Ubicacion</strong></span></linkbutton>
                </strong>
            </div>
            <br />

        </article>

        <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

            <br />
            <div>
                <label>Direccion de trabajo</label>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxDireccionTrabajo" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                   <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxDireccionTrabajo">*</asp:RegularExpressionValidator>--%>

                </strong>

                <asp:TextBox ID="tbxDireccionTrabajo" CssClass="form-control" runat="server" />

            </div>
            <div>
                <label>Telefono de trabajo</label>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxTelefonoTrabajo" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxTelefonoTrabajo">*</asp:RegularExpressionValidator>

                </strong>

                <asp:TextBox ID="tbxTelefonoTrabajo" CssClass="form-control" runat="server" />

            </div>

            <label>Estado civil</label>
            <div>
                <asp:RadioButton Text="Soltero" ID="radSoltero" AutoPostBack="true" runat="server" OnCheckedChanged="radSoltero_CheckedChanged" />
                <asp:RadioButton Text="Casado" ID="radCasado" AutoPostBack="true" runat="server" OnCheckedChanged="radCasado_CheckedChanged" />
            </div>

            <div>
                <label># de Hijo</label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Solo campos numericos" ForeColor="#CC0000" Style="font-size: small" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="vgroup" ControlToValidate="tbxHijo">*</asp:RegularExpressionValidator>

                <asp:TextBox ID="tbxHijo" CssClass="form-control" runat="server" Width="98px" />

            </div>



            <div>
                <label>Ingreso</label>
                <strong>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Solo campos numericos" ForeColor="#CC0000" Style="font-size: small" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="vgroup" ControlToValidate="tbxIngreo">*</asp:RegularExpressionValidator>

                </strong>

                <span style="font-size: large; color: #CC0000">*</span><asp:TextBox ID="tbxIngreo" CssClass="form-control" runat="server" Width="98px" />

            </div>

            <div>
                <label>Remesa</label>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Solo campos numericos" ForeColor="#CC0000" Style="font-size: small" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="vgroup" ControlToValidate="tbxRemesa">*</asp:RegularExpressionValidator>

                <asp:TextBox ID="tbxRemesa" CssClass="form-control" runat="server" Width="98px" />

            </div>
            <br />
        </article>

    </div>



    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="color: #ff0000" ValidationGroup="vgroup" ForeColor="#CC3300" />

    </div>

    <div>
        <br />
        &nbsp;
            <asp:Button ID="btnGuardar" Text="Guardar" runat="server" Style="font-size: large; color: white; font-weight: bold; border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93" Width="218px" ValidationGroup="vgroup" Height="54px" OnClick="btnGuardar_Click" />
    </div>


    <!--COMIENZA EL MODAL DE UBICACION-->
    <ul class="nav navbar-nav" style="color: #93beed">

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">


            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #1d65e6">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h2 class="modal-title" id="myModalLabel"><b style="color: white">UBICACION</b></h2>
                    </div>

                    <asp:UpdatePanel runat="server" UpdateMode="Conditional">

                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnMapa" />
                        </Triggers>

                        <ContentTemplate>

                            <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                                <div>
                                    <label style="color: black">&nbsp;Latitude y Longitude</label>
                                    <strong>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxlatitude" Style="font-size: large" ValidationGroup="vgrouplocation">*</asp:RequiredFieldValidator>

                                    </strong>

                                    <asp:TextBox ID="tbxlatitude" placeholder="Ejemplo:19.24007, -70.31890" CssClass="form-control" runat="server" />

                                </div>

                                <div>

                                    <asp:ImageButton ID="btnMapa" ImageUrl="~/Imagenes/GoogleMap.png" Height="50px" Width="50px" runat="server" OnClick="btnMapa_Click" />
                           
                                </div>


                            </article>


                            <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                                <div>
                                    <label style="color: black">&nbsp;Nombre de lugar</label>
                                    <strong>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxDescripcion" Style="font-size: large" ValidationGroup="vgrouplocation">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgrouplocation" ControlToValidate="tbxDescripcion">*</asp:RegularExpressionValidator>

                                    </strong>

                                    <asp:TextBox ID="tbxDescripcion" CssClass="form-control" runat="server" />
                                </div>

                                <div style="text-align: end">

                                    <asp:Button CssClass="btn btn-primary" ID="btnAgregar" Text="+ Agregar" runat="server" Style="font-weight: bold" OnClick="btnAgregar_Click" ValidationGroup="vgrouplocation" />

                                </div>
                                <br />
                            </article>

                            <div style="margin-left: 23%">
                                <div id="divEjemplo" runat="server" visible="false">
                                    <h2 style="color: red"><strong>Formato inccorrecto</strong></h2>
                                    <h3 style="color: black"><strong>Ejemplo:</strong>19.24007, -70.31890</h3>
                                </div>

                                <asp:GridView ID="GridLocation" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                    <Columns>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
                                        <asp:BoundField DataField="Longitude" HeaderText="Longitude" />

                                        <%--      <asp:TemplateField>
                                        <ItemTemplate >                             
                                           <asp:Button ID="btnQuitar" CssClass="btn btn-danger" Text="X" runat="server" Enabled="true" OnClick="btnQuitar_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#00cc66" Font-Bold="True" ForeColor="white" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>




                            </div>

                            <asp:Label ForeColor="Transparent" ID="lblIdCliente" Text="0" runat="server" />
                            </article>


                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <div class="modal-footer" style="background-color: cornflowerblue">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>


    </ul>

</asp:Content>
