using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrestaGz.Registro
{
    public partial class ReCuadre : System.Web.UI.Page
    {


        public string texto { get; set; }
        public string orden { get; set; }
        public int UsuarioId { get; set; }
        public int CuadreId { get; set; }
        public float Valor { get; set; }

        public ReCuadre()
        {
            this.texto = "";
            this.orden = "";
            this.CuadreId = 0;
            this.Valor = 0;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

                Thread.Sleep(3000);
            {
                if (dropCuadre.SelectedValue == "0")
                {
                    BuscarCuadre(DateTime.Now);
                }

                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {
                    DivBuscar.Style.Value = "border-bottom: 6px solid #848484; margin-left: 35%; margin-right: 35%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    Divfecha.Style.Value = "margin-left:22.5%";
                    divDinero.Style.Value = " margin-left: 15%; margin-right: 15%; border-bottom: 6px solid #848484; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                }
            }

        }

        public float Redondear(string Valor)
        {
            float Entero = Convert.ToSingle(Valor.Split('.').First());
            float Decimal = Convert.ToSingle(Valor.Split('.').Last());

            float Resultado = 0;

            if(Decimal > 5)
            {
                Resultado = Entero + 1;
            }
            else
            {
                Resultado = Entero;
            }

            return Resultado;

        }

        public void BuscarCuadre(DateTime Fecha)
        {
            Abono a = new Abono();
            int Id = Convert.ToInt32(Session["UsuarioCoId"]);
            string Campo = "";
            string Tabla = "";
            string Condicion = "";
            string Cantidad = "";
            float CantExistente = 0;

            DataTable dt = new DataTable();
            DataTable dtCliente = new DataTable();

            DateTime fecha = Fecha;

            string FechaHoy = fecha.Year + "/" + fecha.Month + "/" + fecha.Day + " 00:0:00.000 ";


            Campo = " Sum(A.Cantidad) as Cantidad ";
            Tabla = " from Abono as A inner join UsuarioCo as Uc on Uc.UsuarioCoId =  A.UsuarioCoId ";
            Condicion = " where A.Fecha = '" + FechaHoy + "' and A.UsuarioCoId = " + Id;



            dt = Utilitario.Lista(Campo, Tabla, Condicion);


            Cantidad = dt.Rows[0]["Cantidad"].ToString();
            CantExistente = ExistenciaCuadreDiario(Fecha);

            if (Cantidad != string.Empty)
            {

                if (CantExistente > 0)
                {
                    Cantidad = Convert.ToString(Convert.ToSingle(Cantidad) - CantExistente);

                }

                dtCliente = Utilitario.Lista(" DISTINCT ClienteId ", " FROM Abono ", " where Fecha = '" + FechaHoy + "'" + " and UsuarioCoId = " + Id);

                tbxCantCobrado.Text = dtCliente.Rows.Count.ToString();


                tbxTotalAIntroducir.Text =  Redondear(Cantidad).ToString("N2");

              //  tbxTotalAIntroducir.Text = Cantidad;



            }



        }
        public void ImprimirCuadre(int Id)
        {
            string Aux = "";
            string Valor = "";

            Aux = "3";
            Valor = Id.ToString();

            Response.Write("<script type='text/javascript'>detailedresults=window.open('/Reportes/ReportTodos.aspx?Aux= " + Aux + "&Valor= " + Valor + "');</script>");
        }

        public void Refrescar()
        {
            try
            {
                tbxTotalIntroducido.Text = Convert.ToString(Convert.ToSingle(tbxTotal1.Text) + Convert.ToSingle(tbxTotal5.Text) + Convert.ToSingle(tbxTotal10.Text) +
                    Convert.ToSingle(tbxTotal25.Text) + Convert.ToSingle(tbxTotal50.Text) + Convert.ToSingle(tbxTotal100.Text) +
                    Convert.ToSingle(tbxTotal200.Text) + Convert.ToSingle(tbxTotal500.Text) + Convert.ToSingle(tbxTotal1000.Text) + Convert.ToSingle(tbxTotal2000.Text));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Limpiar()
        {
            tbxTotal1.Text = "0";
            tbxTotal5.Text = "0";
            tbxTotal10.Text = "0";
            tbxTotal25.Text = "0";
            tbxTotal50.Text = "0";
            tbxTotal100.Text = "0";
            tbxTotal200.Text = "0";
            tbxTotal500.Text = "0";
            tbxTotal1000.Text = "0";
            tbxTotal2000.Text = "0";

            tbxTotalIntroducido.Text = "0";

            tbxTotalAIntroducir.Text = "0";



        }

        public void ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(tbxCantidad1.Text))
            {
                tbxCantidad1.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(tbxCantidad5.Text))
            {
                tbxCantidad5.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(tbxCantidad10.Text))
            {
                tbxCantidad10.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(tbxCantidad25.Text))
            {
                tbxCantidad25.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(tbxCantidad50.Text))
            {
                tbxCantidad50.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(tbxCantidad100.Text))
            {
                tbxCantidad100.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(tbxCantidad200.Text))
            {
                tbxCantidad200.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(tbxCantidad500.Text))
            {
                tbxCantidad500.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(tbxCantidad1000.Text))
            {
                tbxCantidad1000.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(tbxCantidad2000.Text))
            {
                tbxCantidad2000.Text = "0";
            }

        }
        public float ExistenciaCuadreDiario(DateTime Fecha)
        {
            Cuadre c = new Cuadre();
            DateTime Fe = Fecha;
            this.UsuarioId = Convert.ToInt32(Session["UsuarioCoId"]);
            float Resultado = 0;

            this.texto = " from Cuadre where Fecha  = '";
            this.orden = Fe.Year + "/" + Fe.Month + "/" + Fe.Day + " 00:0:00.000' AND UsuarioCoId = " + this.UsuarioId;

            foreach (DataRow row in Utilitario.Lista("Total", texto, orden).Rows)
            {
                Resultado += Convert.ToSingle(row["Total"]);
            }

            return Resultado;
        }

        public void ObtenerDatosCuadre(Cuadre c)
        {
            try
            {
                this.UsuarioId = Convert.ToInt32(Session["UsuarioCoId"]);
                ValidarDatos();

                c.Total = Convert.ToSingle(tbxTotalIntroducido.Text);
                c.P1 = Convert.ToSingle(tbxCantidad1.Text);
                c.P5 = Convert.ToSingle(tbxCantidad5.Text);
                c.P10 = Convert.ToSingle(tbxCantidad10.Text);
                c.P25 = Convert.ToSingle(tbxCantidad25.Text);
                c.P50 = Convert.ToSingle(tbxCantidad50.Text);
                c.P100 = Convert.ToSingle(tbxCantidad100.Text);
                c.P200 = Convert.ToSingle(tbxCantidad200.Text);
                c.P500 = Convert.ToSingle(tbxCantidad500.Text);
                c.P1000 = Convert.ToSingle(tbxCantidad1000.Text);
                c.P2000 = Convert.ToSingle(tbxCantidad2000.Text);

                c.UsuarioCoId = this.UsuarioId;
                c.Fecha = Utilitario.FormatoFecha(DateTime.Now.ToString());
                c.Estado = 1;
            }
            catch (FormatException )
            {
               
            }
        }

        public void MultiValor(TextBox Cantidad, TextBox Total, float canti)
        {

            if (Cantidad.Text == "")
            {
                Refrescar();
            }
            else
            {

                Total.Text = Convert.ToString(Convert.ToSingle(Cantidad.Text) * canti);

                Refrescar();


            }
        }

        protected void dropCuadre_TextChanged(object sender, EventArgs e)
        {
            if (dropCuadre.SelectedValue != "0")
            {
                Divfecha.Visible = true;
            }
        }


        protected void btnC10_Click(object sender, EventArgs e)
        {
            if (tbxCantidad10.Text == "")
            {
                tbxTotal10.Text = "0";
            }
            MultiValor(tbxCantidad10, tbxTotal10, 10);
        }

        protected void btnC25_Click(object sender, EventArgs e)
        {
            if (tbxCantidad25.Text == "")
            {
                tbxTotal25.Text = "0";
            }
            MultiValor(tbxCantidad25, tbxTotal25, 25);
        }

        protected void btn50_Click(object sender, EventArgs e)
        {
            if (tbxCantidad50.Text == "")
            {
                tbxTotal50.Text = "0";
            }
            MultiValor(tbxCantidad50, tbxTotal50, 50);
        }

        protected void btnC100_Click(object sender, EventArgs e)
        {
            if (tbxCantidad100.Text == "")
            {
                tbxTotal100.Text = "0";
            }
            MultiValor(tbxCantidad100, tbxTotal100, 100);
        }

        protected void btnC200_Click(object sender, EventArgs e)
        {
            if (tbxCantidad200.Text == "")
            {
                tbxTotal200.Text = "0";
            }
            MultiValor(tbxCantidad200, tbxTotal200, 200);
        }

        protected void btnC500_Click(object sender, EventArgs e)
        {
            if (tbxCantidad500.Text == "")
            {
                tbxTotal500.Text = "0";
            }
            MultiValor(tbxCantidad500, tbxTotal500, 500);
        }

        protected void btn1000_Click(object sender, EventArgs e)
        {
            if (tbxCantidad1000.Text == "")
            {
                tbxTotal1000.Text = "0";
            }
            MultiValor(tbxCantidad1000, tbxTotal1000, 1000);
        }

        protected void btn2000_Click(object sender, EventArgs e)
        {
            if (tbxCantidad2000.Text == "")
            {
                tbxTotal2000.Text = "0";
            }
            MultiValor(tbxCantidad2000, tbxTotal2000, 2000);
        }

        protected void dropCuadre_TextChanged1(object sender, EventArgs e)
        {
            if (dropCuadre.SelectedValue == "1")
            {
                Divfecha.Visible = true;
                Limpiar();
            }else
            {
                Divfecha.Visible = false;
                Limpiar();
            }

        }

        protected void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                if (dropCuadre.SelectedValue == "1")
                {
                    BuscarCuadre(Convert.ToDateTime(tbxFecha.Text));
                }
            }
            catch (FormatException)
            {
                Utilitario.ShowToastr(this, "Formato Fecha Incorrecto", "Mensaje", "error");
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cuadre c = new Cuadre();

            ObtenerDatosCuadre(c);

            if (Convert.ToSingle(tbxTotalIntroducido.Text) != Convert.ToSingle(tbxTotalAIntroducir.Text) || tbxTotalAIntroducir.Text == "0")
            {
                Utilitario.ShowToastr(this, "Total introducido debe ser igual al Total", "Mensaje", "error");
            }
            else
            {
                if (c.Insertar())
                {
                   
                    Utilitario.ShowToastr(this, "Guardado", "Mensaje", "success");
                    ImprimirCuadre(c.CuadreId);
                    Limpiar();
                }
            }
        }


        protected void tbxCantidad1_TextChanged1(object sender, EventArgs e)
        {
            if (tbxCantidad1.Text == "")
            {
                tbxTotal1.Text = "0";
            }

            MultiValor(tbxCantidad1, tbxTotal1, 1);

        }

        protected void tbxCantidad5_TextChanged(object sender, EventArgs e)
        {
            if (tbxCantidad5.Text == "")
            {
                tbxTotal5.Text = "0";
            }
            MultiValor(tbxCantidad5, tbxTotal5, 5);
        }

        protected void tbxCantidad10_TextChanged(object sender, EventArgs e)
        {
            if (tbxCantidad10.Text == "")
            {
                tbxTotal10.Text = "0";
            }
            MultiValor(tbxCantidad10, tbxTotal10, 10);
        }

        protected void tbxCantidad25_TextChanged(object sender, EventArgs e)
        {
            if (tbxCantidad25.Text == "")
            {
                tbxTotal25.Text = "0";
            }
            MultiValor(tbxCantidad25, tbxTotal25, 25);
        }

        protected void tbxCantidad50_TextChanged(object sender, EventArgs e)
        {
            if (tbxCantidad50.Text == "")
            {
                tbxTotal50.Text = "0";
            }
            MultiValor(tbxCantidad50, tbxTotal50, 50);
        }

        protected void tbxCantidad100_TextChanged(object sender, EventArgs e)
        {
            if (tbxCantidad100.Text == "")
            {
                tbxTotal100.Text = "0";
            }
            MultiValor(tbxCantidad100, tbxTotal100, 100);
        }

     

        protected void tbxCantidad500_TextChanged(object sender, EventArgs e)
        {
            if (tbxCantidad500.Text == "")
            {
                tbxTotal500.Text = "0";
            }
            MultiValor(tbxCantidad500, tbxTotal500, 500);
        }


        protected void tbxCantidad2000_TextChanged(object sender, EventArgs e)
        {
            if (tbxCantidad2000.Text == "")
            {
                tbxTotal2000.Text = "0";
            }
            MultiValor(tbxCantidad2000, tbxTotal2000, 2000);
        }

        protected void tbxCantidad200_TextChanged1(object sender, EventArgs e)
        {
            if (tbxCantidad200.Text == "")
            {
                tbxTotal200.Text = "0";
            }
            MultiValor(tbxCantidad200, tbxTotal200, 200);
        }

        protected void tbxCantidad1000_TextChanged1(object sender, EventArgs e)
        {
            if (tbxCantidad1000.Text == "")
            {
                tbxTotal1000.Text = "0";
            }
            MultiValor(tbxCantidad1000, tbxTotal1000, 1000);
        }
    }
}