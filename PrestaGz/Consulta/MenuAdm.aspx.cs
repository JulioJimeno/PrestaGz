using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PrestaGz.Consulta
{
    public partial class MenuAdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Consulta();
                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {

                    divGridPrestamo.Style.Value = "margin-left:25%";
                    divMenu.Style.Value = "margin-left:15%; margin-right:15%; border-bottom: 6px solid #848484; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";

                }
            }
        }

        public void ObtenerDatos(string Campo,string Entidad, string Tabla, string Condicion, DataTable dt, TextBox txbox)
        {

            dt = Utilitario.Lista(Campo, Tabla, Condicion);
            float Total = 0;

            if (dt.Rows.Count > 0)
            {
                if(dt.Rows[0][Entidad].ToString() == string.Empty)
                {
                    Total = 0;

                }else
                {
                  Total = Convert.ToSingle(dt.Rows[0][Entidad].ToString());
                }
          
            }

            txbox.Text = Total.ToString("N2");

        }

        public void Consulta()
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            DateTime Fe = DateTime.Now;
           int id = 0;

            if(Convert.ToInt32(Session["UsuarioId"])>0)
            {
                id = Convert.ToInt32(Session["UsuarioId"]);

            }else
            {
                id = Utilitario.ObtenerIdUsuarioAdm(Convert.ToInt32(Session["UsuarioCoId"]));
            }


            string Campo = " TOP 5 P.PrestamoId,C.Nombre,P.Total ";
            string Tabla = " from Prestamo as P inner join Cliente as C on C.ClienteId = P.ClienteId inner join UsuarioCo as Uc on Uc.UsuarioCoId = P.UsuarioCoId inner join Usuario as U on U.UsuarioId = Uc.UsuarioId";
            string Condicion = " where U.UsuarioId = " + id + " Order by (P.FechaInicio) ";

            string Campo2 = " Sum(P.Total) as Total ";
            string Condicion2 = " where U.UsuarioId = " + id;
            string Condicion3 =" where P.FechaInicio = '"+ Fe.Year + "/" + Fe.Month + "/" + Fe.Day + " 00:0:00.000' AND U.UsuarioId = " + id ;

            try
            {
                dt = Utilitario.Lista(Campo, Tabla, Condicion);

                if (dt.Rows.Count > 0)
                {

                    GridPrestamo.DataSource = dt;
                    GridPrestamo.DataBind();

                }else
                {
                    divInfo.Visible = true;
                }
      
                ObtenerDatos(Campo2,"Total",Tabla,Condicion2,dt,tbxTotalPrestado);
                ObtenerDatos(Campo,"Total",Tabla,Condicion3,dt,tbxPrestadoDiario);

                string Tabla2 = " from Abono as A inner join Cliente as C on C.ClienteId = A.ClienteId inner join UsuarioCo as Uc on Uc.UsuarioCoId = A.UsuarioCoId inner join Usuario as U on U.UsuarioId = Uc.UsuarioId";
                string Condicion4 = " where A.Fecha = '" + Fe.Year + "/" + Fe.Month + "/" + Fe.Day + " 00:0:00.000' AND U.UsuarioId = " + id;
                string Campo3 = " Sum(A.Cantidad) as Cantidad ";

                ObtenerDatos(Campo3, "Cantidad", Tabla2,Condicion4,dt,tbxCobradoHoy);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void dropConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dropConsulta.SelectedValue == "0")
            {
                Response.Redirect("~/Consulta/CoCuadre.aspx");
            }           
            else if (dropConsulta.SelectedValue == "1")
            {
                Response.Redirect("~/Consulta/CoPrestamo.aspx");
            }
            else if (dropConsulta.SelectedValue == "2")
            {
                Response.Redirect("~/Consulta/CoCliente.aspx");
            }
            else if (dropConsulta.SelectedValue == "3")
            {
                Response.Redirect("~/Consulta/CoUsuario.aspx");
            }


        }

        protected void dropRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropRegistro.SelectedValue == "1")
            {
                Response.Redirect("~/Registro/ReUsuario.aspx?TipoUsuario=0");

            }else if (dropRegistro.SelectedValue == "0")
            {
                Response.Redirect("~/Registro/ReCliente.aspx");
            }
        }

     
        protected void dropConfiguracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dropConfiguracion.SelectedValue == "0")
            {
                Response.Redirect("~/Registro/ReUsuario.aspx?TipoUsuario=1&TipoRegistro=1");

            }else if(dropConfiguracion.SelectedValue == "1")
            {
               Response.Redirect("~/Registro/ReHerramienta.aspx");

            }else if(dropConfiguracion.SelectedValue == "2")
            {
                Response.Redirect("~/Registro/ReBancario.aspx");
            }
        }

        protected void btnGestionarPrestamo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Consulta/CoCobrar.aspx");
        }
    }
}