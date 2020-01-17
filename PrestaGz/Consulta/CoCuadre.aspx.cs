using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrestaGz.Consulta
{
    public partial class CoCuadre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(dropCuadre.SelectedValue =="0")
                {
                    BuscarCuadre(DateTime.Today);
                }

                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {
                    DivGridCuadre.Style.Value = " margin-left:35%;margin-right:15% ";
                    Divfecha.Style.Value = "margin-left:31%; margin-right:20%";
                    DivBuscar.Style.Value = "border-bottom: 6px solid #848484; text-align: start; margin-left: 25%; margin-right: 25%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                  
                }
            }

        }
        public void BuscarCuadre(DateTime Fecha)
        {
            Abono a = new Abono();
            int Id = Convert.ToInt32(Session["UsuarioId"]);    //ESTE USUARIO ES EL ADMINISTRATIVO
            string Campo = "";
            string Tabla = "";
            string Condicion = "";


            DataTable dt = new DataTable();
            DataTable dtCliente = new DataTable();

            DateTime fecha = Fecha;
            string FechaHoy = fecha.Year + "/" + fecha.Month + "/" + fecha.Day + " 00:0:00.000 ";
            string ConvFecha = "Convert(VARCHAR(10),C.Fecha,103) as Fecha";

            Campo = " C.CuadreId, Uc.Nombre,C.Total, C.UsuarioCoId,"+ ConvFecha;
            Tabla = " from Cuadre as C inner join UsuarioCo as Uc on Uc.UsuarioCoId = C.UsuarioCoId inner join Usuario as U on U.UsuarioId = Uc.UsuarioId";
            Condicion = " where C.Fecha = '" + FechaHoy + "' and U.UsuarioId = " + Id;

            dt = Utilitario.Lista(Campo, Tabla, Condicion);

            if (dt.Rows.Count > 0)
            {
                GridPrestamo.DataSource = dt;
                GridPrestamo.DataBind();

            }else
            {
                Utilitario.ShowToastr(this, "No existen registro conforme a esta fecha", "Mensaje", "error");

                GridPrestamo.DataSource = null;
                GridPrestamo.DataBind();

            }




        }


        protected void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                if (dropCuadre.SelectedValue == "1")
                {
                    BuscarCuadre(Convert.ToDateTime(tbxFecha.Text));
                }
            }
            catch (FormatException)
            {
                Utilitario.ShowToastr(this, "Formato Fecha Incorrecto", "Mensaje", "error");
            }

        }

        protected void dropCuadre_TextChanged(object sender, EventArgs e)
        {
            if (dropCuadre.SelectedValue == "1")
            {
                Divfecha.Visible = true;
                // Limpiar();
            }
            else
            {
                Divfecha.Visible = false;
                BuscarCuadre(DateTime.Now);
            }
        }

        protected void GridPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridPrestamo.SelectedRow;
        
            string Aux = "";
            string Valor = "";

            Aux = "3";
            Valor =  row.Cells[1].Text;
            string UsuarioId = row.Cells[2].Text;

           Response.Write("<script type='text/javascript'>detailedresults=window.open('/Reportes/ReportTodos.aspx?Aux= " + Aux + "&UsuarioCoId="+UsuarioId+"&Valor= " + Valor + "');</script>");


        }
    }
}