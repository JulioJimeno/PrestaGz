using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace PrestaGz.Reportes
{
    public partial class ReportTodos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrestamoAbono();

                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {
                    divReport.Style.Value = "margin-left:19%; margin-right:30%; background-color:white";

                }


            }

        }


        public void PrestamoAbono()
        {
            string Valor = "";
            int Aux = 0;
            string ReportString = "";
            string DataSet = "";
            Valor = Request.QueryString["Valor"].ToString();
            Aux = Convert.ToInt32(Request.QueryString["Aux"].ToString());
            string CoUsuarioId = Convert.ToString(Session["UsuarioCoId"]);

            string Campos = "";
            string Entidades = "";
            string Condicion = "";
            string ConvFechaTermino = "Convert(VARCHAR(10),P.FechaTermino,103) as FechaTermino";
            string ConvFechaInicio = "Convert(VARCHAR(10),P.FechaInicio,103) as FechaInicio";
            string replace = "replace(replace(P.Estado,2,'Abono'),3,'Mora') as 'Estado' ";



            if (Aux == 1)
            {

                string ConvFechaAbono = "Convert(VARCHAR(10),A.Fecha,103) as Fecha";

                Campos = " P.PrestamoId,C.Nombre," + ConvFechaInicio + "," + ConvFechaTermino + ",P.Taza,P.Total,P.Interes," + replace + ",P.CantidadCuota,A.Cantidad," + ConvFechaAbono;
                Entidades = " from Prestamo as P inner join Cliente as C on C.ClienteId = P.ClienteId inner join UsuarioCo as Uc on Uc.UsuarioCoId = P.UsuarioCoId inner join Usuario as U on U.UsuarioId = Uc.UsuarioId inner join Abono as A on A.PrestamoId = P.PrestamoId";
                Condicion = " where P.PrestamoId = " + Valor;
                H2Reporte.InnerText = "Reporte de prestamo";
                ReportString = @"Reportes\ReportePrestamoAbono.rdlc";
                DataSet = "DataSetPrestamoAbono";

            }
            else if (Aux == 2)
            {

                Campos = " P.PrestamoId,C.Nombre," + ConvFechaInicio + "," + ConvFechaTermino + ",P.Taza,P.Total,P.Interes," + replace + ",P.CantidadCuota";
                Entidades = " from Prestamo as P inner join Cliente as C on C.ClienteId = P.ClienteId inner join UsuarioCo as Uc on Uc.UsuarioCoId = P.UsuarioCoId inner join Usuario as U on U.UsuarioId = Uc.UsuarioId";
                Condicion = " where P.PrestamoId = " + Valor;

                H2Reporte.InnerText = "Reporte de Abono";
                ReportString = @"Reportes\ReportePrestamoAbono.rdlc";
                DataSet = "DataSetPrestamoAbono";


            }
            else if (Aux == 3)
            {

                Campos = " C.P1, C.P5,C.P10,C.P25,C.P50,C.P100,C.P200,C.P500,C.P1000,C.P2000,C.Total,C.Fecha,Uc.Nombre,C.CuadreId ";
                Entidades = " from Cuadre as C inner join UsuarioCo as Uc on Uc.UsuarioCoId = C.UsuarioCoId ";
                Condicion = " where C.CuadreId = " + Valor;

                H2Reporte.InnerText = "Reporte de Cuadre";
                ReportString = @"Reportes\ReporteCuadre.rdlc";
                DataSet = "DataSetCuadre";

            }


            string UsuarioAdmId = "";

            if (Convert.ToInt32(Session["UsuarioCoId"]) == 0)
            {
                try
                {

                    UsuarioAdmId = Session["UsuarioId"].ToString();

                    //CoUsuarioId = Request.QueryString["UsuarioCoId"].ToString();
                    //UsuarioAdmId = Convert.ToString(Utilitario.ObtenerIdUsuarioAdm(Convert.ToInt32(CoUsuarioId)));
                }

                catch (Exception)
                {
                    UsuarioAdmId = Session["UsuarioId"].ToString();
                }

            }
            else
            {
                UsuarioAdmId = Convert.ToString(Utilitario.ObtenerIdUsuarioAdm(Convert.ToInt32(CoUsuarioId)));
            }


            string NombreEmpresa = "";

            //5 por que queremos el valor 5 y es el nombre de la empresa                      //EN CASO DE QUE DE UN ERROR PONERLO DONDE ESTABA ABAJO 
            NombreEmpresa = Utilitario.DatosHerramientas("Descripcion", UsuarioAdmId, "5");
            ReportParameter p = new ReportParameter("Parametro1", NombreEmpresa);

            ReportViewTodo.LocalReport.DataSources.Clear();
            ReportViewTodo.ProcessingMode = ProcessingMode.Local;
            ReportViewTodo.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + ReportString;

            //POR SI DA ERROR DE DIRECCION  https://stackoverflow.com/questions/28718036/reportviewer-error-when-dynamically-setting-rdlc-file-on-azure-cloud-services
            //AQUI DICE QUE HAY QUE DARLE CLICK DERECHO AL ARCHIVO .rdlc y darle a propeties:
            //1) BUILD ARCTION: Content
            //2) Copy always: Copy always 
            //3) DESPUES INSTALAR EL PACKAGE EN INSTALAR EN LA CONSOLA: Install-Package Microsoft.SqlServer.Types -Version 14.0.1016.290

            ReportDataSource source = new ReportDataSource(DataSet, Utilitario.Lista(Campos, Entidades, Condicion));

            ReportViewTodo.LocalReport.DataSources.Add(source);
            ReportViewTodo.LocalReport.SetParameters(p);
            ReportViewTodo.LocalReport.Refresh();
        }

    }
}