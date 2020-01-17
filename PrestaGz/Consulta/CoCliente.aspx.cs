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
    public partial class CoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {
                    divConsultaCliente.Style.Value = "border-bottom: 6px solid #848484; margin-left: 25%; margin-right: 25%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    divBuscar.Style.Value = "margin-left: -100%";
                    divGridCliente.Style.Value = "margin-left:25%";
                }
            }
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string ConvFechaRegistro = "Convert(VARCHAR(10),C.FechaRegistro,103) as FechaRegistro";

            string campo = "ClienteId,C.Nombre,C.Telefono,C.Cedula,C.Direccion," + ConvFechaRegistro + ",C.Estado,Uc.Nombre as NombreUsuario";
            string tabla = " from Cliente as C inner join UsuarioCo as Uc on Uc.UsuarioCoId = C.UsuarioCoId inner join Usuario as U on U.UsuarioId = Uc.UsuarioId";


            string condicion = "";

            if (dropCliente.SelectedValue == "0")
            {
                condicion = " where C.Nombre like '" + tbxBuscar.Text + "%'"+" and U.UsuarioId = "+Session["UsuarioId"];
            }
            else if (dropCliente.SelectedValue == "1")
            {
                condicion = " where C.Cedula = " + tbxBuscar.Text+ " and U.UsuarioId = " + Session["UsuarioId"];
            }
            else if (dropCliente.SelectedValue == "2")
            {
                condicion = " where C.Telefono = " + tbxBuscar.Text + " and U.UsuarioId = " + Session["UsuarioId"];
            }
            else if (dropCliente.SelectedValue == "3")
            {
                condicion = " where C.ClienteId = " + tbxBuscar.Text + " and U.UsuarioId = " + Session["UsuarioId"];
            }
            else if (dropCliente.SelectedValue == "4")
            {
                condicion = " where U.UsuarioId = "+ Session["UsuarioId"];
                tbxBuscar.Text = string.Empty;
            }

            DataTable dt = new DataTable();
            dt = Utilitario.Lista(campo, tabla, condicion);

            if (dt.Rows.Count > 0)
            {
                GridCliente.DataSource = dt;
                GridCliente.DataBind();


            }
            else
            {
                tbxBuscar.Text = string.Empty;
            
                GridCliente.DataSource = null;
                GridCliente.DataBind();
                Utilitario.ShowToastr(this, "NO SE ENCONTRARON RESULTADO", "Mensaje", "error");
            }
        }

        protected void GridCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridCliente.SelectedRow;
            int id = Convert.ToInt32(row.Cells[1].Text);

            Session["ClienteId"] = row.Cells[1].Text;

            Response.Redirect("~/Registro/ReCliente.aspx?");
        }

      
    }
}