<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportTodos.aspx.cs" Inherits="PrestaGz.Reportes.ReportTodos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div id="divReport" runat="server" style="margin-left:1%; margin-right:1%; background-color:white; ">

        <h2 id="H2Reporte" runat="server" style="color:#166AB9"><strong>Reporte de prestamo</strong></h2>

        <rsweb:ReportViewer ID="ReportViewTodo" runat="server" Height="641px" Width="100%"></rsweb:ReportViewer>

    </div>



</asp:Content>
