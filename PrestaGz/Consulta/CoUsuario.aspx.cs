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
    public partial class CoUsuario : System.Web.UI.Page
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
                    divConsultaUsuario.Style.Value = "border-bottom: 6px solid #848484; margin-left: 23%; margin-right: 23%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    divBuscar.Style.Value = "margin-left: -100%";
                    divGridUsuario.Style.Value = "margin-left:30%";
                }
            }
        }

        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            string ConvFechaRegistro = "Convert(VARCHAR(10),FechaCreacion,103) as FechaCreacion";

            string campo = " UsuarioCoId,Nombre,Telefono,Correo," + ConvFechaRegistro + ",Estado";
            string tabla = " from UsuarioCo ";

            int UsuarioId = Convert.ToInt32(Session["UsuarioId"]);

            string condicion = "";

            if (dropCliente.SelectedValue == "0")
            {
                condicion = " where Nombre like '" + tbxBuscar.Text + "%' and UsuarioId = "+UsuarioId;
            }
            else if (dropCliente.SelectedValue == "1")
            {
                condicion = " where Correo like '" + tbxBuscar.Text + "%' and UsuarioId = "+UsuarioId;
            }
            else if (dropCliente.SelectedValue == "2")
            {
                condicion = " where Telefono = " + tbxBuscar.Text + " and UsuarioId = " + UsuarioId;
            }
            else if (dropCliente.SelectedValue == "3")
            {
                condicion = " where UsuarioCoId = " + tbxBuscar.Text + " and UsuarioId = " + UsuarioId;
            }
            else if (dropCliente.SelectedValue == "4")
            {
                condicion = " where UsuarioId = "+UsuarioId;
                tbxBuscar.Text = string.Empty;
            }

            DataTable dt = new DataTable();
            dt = Utilitario.Lista(campo, tabla, condicion);

            if (dt.Rows.Count > 0)
            {
                GridUsuario.DataSource = dt;
                GridUsuario.DataBind();
            }
            else
            {
                GridUsuario.DataSource = null;
                GridUsuario.DataBind();
                tbxBuscar.Text = string.Empty;
                Utilitario.ShowToastr(this, "NO SE ENCONTRARON RESULTADO", "Mensaje", "error");
            }
        }

        protected void GridUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridUsuario.SelectedRow;
            int id = Convert.ToInt32(row.Cells[1].Text);

            Session["UsuarioCoId"] = id;

            Response.Redirect("~/Registro/ReUsuario.aspx?TipoRegistro=1&TipoUsuario=0");
        }
    }
}