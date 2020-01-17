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
    public partial class CoPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarGridview();
                Buscar();

                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {
                    divConsultaPrestamo.Style.Value = "border-bottom: 6px solid #848484; margin-left: 30%; margin-right: 30%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    divBuscar.Style.Value = "margin-left: -100%";
                    divGridPrestamo.Style.Value = "margin-left:15%";
                    divAbono.Style.Value = "border-bottom: 2.5px solid #848484; margin-left: 1%; margin-right: 2%; border-right: 2px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    divGridAbono.Style.Value = "margin-left:30%";
                }
            }
        }

        public void ObtenerGridView()
        {
            GridComentario.DataSource = (DataTable)ViewState["Detalle"];
            GridComentario.DataBind();

        }
        public void LLenarGridview()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Descripcion"), new DataColumn("Fecha") });
            ViewState["Detalle"] = dt;


        }

        public void Buscar()
        {
            string ConvFechaTermino = "";
            string ConvFechaInicio = "";
            string replace = "";
            string campo = "";
            string tabla = "";

            

             ConvFechaTermino = "Convert(VARCHAR(10),P.FechaTermino,103) as FechaTermino";
             ConvFechaInicio = "Convert(VARCHAR(10),P.FechaInicio,103) as FechaInicio";
             replace = "replace(replace(replace(replace(P.Estado,2,'Abono'),3,'Mora'),4,'Saldado'),1,'Pasivo')as 'Estado' ";
             campo = " P.PrestamoId,C.Nombre," + ConvFechaInicio + "," + ConvFechaTermino + ",P.Taza,P.Total,P.Interes," + replace + ",P.CantidadCuota,Uc.Nombre as NombreUsuario ";
             tabla = " from Prestamo as P inner join Cliente as C on C.ClienteId = P.ClienteId inner join UsuarioCo as Uc on Uc.UsuarioCoId = P.UsuarioCoId inner join Usuario as U on U.UsuarioId = Uc.UsuarioId";


                string condicion = "";


            if (dropCliente.SelectedValue == "0")
            {
                DateTime fecha = DateTime.Now;
                string FechaHoy = fecha.Year + "/" + fecha.Month + "/" + fecha.Day + " 00:0:00.000 ";

                condicion = " where P.FechaInicio ='" + FechaHoy + "' and U.UsuarioId =" + Session["UsuarioId"];
            }
            else if (dropCliente.SelectedValue == "1")
            {
                condicion = " where C.Nombre like '" + tbxBuscar.Text + "%' and U.UsuarioId =" + Session["UsuarioId"];
            }
            else if (dropCliente.SelectedValue == "2")
            {
                condicion = " where C.Cedula =" + tbxBuscar.Text + " and U.UsuarioId = " + Session["UsuarioId"];
            }
            else if (dropCliente.SelectedValue == "3")
            {
                condicion = " where C.Telefono =" + tbxBuscar.Text + " and U.UsuarioId = " + Session["UsuarioId"]; ;
            }
            else if (dropCliente.SelectedValue == "4")
            {
                condicion = " where P.ClienteId =" + tbxBuscar.Text + " and U.UsuarioId = " + Session["UsuarioId"]; ;
            }
            else if (dropCliente.SelectedValue == "5")
            {
                condicion = " where U.UsuarioId = " + Session["UsuarioId"];
                tbxBuscar.Text = string.Empty;
            }

            DataTable dt = new DataTable();
            dt = Utilitario.Lista(campo, tabla, condicion);

            if (dt.Rows.Count > 0)
            {
             
                GridPrestamo.DataSource = dt;
                GridPrestamo.DataBind();
            }
            else
            {
                Utilitario.ShowToastr(this, "NO SE ENCONTRARON RESULTADO", "Mensaje", "error");
            }



        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void GridPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = GridPrestamo.SelectedRow;
            string ConvFecha = " Convert(VARCHAR(10),Fecha,103) as Fecha ";

            DataTable dt = Utilitario.Lista(" Cantidad, " + ConvFecha, " from Abono ", " where PrestamoId = " + row.Cells[1].Text);

            DataTable dt2 = new DataTable();
            dt2 = Utilitario.Lista(" ClienteId ", " from Prestamo ", " where PrestamoId = " + row.Cells[1].Text);


            if (dt2.Rows.Count > 0)
            {
                LblClienteId.Text = dt2.Rows[0]["ClienteId"].ToString();

                DataTable dt3 = new DataTable();

                dt3 = Utilitario.Lista(" Descripcion,Fecha ", " from Nota ", " where PrestamoId = " + row.Cells[1].Text);

                if (dt3.Rows.Count > 0)
                {
                    GridComentario.DataSource = dt3;
                    GridComentario.DataBind();

                    ViewState["Detalle"] = dt3;
                    ObtenerGridView();
                    btnGuardarNonta.Visible = true;
                }
                else
                {
                    btnGuardarNonta.Visible = false;
                }


            }



            if (Utilitario.ValidarTabla(dt))
            {
                GridVAbono.DataSource = dt;
                GridVAbono.DataBind();
                divAbono.Visible = true;
                lblId.Text = row.Cells[0].Text;


            }
            else
            {
                lblId.Text = row.Cells[0].Text;
                divAbono.Visible = false;
                Utilitario.ShowToastr(this, "NO TIENE ABONO", "Mensaje", "error");
            }

            btnImprimir.Visible = true;

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            string Aux = "";
            string Valor = "";

            if (GridVAbono.Rows.Count > 1)
            {
                Aux = "1";
                Valor = lblId.Text;

            }
            else
            {
                Aux = "2";
                Valor = lblId.Text;
            }

            Response.Write("<script type='text/javascript'>detailedresults=window.open('/Reportes/ReportTodos.aspx?Aux= " + Aux + "&UsuarioCoId=" + "&Valor= " + Valor + "');</script>");

        }

        protected void btnNota_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Detalle"];
            DataRow row;
            row = dt.NewRow();

            row["Descripcion"] = tbxNota.InnerText;
            row["Fecha"] = DateTime.Today.ToString("dd/MM/yy");

            dt.Rows.Add(row);
            ViewState["Detalle2"] = dt;
            ObtenerGridView();

            if(GridComentario.Rows.Count >0)
            {
                btnGuardarNonta.Visible = true;
            }

        }

        protected void btnGuardarNonta_Click(object sender, EventArgs e)
        {
            Nota no = new Nota();

            CapturaNota(no, Convert.ToInt32(lblId.Text), Convert.ToInt32(LblClienteId.Text));

            if (no.Insertar())
            {
                Utilitario.ShowToastr(this, "NOTA AGREGADA.!", "Mensaje", "success");

            }
        }

        public void CapturaNota(Nota no, int PrestamoId, int ClienteId)
        {
            if (GridComentario.Rows.Count > 0)
            {
                foreach (GridViewRow row in GridComentario.Rows)
                {
                    no.AgregarNota(PrestamoId, ClienteId, row.Cells[0].Text, DateTime.Now.ToString("dd/MM/yy"));
                }

            }
        }



    }
}