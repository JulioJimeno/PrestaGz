using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;


namespace PrestaGz.Consulta
{
    public partial class CoCobrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarPrestamo();

                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {
                    divConsultaPrestamo.Style.Value = "border-bottom: 6px solid #848484; margin-left: 30%; margin-right: 30%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    GridPrestamo.Style.Value = " large ";
                    divGridPrestamo.Style.Value = "margin-left:23%";
                }
    
            }

        }
        public DataTable BuscarPrestamo()
        {
            //HAY QUE PONER EL PROGRAMA A QUE DE VARIOS DIAS DE PRORROGA ANTES DE ACUMULAR MORA

            string replace = "replace(replace(replace(P.Estado,2,'Abono'),3,'Mora'),1,'OK') as 'Estado' ";

            btnDescargar.Visible = false;
            GridPrestamo.DataSource = null;
            GridPrestamo.DataBind();

            string campo = "P.PrestamoId,C.Nombre,C.ClienteId ,P.CantidadCuota,P.Total,U.Latitude,U.Descripcion as Lugar ,U.Descripcion,U.Longitude, " + replace;
            string tabla = " from Prestamo AS P inner join UsuarioCo as Uc on Uc.UsuarioCoId = P.UsuarioCoId inner join Usuario as Ua on Ua.UsuarioId = Uc.UsuarioId inner join Cliente as C on C.ClienteId = P.ClienteId inner join Ubicacion as U on U.ClienteId = C.ClienteId";
            DataTable dtAuxiliar = new DataTable();

            //AQUI PONER TANTO COMO EL ADMINISTRATIVO Y EL COLABORADOR PUEDA CONSULTAR
            int UsuarioId = 0;
            if(Convert.ToInt32(Session["UsuarioId"])>0)
            {

                UsuarioId = Convert.ToInt32(Session["UsuarioId"]);

            }else
            {
                UsuarioId = Utilitario.ObtenerIdUsuarioAdm(Convert.ToInt32(Session["UsuarioCoId"]));
            }

              
            string condicion = "";

            if (dropCliente.SelectedValue == "0")
            {
                condicion = " where Ua.UsuarioId = "+UsuarioId+" and P.Estado =2 OR P.Estado =3 ";

            }
            else if (dropCliente.SelectedValue == "1")
            {
                condicion = " where P.Estado = 2 and Ua.UsuarioId = " + UsuarioId;
            }
            else if (dropCliente.SelectedValue == "2")
            {
                condicion = " where P.Estado = 3 and Ua.UsuarioId = " + UsuarioId;
            }
            else if (dropCliente.SelectedValue == "3")
            {
                condicion = " where C.Nombre like '" + tbxBuscar.Text + "%' and Ua.UsuarioId  = " + UsuarioId;
            }
            else if (dropCliente.SelectedValue == "4")
            {
                condicion = " where C.Cedula = " + tbxBuscar.Text+ " and Ua.UsuarioId  = " + UsuarioId;

            }
            else if (dropCliente.SelectedValue == "5")
            {
                condicion = " where C.Telefono =" + tbxBuscar.Text+" and Ua.UsuarioId = " + UsuarioId;

            }
            else if (dropCliente.SelectedValue == "6")
            {
                condicion = " where P.PrestamoId =" + tbxBuscar.Text+ "and Ua.UsuarioId  = " + UsuarioId;

            }

            DataTable dt = new DataTable();
            dt = Utilitario.Lista(campo, tabla, condicion);

            if (dt.Rows.Count > 0)
            {
                GridPrestamo.DataSource = dt;
                GridPrestamo.DataBind();
                btnDescargar.Visible = true;


            }
            else
            {
                btnDescargar.Visible = false;
                GridPrestamo.DataSource = null;
                GridPrestamo.DataBind();
                Utilitario.ShowToastr(this, "NO TIENE COBROS PENDIENTES", "Mensaje", "error");
            }

            return dt;
        }
        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarPrestamo();
        }
        protected void dropCliente_TextChanged(object sender, EventArgs e)
        {
            if (dropCliente.SelectedValue != "0" && dropCliente.SelectedValue != "1" && dropCliente.SelectedValue != "2")
            {
                tbxBuscar.ReadOnly = false;
            }
        }
        protected void GridPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridPrestamo.SelectedRow;

            string location = "https://www.google.com/maps/dir//" + row.Cells[5].Text + "," + row.Cells[6].Text + "/@" + row.Cells[5].Text + "," + row.Cells[6].Text + ",16.39z/data=!4m4!4m3!1m0!1m1!4e1";

            Response.Write("<script> window.open('" + location + "','_blank'); </script>");
        }
  
        protected void btnDescargar_Click1(object sender, EventArgs e)
        {
            //PONER ESTO EN LA CABEZERA DE ASPX
            // CodeBehind = "CoCobrar.aspx.cs" Inherits = "PrestaGz.Consulta.CoCobrar" %>

            //CREAR ESTA FUNCION
            //  public override void VerifyRenderingInServerForm(Control control)


            ExportarExcel();

            //HAY QUE INSTALAR ESTA BIBLIOTECA 
            //Install-Package ClosedXML -Version 0.94.2


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        public void ExportarExcel()
        {


            string Nombre = "Prestamo "+DateTime.Now.Day+"-"+DateTime.Now.Month+"-"+DateTime.Now.Year;

            using (XLWorkbook wb = new XLWorkbook())
            {
                DataTable dt = new DataTable();

                dt = BuscarPrestamo();

                if (GridPrestamo != null)
                {
                    wb.Worksheets.Add(dt, Nombre);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xlsx", Nombre));

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }



    }
}