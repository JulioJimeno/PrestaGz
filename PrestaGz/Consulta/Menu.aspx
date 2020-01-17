<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PrestaGz.Consulta.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>

            <div id="divConsultaPrestamo" runat="server" class="row" style="border-bottom: 6px solid #848484; text-align: center; margin-left: 18%; margin-right: 18%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93">
                <br />
                <h1><strong>Menu Prestador</strong></h1>
            </div>

            <div id="divMenu" runat="server" class="row" style="margin-left: 50px; margin-right: 50px">

                <br />
                <br />
                <br />

                <asp:Button ID="btnReCliente" CssClass="btn btn-primary" Text="CREAR CLIENTE" runat="server" Style="font-weight: bold; font-size: x-large;" Height="160px" Width="325px" OnClick="btnReCliente_Click" />

                &nbsp;<asp:Button ID="btnRePrestamo" CssClass="btn btn-success" Text="PRESTAR" runat="server" Style="font-weight: bold; font-size: x-large;" Height="160px" Width="325px" OnClick="btnRePrestamo_Click" />
                &nbsp;<asp:Button ID="btnReAbono" CssClass="btn btn-danger" Text="ABONAR" runat="server" Style="font-weight: bold; font-size: x-large;" Height="160px" Width="325px" OnClick="btnReAbono_Click" />
                &nbsp;<asp:Button ID="btnCuadre" CssClass="btn btn-warning" Text="CUADRE" runat="server" Style="font-weight: bold; font-size: x-large; margin-right: 0;" Height="160px" Width="325px" OnClick="btnCuadre_Click" />
                &nbsp;<asp:Button ID="btnGesPago" CssClass="btn btn-info" Text="GESTIONAR COBRO" runat="server" Style="font-weight: bold; font-size: x-large; margin-right: 0;" Height="160px" Width="325px" OnClick="btnGesPago_Click" />

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
