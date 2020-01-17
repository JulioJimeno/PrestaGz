<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReUsuario.aspx.cs" Inherits="PrestaGz.Registro.ReUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">


        <Triggers>

            <asp:PostBackTrigger ControlID="btnGuardar" />


        </Triggers>

        <ContentTemplate>


            <div class="row" style="border-bottom: 6px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
                <br />
                <h2 id="H2Colaborador" runat="server" visible="false" style="margin-left: 1%"><strong>REGISTRAR PRESTADOR </strong></h2>
                <h2 id="H2Administativo" runat="server" visible="false" style="margin-left: 1%"><strong>REGISTRO DE ADMINISTRADOR </strong></h2>
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
                        <label>Telefono</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxTelefono" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxTelefono">*</asp:RegularExpressionValidator>

                        </strong>

                        <asp:TextBox ID="tbxTelefono" CssClass="form-control" runat="server" />

                    </div>

                    <div id="divRnc" runat="server" visible="true">
                        <label>RNC O CEDULA</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxRnc" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxRnc">*</asp:RegularExpressionValidator>

                        </strong>

                        <asp:TextBox ID="tbxRnc" CssClass="form-control" runat="server" />

                    </div>

                </article>

                <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    <br />
                    <div>
                        <label>Correo electronico</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxCorreo" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>

                        </strong>

                        <asp:TextBox ID="tbxCorreo" TextMode="Email" CssClass="form-control" runat="server" />

                    </div>

                    <div>
                        <label>Contrase&ntilde;a</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxContrasena" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxContrasena">*</asp:RegularExpressionValidator>

                        </strong>

                        <asp:TextBox ID="tbxContrasena" CssClass="form-control" runat="server" TextMode="Password" />

                    </div>

                    <div>
                        <label>Confirmar Contrase&ntilde;a</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxConfirmar" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbxContrasena" ControlToValidate="tbxConfirmar" Style="color: #CC0000"></asp:CompareValidator>
                        </strong>

                        <asp:TextBox ID="tbxConfirmar" CssClass="form-control" runat="server" TextMode="Password" ValidationGroup="vgroup" />
                        <br />
                    </div>

                </article>



<%--                <div id="divBanco" runat="server">

                    <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">



                        <h2 style="margin-left: 1%"><strong>REGISTRO BANCARIO </strong></h2>
                        <div>
                            <label>Nombre banco</label>
                            <strong>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxBanco" Style="font-size: x-small" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: x-small" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxBanco">*</asp:RegularExpressionValidator>

                            </strong>

                            <asp:TextBox ID="tbxBanco" CssClass="form-control" runat="server" />

                        </div>

                        <div>
                            <div>
                                <label>Tipo cuenta</label>
                            </div>

                            <asp:DropDownList CssClass="btn btn-primary" ID="dropTipoCuenta" runat="server" Style="font-weight: bold" Height="35px" Width="153px">
                                <asp:ListItem Text="Seleccione" />
                                <asp:ListItem Value="0" Text="Credito" />
                                <asp:ListItem Value="1" Text="Corriente" />
                                <asp:ListItem Value="2" Text="Ahorro" />
                            </asp:DropDownList>



                        </div>

                        <br />

                    </article>


                    <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                        <br />
                        <br />


                        <div>
                            <label>Numero de cuenta</label>
                            <strong>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxCuenta" Style="font-size: xx-small" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxCuenta">*</asp:RegularExpressionValidator>

                            </strong>

                            <asp:TextBox ID="tbxCuenta" CssClass="form-control" runat="server" />

                        </div>
                        <div>
                            <label>Cedula</label>
                            <strong>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Campo Cedula es importante" ForeColor="#CC3300" ControlToValidate="tbxCedula" Style="font-size: xx-small" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxCedula">*</asp:RegularExpressionValidator>

                            </strong>

                            <asp:TextBox ID="tbxCedula" CssClass="form-control" runat="server" />


                        </div>
                        <br />

                    </article>


                </div>--%>
                <%-- <div>
            <strong>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="color: #CC0000" ValidationGroup="vgroup" ForeColor="#CC3300" />

            </strong>

        </div>--%>
            </div>
            <div style="margin-left: 1.2%">

                <br />

                <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="&#9668;Guardar&#9658;" runat="server" Height="48px" Style="font-weight: bold; font-size: large" Width="226px" ValidationGroup="vgroup" OnClick="btnGuardar_Click" />

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
