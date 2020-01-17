<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReCuadre.aspx.cs" Inherits="PrestaGz.Registro.ReCuadre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />



    <div class="row" id="DivBuscar" runat="server" style="border-bottom: 6px solid #848484; text-align: start; margin-left: 1%; margin-right: 1%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">

        <br />
        <div style="text-align: center">
            <div style="margin-left: -5%">
                <strong>
                    <asp:Label Text="Buscar " runat="server" CssClass="w3-text-white" Style="font-size: large" /></strong>

            </div>
            <asp:DropDownList CssClass="btn btn-primary" ID="dropCuadre" AutoPostBack="true" runat="server" Style="font-weight: bold; font-size: large;" Width="232px" OnTextChanged="dropCuadre_TextChanged1">
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

           <Triggers>

            <asp:PostBackTrigger ControlID="btnGuardar" />
           

        </Triggers>


        <ContentTemplate>
            <div class="row" id="divDinero" runat="server" style="margin-left: 1%; margin-right: 1%; border-bottom: 6px solid #848484; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
                <h2><strong>&nbsp; Registro de cuadre</strong></h2>

                <%-- <div class="row" style="margin-left:-2%; margin-right:-9%">--%>
                <br />
                <article class="col-xs-6 col-sm-6 col-md-4 col-lg-4">

                    <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cantidad</label>
                    <div>
                        <label><b>1&nbsp;&nbsp; $</b></label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup1" ControlToValidate="tbxCantidad1">*</asp:RegularExpressionValidator>

                        <asp:TextBox ID="tbxCantidad1" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad1_TextChanged1" />
                        &nbsp;<asp:TextBox ID="tbxTotal1" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />

                    </div>

                    <div>
                        <label><b>5&nbsp;&nbsp; $</label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup5" ControlToValidate="tbxCantidad5">*</asp:RegularExpressionValidator>

                        <asp:TextBox ID="tbxCantidad5" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad5_TextChanged" />
                        &nbsp;<asp:TextBox ID="tbxTotal5" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />
                    </div>

                    <div>
                        <label><b>10 $</b></label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup10" ControlToValidate="tbxCantidad10">*</asp:RegularExpressionValidator>

                        <asp:TextBox ID="tbxCantidad10" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad10_TextChanged" />
                        &nbsp;<asp:TextBox ID="tbxTotal10" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />
                    </div>

                    <div>
                        <label><b>25 $</b></label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup25" ControlToValidate="tbxCantidad25">*</asp:RegularExpressionValidator>

                        <asp:TextBox ID="tbxCantidad25" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad25_TextChanged" />
                        &nbsp;<asp:TextBox ID="tbxTotal25" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />
                    </div>

                    <div>
                        <label><b>50 $</b></label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup50" ControlToValidate="tbxCantidad50">*</asp:RegularExpressionValidator>

                        <asp:TextBox ID="tbxCantidad50" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad50_TextChanged" />
                        &nbsp;<asp:TextBox ID="tbxTotal50" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />
                    </div>
                    <br />

                </article>

                <article class="col-xs-6 col-sm-6 col-md-4 col-lg-4">
                    <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cantidad</label>

                    <div style="margin-right:-2%; margin-left:-2%">
                        <div>
                            <label><b>100&nbsp;&nbsp; $</b></label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup100" ControlToValidate="tbxCantidad100">*</asp:RegularExpressionValidator>

                            <asp:TextBox ID="tbxCantidad100" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad100_TextChanged" />
                            &nbsp;<asp:TextBox ID="tbxTotal100" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />
                        </div>

                        <div>
                            <label><b>200&nbsp;&nbsp; $</b></label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup200" ControlToValidate="tbxCantidad200">*</asp:RegularExpressionValidator>

                            <asp:TextBox ID="tbxCantidad200" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad200_TextChanged1" />
                            &nbsp;<asp:TextBox ID="tbxTotal200" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />
                        </div>

                        <div>
                            <label><b>500&nbsp;&nbsp; $</b></label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup500" ControlToValidate="tbxCantidad500">*</asp:RegularExpressionValidator>

                            <asp:TextBox ID="tbxCantidad500" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad500_TextChanged" />
                            &nbsp;<asp:TextBox ID="tbxTotal500" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />
                        </div>

                        <div>
                            <label><b>1000 $</b></label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup1000" ControlToValidate="tbxCantidad1000">*</asp:RegularExpressionValidator>

                            <asp:TextBox ID="tbxCantidad1000" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad1000_TextChanged1" />
                            &nbsp;<asp:TextBox ID="tbxTotal1000" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />
                        </div>

                        <div>
                            <label><b>2000 $</b></label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="Simbolos no permitidos" ForeColor="#CC0000" Style="font-size: xx-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup2000" ControlToValidate="tbxCantidad2000">*</asp:RegularExpressionValidator>

                            <asp:TextBox ID="tbxCantidad2000" AutoPostBack="true" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="50px" runat="server" OnTextChanged="tbxCantidad2000_TextChanged" />
                            &nbsp;<asp:TextBox ID="tbxTotal2000" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="50px" ReadOnly="true" runat="server" />
                        </div>


                    </div>
                </article>

                <article class="col-xs-11 col-sm-11 col-md-4 col-lg-4">
                    <div style="text-align: center">
                        <div>
                            <label># Cliente Cobrado</label>

                            <div style="margin-left: 18%" class="text-center">

                                <asp:TextBox ID="tbxCantCobrado" Text="0" CssClass="form-control" ReadOnly="true" runat="server" Style="font-weight: bold" Width="198px" />

                            </div>


                        </div>

                        <div>
                            <div style="margin-left: -18%">
                                <label><b>Introducido</b></label>&nbsp;&nbsp;&nbsp;
                        <label><b style="color: #a09f9f">Total</b></label>

                            </div>
                            <asp:TextBox ID="tbxTotalIntroducido" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; font-weight: bold;" Width="120px" ReadOnly="true" runat="server" Height="28px" />

                            &nbsp;<asp:TextBox ID="tbxTotalAIntroducir" Text="0" Style="border-bottom: 2px solid #ffffff; border-right: 2px solid #ffffff; border-radius: 8px; background-color: #a09f9f; font-weight: bold;" Width="120px" Height="28px" ReadOnly="true" runat="server" />
                        </div>

                        <div style="text-align: center; margin-left: 15%">

                            <strong>
                                <br />

                                <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="&#9668; GUARDAR &#9658;" runat="server" Style="font-weight: bold" Height="43px" Width="181px" OnClick="btnGuardar_Click" />

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                            </strong>

                        </div>
                    </div>
                </article>
                <%-- </div>--%>

                <br />
            </div>
            </b>
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
