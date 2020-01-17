using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data;
using BLL;
using System.Threading;

namespace PrestaGz
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Thread.Sleep(3000);


                int Id = 0;
                Id = Convert.ToInt32(Session["UsuarioId"]);


                DatosSesion(Id);

            }


        }

   
        public void DatosSesion(int Id)
        {


            if (Convert.ToInt32(Session["UsuarioId"]) == 0 && Convert.ToInt32(Session["UsuarioCoId"]) == 0)
            {
                AMenu.HRef = "~/default.aspx";
                AInicio.HRef = "~/default.aspx";


            }
            else if (Id > 0)
            {
                AMenu.HRef = "~/Consulta/MenuAdm.aspx";
                AInicio.HRef = "~/Consulta/MenuAdm.aspx";

            }
            else
            {
                Id = Utilitario.ObtenerIdUsuarioAdm(Convert.ToInt32(Session["UsuarioCoId"]));
                AMenu.HRef = "~/Consulta/Menu.aspx";
                AInicio.HRef = "~/Consulta/Menu.aspx";

            }


            if (Id > 0)
            {

                btnDesplegable.Visible = true;

                if (ValidarActualizacion())
                {
                    ActualizarEstadoPrestamo();
                }


                UserName.Visible = true;
                UserName.InnerText = Session["UserName"].ToString();
            }


            if (Request.Browser.IsMobileDevice)
            {
                btnSubscripcion.Style.Value = "width: 63px;background-color: #045FB4; opacity: 0.93;";
                spanSubcripcion.Style.Value = "font-size: 65%;color:white";


                if (Id > 0)
                {
                    divInicio.Style.Value = "margin-left:56%; margin-top:-6%";

                }

            }
            else
            {
                divInicio.Style.Value = "margin-left: 170px; margin-top:15px";
                imgPaypal.Style.Value = "Height:70%; Width:70%";



            }
        }

        public bool ValidarActualizacion()
        {
            bool Resultado = false;
            DateTime FechaAux;
            string Fecha1, Fecha2;

            Herramienta he = new Herramienta();
            int Id = 0;

            Id = Convert.ToInt32(Session["UsuarioId"]);

            if (Id == 0 && Convert.ToInt32(Session["UsuarioCoId"]) > 0)
            {
                Id = Utilitario.ObtenerIdUsuarioAdm(Convert.ToInt32(Session["UsuarioCoId"]));
            }


            if (Id > 0)
            {
                btnCerrarSesion.Visible = true;
                UserName.InnerText = Session["UserName"].ToString();
                UserName.Visible = true;
            }
            else
            {
                btnCerrarSesion.Visible = false;
                UserName.InnerText = "";
                UserName.Visible = false;

            }

            try
            {

                //4 por el campo valor de la tabla herramienta
                if ((Utilitario.DatosHerramientas("Fecha", Id.ToString(), "4")) == "0")
                {
                    //SI EL USUARIO ES NUEVO QUE TIRE 0 PORQUE NO TIENE REGISTRO DE FECHA AUN
                }
                else
                {

                    FechaAux = Convert.ToDateTime(Utilitario.DatosHerramientas("Fecha", Id.ToString(), "4"));

                    Fecha1 = Utilitario.FormatoFecha(FechaAux.ToString());
                    Fecha2 = Utilitario.FormatoFecha(DateTime.Now.ToString());


                    if (Fecha2 != Fecha1)
                    {

                        //PONER DE ALGUNA MANERA QUE ESTA CONDICION SOLO ENTRE EL USUARIO ADMINISTRATIVO MEDIANTE OTRO LOGING SOLO PARA ADMINISTRATIVO O COMO SEA CUALQUIERA DE LOS DOS
                        he.UsuarioId = Id;
                        he.Fecha = Utilitario.FormatoFecha(DateTime.Now.ToString());
                        he.ActualizarFecha();
                        Resultado = true;

                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return Resultado;
        }

        public void ActualizarEstadoPrestamo()
        {
            DataTable dt = new DataTable();
            Prestamo pre = new Prestamo();
            int UsuarioId = 0;
            DateTime FechaCortetime;

            try
            {


                if (Convert.ToInt32(Session["UsuarioId"]) > 0)
                {
                    UsuarioId = Convert.ToInt32(Session["UsuarioId"]);

                }
                else if (Convert.ToInt32(Session["UsuarioCoId"]) > 0)
                {
                    UsuarioId = Utilitario.ObtenerIdUsuarioAdm(Convert.ToInt32(Session["UsuarioCoId"]));
                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }


                dt = Utilitario.Lista(" P.Estado,P.PrestamoId,P.FechaCorte ", " from Usuario as U inner join UsuarioCo as Uc on Uc.UsuarioId = U.UsuarioId inner Join Prestamo as P on P.UsuarioCoId = Uc.UsuarioCoId ",
                " where P.Estado >= 1 and P.Estado <= 2 and U.UsuarioId =" + UsuarioId);

                if (Utilitario.ValidarTabla(dt))
                {

                    FechaCortetime = Convert.ToDateTime(dt.Rows[0]["FechaCorte"].ToString());

                    foreach (DataRow dtRow in dt.Rows)
                    {
                        int PrestamoId = Convert.ToInt32(dt.Rows[0]["PrestamoId"].ToString());

                        if (DateTime.Now > FechaCortetime)
                        {
                            pre.PrestamoId = PrestamoId;
                            pre.Estado = 3;

                            pre.ActualizarEstado();

                        }
                        else if (Utilitario.AlertarMora(PrestamoId))
                        {
                            pre.PrestamoId = PrestamoId;
                            pre.Estado = 2;
                            pre.ActualizarEstado();
                        }


                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["UsuarioId"] = null;
            Session["UsuarioCoId"] = null;
            Session["ClienteId"] = null;

            Response.Redirect("~/default.aspx");
            btnCerrarSesion.Visible = false;

        }
    }

}