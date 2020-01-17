using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Threading;

namespace PrestaGz.Registro
{
    public partial class ReUsuario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.Sleep(3000);

                int Id = 0;

                Id = Convert.ToInt32(Session["UsuarioCoId"]);

                int Tipo = Convert.ToInt32(Request.QueryString["TipoUsuario"]);

                if (Id > 0)
                {
                    CapturarDatos(Tipo, Id);

                    H2Colaborador.Visible = true;
                    H2Administativo.Visible = false;

                    //divBanco.Visible = false;
                    divRnc.Visible = false;

                }
                else
                {

                    H2Colaborador.Visible = false;
                    H2Administativo.Visible = true;
                    Id = Convert.ToInt32(Session["UsuarioId"]);
                    //divBanco.Visible = true;
                    divRnc.Visible = true;


                }


                //if (Tipo == 0)
                //{
                //    H2Administativo.Visible = false;
                //    H2Colaborador.Visible = true;

                //    divBanco.Visible = false;
                //    divRnc.Visible = false;

                //}

                if (Convert.ToInt32(Request.QueryString["TipoRegistro"]) > 0)
                {
                    H2Administativo.InnerText = "Actualizar Datos";
                    H2Administativo.Visible = true;
                    H2Colaborador.Visible = false;
                    btnGuardar.Text = "Actualizar";
                    CapturarDatos(Tipo, Id);

                }
            }

        }

        public void CapturarDatos(int Tipo, int id)
        {
            Usuario Us = new Usuario();


            string Tabla = "";
            string TipoUsuario = "";

            if (Tipo == 0)
            {
                Tabla = "UsuarioCo";
                TipoUsuario = "UsuarioCoId";
                //divBanco.Visible = false;

            }
            else if (Tipo == 1)
            {
                Tabla = "Usuario";
                TipoUsuario = "UsuarioId";
            }

            if (Us.Buscar(id, Tabla, TipoUsuario))
            {

                tbxNombre.Text = Us.Nombre;
                tbxTelefono.Text = Us.Telefono;

                tbxCorreo.Text = Us.Correo;
                tbxContrasena.Text = Us.Contrasena;
                tbxConfirmar.Text = Us.Contrasena;

                if (Tipo == 1)
                {
                    //CuentaBancaria cb = new CuentaBancaria();
                    //tbxRnc.Text = Us.RNC;

                    //cb.UsuarioId = id;
                    //cb.Buscar();

                    //tbxBanco.Text = cb.NombreBanco;
                    //dropTipoCuenta.Text = cb.TipoCuenta;
                    //tbxCuenta.Text = cb.NumeroCuenta;
                    //tbxCedula.Text = cb.Cedula;

                }
                else
                {
                    divRnc.Visible = false;
                }
            }

        }

        public bool ValidarDatosUsuario(string Campo, string Dato, string Tabla)
        {
            bool Resultado = false;
            DataTable dt = new DataTable();

            dt = Utilitario.Lista(Campo, " from " + " Usuario ", " where " + Campo + " = '" + Dato + "'");

            Resultado = Utilitario.ValidarTabla(dt);



            if (Campo == "Correo" && Resultado == false)
            {
                dt = Utilitario.Lista(Campo, " from " + "UsuarioCo", " where " + Campo + " = '" + Dato + "'");

                Resultado = Utilitario.ValidarTabla(dt);

            }

            if (Convert.ToInt32(Request.QueryString["TipoRegistro"]) > 0 && dt.Rows.Count > 1)
            {
                Resultado = true;
            }
            else
            {
                Resultado = false;
            }



            return Resultado;

        }

        public void ObtenerDatos(Usuario us)
        {
            us.Nombre = tbxNombre.Text;
            us.Contrasena = tbxContrasena.Text;
            us.Correo = tbxCorreo.Text;
            us.Telefono = tbxTelefono.Text;
            us.FechaCreacion = Utilitario.FormatoFecha(DateTime.Now.ToString());
            us.Estado = 1;
            us.RNC = tbxRnc.Text;

        }


        public void ObtenerDatosCuentaBancaria(CuentaBancaria cb, int Id)
        {

            //cb.UsuarioId = Id;
            //cb.NombreBanco = tbxBanco.Text;
            //cb.TipoCuenta = dropTipoCuenta.Text;
            //cb.NumeroCuenta = tbxCuenta.Text;
            //cb.Cedula = tbxCedula.Text;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //VOLVER A CREAR Y ORGANIZAR ESTE REGISTRO
                //CONSEJO, TIPO DE REGISTRO SI ES ACTUALIZAR O REGISTRAR, TIPODE REGISTRO Y USUARIOID O USUARIOCOID

                Usuario us = new Usuario();
                CuentaBancaria cb = new CuentaBancaria();

                string Tabla = "";
                string TipoUsuarioId = "";


                int Tipo = Convert.ToInt32(Request.QueryString["TipoUsuario"]);

                if (Tipo == 0)
                {
                    Tabla = "UsuarioCo";
                    TipoUsuarioId = "UsuarioCoId"; //este solo es para actualizar
                    us.UsuarioId = Convert.ToInt32(Session["UsuarioId"]);
                    //divBanco.Visible = false;

                }
                else if (Tipo == 1)
                {
                    Tabla = "Usuario";
                    TipoUsuarioId = "UsuarioId"; //este solo es para actualizar
                }

                ObtenerDatos(us);

                //if (Tipo == 1 && dropTipoCuenta.Text == "Seleccione")
                //{

                //    Utilitario.ShowToastr(this, "SELECCIONE UN TIPO DE CUENTA", "Mensaje", "error");

                //}
                //else
                //{

                    if (Convert.ToInt32(Request.QueryString["TipoRegistro"]) == 0)
                    {


                        if (ValidarDatosUsuario("Correo", tbxCorreo.Text, Tabla))
                        {
                            Utilitario.ShowToastr(this, "Este CORREO ELECTRONICO ya esta registrado.!", "Mensaje", "error");

                        }
                        else if (Tabla == "Usuario" && ValidarDatosUsuario("RNC", tbxRnc.Text, Tabla))
                        {

                            Utilitario.ShowToastr(this, "Este RNC O CEDULA ya esta registrado.!", "Mensaje", "error");

                        }
                        else if (us.Insertar(Tabla))
                        {
                       

                            if (Tipo == 1)
                            {
                                //ObtenerDatosCuentaBancaria(cb, us.UsuarioId);
                                //if (cb.Insertar())
                                //{
                                //    Utilitario.ShowToastr(this, "Error registro Cuenta.!", "Mensaje", "error");
                                //}

                                Session["UsuarioId"] = us.UsuarioId;
                                Session["UserName"] = Utilitario.Lista("Nombre", " from Usuario ", " where UsuarioId = " + us.UsuarioId).Rows[0]["Nombre"].ToString();

                                Response.Redirect("~/Registro/ReHerramienta.aspx");

                            }
                            else
                            {

                            }

                            Response.Redirect("~/Consulta/MenuAdm.aspx");

                        }
                        else
                        {
                            Utilitario.ShowToastr(this, "Error.!", "Mensaje", "error");
                        }

                    }
                    else
                    {
                        if (ValidarDatosUsuario("Correo", tbxCorreo.Text, Tabla))
                        {
                            Utilitario.ShowToastr(this, "Este CORREO ELECTRONICO ya esta registrado.!", "Mensaje", "error");

                        }
                        else if (Tabla == "Usuario" && ValidarDatosUsuario("RNC", tbxRnc.Text, Tabla))
                        {

                            Utilitario.ShowToastr(this, "Este RNC O CEDULA ya esta registrado.!", "Mensaje", "error");

                        }
                        else
                        {


                            if (Tipo == 0)
                            {
                                us.UsuarioId = Convert.ToInt32(Session["UsuarioCoId"]);

                            }
                            else if (Tipo == 1)
                            {
                                us.UsuarioId = Convert.ToInt32(Session["UsuarioId"]);
                            }

                            if (us.Editar(Tabla, TipoUsuarioId))
                            {
                                Response.Redirect("~/Consulta/MenuAdm.aspx");
                                Utilitario.ShowToastr(this, " Datos Actualizado.!", "Mensaje", "success");
                            }
                            else
                            {
                                Utilitario.ShowToastr(this, "Error Actualizar.!", "Mensaje", "error");
                            }

                        }

                    }
               // }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}