using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace PrestaGz.Registro
{
    public partial class ReCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LLenarGridview();

                int Id = 0;

                Id = Convert.ToInt32(Session["ClienteId"]);

                // Id = 18;
                lblIdCliente.Text = Id.ToString();

                if (Id > 0)
                {

                    ObtenerDatos(Id);
                    btnGuardar.Text = "ACTUALIZAR";
                }
            }
        }

        public void CapturarDatos(Cliente cli)
        {
            try
            {


                cli.UsuarioCoId = Convert.ToInt32(Session["UsuarioCoId"]);
                cli.Nombre = tbxNombre.Text;
                cli.Telefono = tbxTelefono.Text;
                cli.Cedula = tbxCedula.Text;
                cli.Direccion = tbxDireccion.Text;

                if (lblIdCliente.Text != "0")
                {


                }
                else
                {
                    cli.FechaNacimiento = Utilitario.FormatoFecha(tbxFecha.Text);
                    cli.FechaRegistro = DateTime.Now.ToString("dd/MM/yy");
                }

                cli.Estado = 1;

                OtrosDatos(cli);

            }catch(FormatException ex)
            {
                throw ex;
            }

        }
        public void OtrosDatos(Cliente cli)
        {
            int EstadoCivil = 0;
            if (radSoltero.Checked == false)
            {
                EstadoCivil = 1;
            }
            cli.DireccionTrabajo = tbxDireccionTrabajo.Text;
            cli.TelefonoTrabajo = tbxTelefonoTrabajo.Text;
            cli.EstadoCivil = EstadoCivil;


            if (GridLocation.Rows.Count == 0)
            {
                cli.AgregarUbicacion(Convert.ToInt32(lblIdCliente.Text), "NO HAY DIRECCION", 0, 0);
            }
            else
            {

                foreach (GridViewRow row in GridLocation.Rows)
                {
                    cli.AgregarUbicacion(Convert.ToInt32(lblIdCliente.Text), row.Cells[0].Text, Convert.ToSingle(row.Cells[1].Text), Convert.ToSingle(row.Cells[2].Text));
                }
            }

            if (tbxHijo.Text == string.Empty)
            {
                cli.Hijo = 0;
            }
            else
            {
                cli.Hijo = Convert.ToInt32(tbxHijo.Text);
            }

            if (tbxVehiculo.Text == string.Empty)
            {
                cli.Vehiculo = 0;
            }
            else
            {
                cli.Vehiculo = Convert.ToInt32(tbxVehiculo.Text);
            }

            if (tbxIngreo.Text == string.Empty)
            {
                cli.Ingreso = 0;
            }
            else
            {
                cli.Ingreso = Convert.ToSingle(tbxIngreo.Text);
            }

            if (tbxRemesa.Text == string.Empty)
            {
                cli.Remesa = 0;
            }
            else
            {
                cli.Remesa = Convert.ToSingle(tbxRemesa.Text);
            }



        }
        public void ObtenerDatos(int Id)
        {
            Cliente cli = new Cliente();
            DataTable dt = new DataTable();

            try
            {
                if (cli.Buscar(Id))
                {
                    // DateTime date = Convert.ToDateTime(cli.FechaNacimiento);
                    tbxNombre.Text = cli.Nombre;
                    tbxCedula.Text = cli.Cedula;
                    tbxTelefono.Text = cli.Cedula;
                    tbxFecha.Visible = false;
                    tbxFecha2.Visible = true;
                    lblEdad.Text = "Edad";
                    tbxFecha2.Text = Utilitario.ObtenerEdad(cli.FechaNacimiento);
                    tbxDireccion.Text = cli.Direccion;
                    tbxVehiculo.Text = cli.Vehiculo.ToString();
                    tbxDireccionTrabajo.Text = cli.DireccionTrabajo;
                    tbxTelefonoTrabajo.Text = cli.TelefonoTrabajo;
                    tbxHijo.Text = cli.Hijo.ToString();
                    tbxIngreo.Text = cli.Ingreso.ToString();
                    tbxRemesa.Text = cli.Remesa.ToString();


                    dt = Utilitario.Lista(" Descripcion,Latitude,Longitude ", " from Ubicacion ", " where ClienteId = " + Id);

                    GridLocation.DataSource = dt;
                    GridLocation.DataBind();

                    ViewState["Detalle"] = dt;
                    ObtenerGridView();


                    if (cli.EstadoCivil > 0)
                    {
                        radCasado.Checked = true;

                    }
                    else
                    {
                        radSoltero.Checked = true;
                    }


                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void ObtenerGridView()
        {
            GridLocation.DataSource = (DataTable)ViewState["Detalle"];
            GridLocation.DataBind();

        }
        public void LLenarGridview()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Descripcion"), new DataColumn("Latitude"), new DataColumn("Longitude") });
            ViewState["Detalle"] = dt;


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cli = new Cliente();
                CapturarDatos(cli);

                int Id = 0;
                Id = Convert.ToInt32(Session["ClienteId"]);

              
                    if (Id == 0)
                    {
                        if (cli.ValidarCliente(tbxCedula.Text, tbxNombre.Text, Utilitario.ObtenerIdUsuarioAdm(Convert.ToInt32(Session["UsuarioCoId"]))))
                        {
                            Utilitario.ShowToastr(this, "EL NOMBRE O CEDULA YA ESTA REGISTRADO(NO GUARDADO).!", "Mensaje", "error");
                        }
                        else
                        {
                            if (Convert.ToInt32(Session["UsuarioId"]) > 0)
                            {
                                cli.UsuarioCoId = Utilitario.ObtenerIdUsuarioColaborador(Convert.ToInt32(Session["UsuarioId"]));
                            }


                            if (cli.Insertar())
                            {
                                if (Convert.ToInt32(Session["UsuarioId"]) > 0)
                                {
                                    Response.Redirect("~/Consulta/MenuAdm.aspx");
                                }
                                else
                                {
                                    Response.Redirect("~/Consulta/Menu.aspx");
                                }


                            }
                            else
                            {
                                Utilitario.ShowToastr(this, "Error.!", "Mensaje", "error");
                            }


                        }

                    }
                    else
                    {

                        cli.ValidarCliente(tbxCedula.Text, tbxNombre.Text, Convert.ToInt32(Session["UsuarioId"]));

                        if (cli.CantidadCliente > 1)
                        {
                            Utilitario.ShowToastr(this, "EL NOMBRE O CEDULA YA ESTA REGISTRADO(NO GUARDADO).!", "Mensaje", "error");
                        }
                        else
                        {
                            cli.ClienteId = Convert.ToInt32(Session["ClienteId"]);
                            if (cli.Actualizar())
                            {
                                Response.Redirect("~/Consulta/MenuAdm.aspx");
                                Utilitario.ShowToastr(this, "Actualizado.!", "Mensaje", "success");
                            }
                            else
                            {
                                Utilitario.ShowToastr(this, "Error.!", "Mensaje", "error");
                            }

                        }

                    }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void radSoltero_CheckedChanged(object sender, EventArgs e)
        {
            radCasado.Checked = false;
        }

        protected void radCasado_CheckedChanged(object sender, EventArgs e)
        {
            radSoltero.Checked = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Detalle"];
            DataRow row;
            string latitude = "";
            string longitude = "";

            latitude = tbxlatitude.Text.Split(',').First();
            longitude = tbxlatitude.Text.Split(',').Last();

            if (latitude == longitude)
            {
                Utilitario.ShowToastr(this, "FORMATO DE LATITUDE Y LONGITUDE INCORRECTO.!", "Mensaje", "error");
                divEjemplo.Visible = true;
            }
            else
            {
                divEjemplo.Visible = false;
                row = dt.NewRow();

                row["Descripcion"] = tbxDescripcion.Text;
                row["Latitude"] = latitude;
                row["Longitude"] = longitude;



                dt.Rows.Add(row);
                ViewState["Detalle"] = dt;
                ObtenerGridView();

                tbxDescripcion.Text = string.Empty;
                tbxlatitude.Text = string.Empty;
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            //HAY QUE PROGRAMARLO EN HTML PARA QUE FUNCIONE
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int indexdeboton = gvr.RowIndex;
            DataTable dt = (DataTable)ViewState["Detalle"];
            dt.Rows[indexdeboton].Delete();
            GridLocation.DataSource = dt;
            GridLocation.DataBind();

        }

        protected void btnMapa_Click(object sender, ImageClickEventArgs e)
        {
            string pageurl = "https://www.google.com/maps";
            Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
        }
    }
}