using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrestaGz.Consulta
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if(!IsPostBack)
            {

                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {

                    divMenu.Style.Value = "margin-left: 15%;margin-right:2%";

                }


                    if (Session["UserName"]==null)
                {
                    Response.Redirect("~/default.aspx");
                }

            }
        }

        protected void btnReCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registro/ReCliente.aspx");
        }

        protected void btnRePrestamo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registro/RePrestamo.aspx");
        }

        protected void btnReAbono_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registro/ReAbono.aspx");
        }

        protected void btnCuadre_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registro/ReCuadre.aspx");
        }

        protected void btnGesPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Consulta/CoCobrar.aspx");
        }
    }
}