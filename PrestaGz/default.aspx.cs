using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrestaGz
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



                Thread.Sleep(3000);

                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {
                    divDefinicion.Style.Value = "margin-right: -5%; margin-left: 30%";
                    divReNegocio.Style.Value = "margin-left: 25%";
                    divImagen.Style.Value = "margin-left: 15%; margin-top: -6%";

                    divSesion.Style.Value = "margin-left:25%";
                    h2Inicio.Style.Value = "margin-left:25%";

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


        protected void btnSesion_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            string TipoUsuario = "";
            string UsuarioId = "";

            if (CheckColaborador.Checked == true)
            {
                TipoUsuario = "UsuarioCo";
                UsuarioId = "UsuarioCoId";


            }
            else
            if (CheckAdm.Checked == true)
            {
                TipoUsuario = "Usuario";
                UsuarioId = "UsuarioId";
            }

            if (CheckAdm.Checked == false && CheckColaborador.Checked == false)
            {
                Utilitario.ShowToastr(this, "SELECCIONE UN TIPO DE USUARIO", "Mensaje", "error");
            }
            else
            {


                if (us.ValidarLog(tbxCorreo.Text, tbxContrasena.Text, TipoUsuario, UsuarioId))
                {
                    if (TipoUsuario == "Usuario")
                    {

                        Session["UserName"] = us.Nombre;
                        Session["UsuarioId"] = us.UsuarioId;



                        us.ActualizarEstadoSubscripcion(us.UsuarioId);
                        if (us.Estado == 3)
                        {
                            Label lbl = this.Master.FindControl("lblExpiracionPrueba") as Label;
                            lbl.Visible = true;
                            
              
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { LoginFail(); });", true);

                        }
                        else
                        {
                            Response.Redirect("~/Consulta/MenuAdm.aspx");
                        }




                    }
                    else
                    {
                        Session["UserName"] = us.Nombre;
                        Session["UsuarioCoId"] = us.UsuarioCoId;

                        Response.Redirect("~/Consulta/Menu.aspx");

                    }
                    lblNoEncontrado.Visible = false;

                }
                else
                {
                    Utilitario.ShowToastr(this, "Contraseña o correo incorrecto.!", "Mensaje", "error");
                    lblNoEncontrado.Visible = true;

                }
            }
        }

        protected void CheckColaborador_CheckedChanged(object sender, EventArgs e)
        {
            CheckAdm.Checked = false;
        }

        protected void CheckAdm_CheckedChanged(object sender, EventArgs e)
        {
            CheckColaborador.Checked = false;
        }

        protected void btnRegistrarNegocio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registro/ReUsuario.aspx?TipoRegistro=0&TipoUsuario=1");
        }



        protected void btnDescargarAcceso_Click(object sender, EventArgs e)
        {


        }

        protected void btndescargararchivo_Click(object sender, EventArgs e)
        {


            string pageurl = "https://1drv.ms/u/s!AoWR-tO6WZfaaLhBUg9Qc_d5rFE?e=pberMu";
            Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");

            // string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            //using (StreamWriter writer = new StreamWriter(deskDir + "\\" + "PrestaGz" + ".lnk"))
            //{
            //    string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //    writer.WriteLine("[InternetShortcut]");
            //    writer.WriteLine("https://prestagz.azurewebsites.net");
            //    writer.WriteLine("IconIndex=0");
            //    string icon = app.Replace('\\', '/');
            //    writer.WriteLine("IconFile=" + icon);
            //    writer.Flush();
            //}
        }

        protected void btnSubscripcion_Click(object sender, EventArgs e)
        {

        }
    }
}