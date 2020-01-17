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
    public partial class ReHerramienta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Session["UsuarioId"].ToString());
                Herramienta h = new Herramienta();

                if (h.Buscar(id))
                {   
                    ObtenerDatos(id);
                    tbxCodigo.Visible = true;
                    lblCodigo.Visible = true;
                    tbxCodigo.Text = h.UsuarioId.ToString();
                    btnGuardar.Text = "Actualizar Datos";
                  
                }


            }

        }

        public string BuscarDatos(string Dato,string Valor,string UsuarioId)
        {
            string Resultado = "";
            DataTable dt = new DataTable();

            dt = Utilitario.Lista(" "+Dato, " from Herramienta ", " where Valor = " + Valor + " and UsuarioId =" + UsuarioId);

            Resultado = dt.Rows[0][Dato].ToString();

            return Resultado;
        }

        public void ObtenerDatos(int UsuarioId)
        {
            tbxPorcientoMora.Text = BuscarDatos("Cantidad","0",UsuarioId.ToString());
            tbxMes.Text = BuscarDatos("Cantidad","1",UsuarioId.ToString());
            tbxQuincena.Text = BuscarDatos("Cantidad", "2", UsuarioId.ToString());
            tbxDia.Text = BuscarDatos("Cantidad", "3", UsuarioId.ToString());           
            tbxNombreEmpresa.Text = BuscarDatos("Descripcion","5",UsuarioId.ToString());
       
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Herramienta h = new Herramienta();
             

                if (tbxCodigo.Text == string.Empty)
                {

                    if (InsertarHerramienta())
                    {
                        Utilitario.ShowToastr(this, "Guardado", "Mensaje", "success");
                        Response.Redirect("~/Consulta/MenuAdm.aspx");
                    }
                    else
                    {
                        Utilitario.ShowToastr(this, "Error", "Mensaje", "error");
                    }

                }
                else
                {
                    if (ActualizarHerramienta(2))
                    {
                        Utilitario.ShowToastr(this, "Actualizado", "Mensaje", "success");
                        Response.Redirect("~/Consulta/MenuAdm.aspx");
                    }
                    else
                    {
                        Utilitario.ShowToastr(this, "Error no se guardo un dato", "Mensaje", "error");
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertarHerramienta()
        {
            bool Resultado = false;
            Herramienta he = new Herramienta();
            string Fecha = Utilitario.FormatoFecha(DateTime.Now.ToString());

            he.UsuarioId = Convert.ToInt32(Session["UsuarioId"]);

            he.Fecha = Fecha;

            he.Cantidad = Convert.ToSingle(tbxPorcientoMora.Text);
            he.Descripcion = "Porciento Mora";
            he.Valor = 0;
            Resultado = he.Insertar();

            he.Cantidad = Convert.ToSingle(tbxMes.Text);
            he.Descripcion = "Dias Corte (Mes)";
            he.Valor = 1;
            Resultado = he.Insertar();

            he.Cantidad = Convert.ToSingle(tbxQuincena.Text);
            he.Descripcion = "Dias Corte (Quincena)";
            he.Valor = 2;
            Resultado = he.Insertar();

            he.Cantidad = Convert.ToSingle(tbxDia.Text);
            he.Descripcion = "Dias Corte (Dia)";
            he.Valor = 3;
            Resultado = he.Insertar();


            he.Cantidad = 5;
            he.Descripcion = "Actualizacion de Moras y Abonos";
            he.Valor = 4;
            Resultado = he.Insertar();


            he.Cantidad = 5;
            he.Descripcion = tbxNombreEmpresa.Text;
            he.Valor = 5;
            Resultado = he.Insertar();


            return Resultado;
        }

        public bool ActualizarHerramienta(int UsuarioId)
        {
            bool Resultado = false;
            Herramienta he = new Herramienta();

            he.UsuarioId = UsuarioId;
            Resultado = he.Actualizar(" Cantidad ={0} ", tbxPorcientoMora.Text, "0");

            Resultado = he.Actualizar(" Cantidad ={0} ", tbxMes.Text, "1");

            Resultado = he.Actualizar(" Cantidad ={0} ", tbxQuincena.Text, "2");

            Resultado = he.Actualizar(" Cantidad ={0} ", tbxDia.Text, "3");

            Resultado = he.Actualizar(" Descripcion ='{0}' ", tbxNombreEmpresa.Text, "5");


            return Resultado;
        }



    }
}