<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReHerramienta.aspx.cs" Inherits="PrestaGz.Registro.ReHerramienta" %>

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
                <h2 style="margin-left: 1%"><strong>CONFIGURACION </strong></h2>
                <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    <br />

                    <div>
                        <label id="lblCodigo" runat="server" visible="false">Codigo Empresa</label>

                        <asp:TextBox ID="tbxCodigo" Visible="false" ReadOnly="true" CssClass="form-control" runat="server" />

                    </div>

                    <div>
                        <label>Porciento mora</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo importante" ForeColor="#CC3300" ControlToValidate="tbxPorcientoMora" Style="font-size: x-small" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo numeros" ForeColor="#CC0000" Style="font-size: x-small" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="vgroup" ControlToValidate="tbxPorcientoMora">*</asp:RegularExpressionValidator>

                        </strong>

                        <asp:TextBox ID="tbxPorcientoMora" ToolTip="Porciento que se agregara a cada mora segun el abono" CssClass="form-control" runat="server" />

                    </div>

                    <div>
                        <label>Nombre de la empresa</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo importante" ForeColor="#CC3300" ControlToValidate="tbxNombreEmpresa" Style="font-size: x-small" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo letras" ForeColor="#CC0000" Style="font-size: x-small" ValidationExpression="^[0-9a-zA-Z ]+$" ValidationGroup="vgroup" ControlToValidate="tbxNombreEmpresa">*</asp:RegularExpressionValidator>

                        </strong>

                        <asp:TextBox ID="tbxNombreEmpresa" CssClass="form-control" runat="server" />

                    </div>


                </article>

                <article class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                    <div>
                        <label>Dias de prorrogas des pues del corte (Mes)</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo importante" ForeColor="#CC3300" ControlToValidate="tbxMes" Style="font-size: x-small" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo numero entero" ForeColor="#CC0000" Style="font-size: x-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup" ControlToValidate="tbxMes">*</asp:RegularExpressionValidator>

                        </strong>

                        <asp:TextBox ID="tbxMes" ToolTip="Dias de prorrogas para abono por mes" CssClass="form-control" runat="server" />

                    </div>


                    <div>
                        <label>Dias de prorrogas des pues del corte (Quincena)</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo importante" ForeColor="#CC3300" ControlToValidate="tbxQuincena" Style="font-size: x-small" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Solo numero entero" ForeColor="#CC0000" Style="font-size: x-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup" ControlToValidate="tbxQuincena">*</asp:RegularExpressionValidator>

                        </strong>

                        <asp:TextBox ID="tbxQuincena" ToolTip="Dias de prorrogas para abono por 15na" CssClass="form-control" runat="server" />

                    </div>

                    <div>
                        <label>Dias de prorrogas des pues del corte (Dia)</label>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo importante" ForeColor="#CC3300" ControlToValidate="tbxDia" Style="font-size: x-small" ValidationGroup="vgroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Solo numero entero no permitidos" ForeColor="#CC0000" Style="font-size: x-small" ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ValidationGroup="vgroup" ControlToValidate="tbxDia">*</asp:RegularExpressionValidator>

                        </strong>

                        <asp:TextBox ID="tbxDia" ToolTip="Dias de prorrogas para abono por dia" CssClass="form-control" runat="server" />

                    </div>
                    <br />
                </article>

                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="vgroup" ForeColor="Red" runat="server" />
            </div>
            <div style="margin-left: 2%">


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
