<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PrestaGz._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />




    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <%--<Triggers>

            <%--<asp:PostBackTrigger ControlID="btnSesion" />--%>

        <%-- </Triggers>--%>

        <ContentTemplate>

            <div class="row" style="border-bottom: 6px solid #848484; margin-left: 3%; margin-right: 3%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">


                <br />

                <article class="col-xs-12 col-sm-12 col-md-5 col-lg-5">

                    <h2 id="h2Inicio" runat="server" style="margin-left: 10%"><strong>Iniciar sesion </strong></h2>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxContrasena" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: large" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxContrasena">*</asp:RegularExpressionValidator>

                    <br />

                    <div id="divSesion" runat="server" style="margin-left: 10%">
                        <div>
                            <label>Correo Electronico</label>
                            <strong>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo nombre es importante" ForeColor="#CC3300" ControlToValidate="tbxCorreo" Style="font-size: large" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>

                            </strong>

                            <asp:TextBox ID="tbxCorreo" CssClass="form-control" runat="server" TextMode="Email" />

                        </div>

                        <div>
                            <label>Contrase&ntilde;a</label>
                            <strong>&nbsp;<asp:CheckBox ID="CheckAdm" ToolTip="Iniciar sesion con cuenta de administrador" Text="Administrador" AutoPostBack="true" runat="server" OnCheckedChanged="CheckAdm_CheckedChanged" Style="font-size: 12px" />
                                <asp:CheckBox ID="CheckColaborador" ToolTip="Iniciar sesion con cuenta de Colaborador" Text="Prestador" AutoPostBack="true" Checked="true" runat="server" OnCheckedChanged="CheckColaborador_CheckedChanged" Style="font-size: 12px" />

                            </strong>

                            <asp:TextBox ID="tbxContrasena" CssClass="form-control" runat="server" TextMode="Password" />



                        </div>


                        <asp:Button ID="btnSesion" value="Grabar Datos" CssClass="btn btn-success" Text="Iniciar sesion" runat="server" Style="font-weight: bold; font-size: large;" Width="160px" ValidationGroup="vgroup" OnClick="btnSesion_Click" />

                        &nbsp;&nbsp;
                         <div>
                             <asp:Label ID="lblNoEncontrado" Visible="false" Style="font-weight: bold" ForeColor="#cc0000" Text="Correo o contranse&ntilde;a incorrecta.!!" runat="server" />
                         </div>


                    </div>
                    <br />
                </article>

                <article class="col-xs-12 col-sm-12 col-md-5 col-lg-5" style="text-align: center">

                    <div id="divDefinicion" runat="server">
                        <h1 style="color: white; font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">PrestaGz</h1>
                        <h3 style="color: white" class="text-left">Es un Software de préstamos, que permite planificar y gestionar las actividades de préstamo.
            
                Además de poder tener un rápido acceso a la información para tener conocimiento del estado de los clientes en todo momento 
                facilitando el cobro de sus clientes.
                        </h3>
                    </div>

                </article>

                <article class="col-xs-12 col-sm-12 col-md-5 col-lg-5">
                    <br />
                    <div id="divReNegocio" runat="server">
                        <h2 style="color: white; font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">Registra tu negocio </h2>
                        <h3 style="color: white">Registrar tu negocio y agrega a colaboradores desde tu cuenta y comienza a gestionar de manera organizada tus clientes.</h3>

                        <asp:Button CssClass="btn btn-info" ID="btnRegistrarNegocio" Text="Registrar.!" runat="server" OnClick="btnRegistrarNegocio_Click" />

                    </div>
                </article>

                <article class="col-xs-12 col-sm-12 col-md-5 col-lg-5" style="text-align: center">

                    <br />
                    <div id="divImagen" runat="server" style="margin-left: -15%">
                        <img src="Imagenes/Dispositivos1.png" style="width: 389px; height: 289px" />
                    </div>
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

    <%--   <linkbutton id="btnSubscripcion" runat="server" type="button" style="background-color: #045FB4; opacity: 0.93; width: 95px;"   class=" navbar-btn" data-toggle="modal" data-target="#myModal"><span id="spanSubcripcion" runat="server" style="font-size: 80%; height:5%; width:10%; color:white"><strong>Subscribirse</strong></span></linkbutton>
    --%>
    <asp:Button ID="btnSubscripcion" Visible="false" Text="Subscripcion" runat="server" type="button" Style="background-color: #045FB4; opacity: 0.93; width: 95px;" class=" navbar-btn" data-toggle="modal" data-target="#myModal2" OnClick="btnSubscripcion_Click" />

    <!-- ESTO ES PARA LLAMAR AL MODAL Y EN EL ARCHIVO CS. ESTA EL CODIGO  -->

    <script type="text/javascript">
        function LoginFail() {
            $('#myModal2').modal();
        }
    </script>

</asp:Content>
