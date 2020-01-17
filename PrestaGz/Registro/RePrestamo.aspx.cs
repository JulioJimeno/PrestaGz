using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.IO;

namespace PrestaGz.Registro
{
    public partial class RePrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cliente cli = new Cliente();
                LLenarGridview();
                LLenarGridviewCliente();

                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {
                    string margin = "40%";
                    divCliente.Style.Value = "margin-left:25%; margin-right:25%; border-bottom: 6px solid #848484; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    divPreta.Style.Value = "margin-left:15%; margin-right:15%; border-bottom: 6px solid #848484; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    divMonto.Style.Value = "margin-left:" + margin;
                    divFecha.Style.Value = "margin-left:" + margin;
                    divTotal.Style.Value = "margin-left:40%";
                    divBuscarCliente.Style.Value = "margin-left:25%; margin-right:25%; border-bottom: 6px solid #848484; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    divNota.Style.Value = "border-bottom: 2.5px solid #848484; margin-left: 1%; margin-right: 1%; border-right: 2px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";

                    GridComentario.Style.Value = "font-size: medium;width:400px;font-weight: bold";
                    tbxTaza.Style.Value = "font-weight: bold; border-radius: 5px; width:100px";
                    btnCalcular.Style.Value = "width:90px;font-weight: bold";
                    dropCuota.Style.Value = "font-weight: bold; width:198px";

                }

            }
        }
        public float InteresSimple(float monto, float tiempo, float taza)
        {
            float resultado = 0;
            float interes = 0;
            float taza1 = taza / 100;

            if(tiempo<=0)     //ESTO ESTA EN TENDENCIA DE REVICION Y ANALISIS
            {
                tiempo = 1;
            }

            interes = monto * taza1 * tiempo;
            tbxInteres.Text = interes.ToString("N2");

            resultado = interes + monto;

            return resultado;
        }
        public float ObtenerNumeroTiempo(string Fecha)
        {
            DateTime FechaFin = Convert.ToDateTime(Fecha);
            float resultado = Math.Abs((FechaFin.Month - DateTime.Now.Month) + 12 * (FechaFin.Year - DateTime.Now.Year));

            return resultado;

        }
        public void Cuotas()
        {
            DateTime FechaFin = new DateTime();

            if (radbFecha.Checked==true)
            {
               FechaFin = Convert.ToDateTime(tbxFecha.Text);

            }else
            {
                FechaFin = TiempoPorCuota();
            }
           
       
            float ReTiempo = Math.Abs((FechaFin.Month - DateTime.Now.Month) + 12 * (FechaFin.Year - DateTime.Now.Year));
            string Resultado = "";
            float Resultado2 = 0;

     
            if (FechaFin.Year == DateTime.Now.Year)
            {

                if (dropCuota.SelectedValue == "0")
                {
                    Resultado = Convert.ToString(Convert.ToSingle(tbxtotal.Text) / ReTiempo);
                }
                else if (dropCuota.SelectedValue == "1")
                {
                    Resultado = Convert.ToString((Convert.ToSingle(tbxtotal.Text) / ReTiempo) / 2);   //hay que analizar esto para que caiga en 15

                }
                else if (dropCuota.SelectedValue == "2")
                {
                    Resultado = Convert.ToString(Convert.ToSingle(tbxtotal.Text) / Convert.ToSingle(Utilitario.ObtenerDias(FechaFin, DateTime.Now))); //AQUI ESTA DIVIDIENDO LOS DIAS POR EL MONTO PRESTADO
                }

            }
            else
            {
                if (dropCuota.SelectedValue == "0")
                {

                    Resultado = Convert.ToString(Convert.ToSingle(tbxtotal.Text) / ReTiempo);
                }
                if (dropCuota.SelectedValue == "1")
                {

                    Resultado = Convert.ToString((Convert.ToSingle(tbxtotal.Text) / ReTiempo) / 2); //hay que analizar esto para que caiga en 15
                }
                if (dropCuota.SelectedValue == "2")
                {
                    Resultado = Convert.ToString(Convert.ToSingle(tbxtotal.Text) / Convert.ToSingle(Utilitario.ObtenerDias(FechaFin, DateTime.Now))); //AQUI ESTA DIVIDIENDO LOS DIAS POR EL MONTO PRESTADO 
                }

             

            }

                Resultado2 = Convert.ToSingle(Resultado);

            tbxCuotaPrestar.Text = Resultado2.ToString("N2");
        }
        public string ConvertirCuotastring()
        {
            string Resultado = "";

            if (dropCuota.SelectedValue == "0")
            {
                Resultado = "MENSUAL";

            }
            else if (dropCuota.SelectedValue == "1")
            {
                Resultado = "QUINCENAL";

            }
            else
            {
                Resultado = "DIARIO";
            }


            return Resultado;

        }
        public void txt(int PrestamoId)
        {

            try
            {


                string NombreEmpresa = "";
                int UsuarioId = Convert.ToInt32(Session["UsuarioCoId"]);

                Usuario us = new Usuario();
                NombreEmpresa = Utilitario.DatosHerramientas("Descripcion", UsuarioId.ToString(), "5");


                MemoryStream ms = new MemoryStream();
                TextWriter sw = new StreamWriter(ms);

                //32 CARACTERES PARA LA OJA TERMICA
                sw.WriteLine("*******" + NombreEmpresa + "******");
                sw.WriteLine("*******REGISTRO DE PRESTAMO*****");
                sw.WriteLine("TELEFONO:" + BuscarDatosEmpresa() + "");

                sw.WriteLine("********************************");
                sw.WriteLine("COD:" + PrestamoId.ToString());
                sw.WriteLine("USUARIO: " + Session["UserName"]);
                sw.WriteLine("FECHA: " + DateTime.Now.ToString("yyy/MM/dd"));
                sw.WriteLine("CLIENTE: " + tbxNombre.Text);

                sw.WriteLine("********************************");
                sw.WriteLine("$CUOTAS: " + tbxCuotaPrestar.Text);
                sw.WriteLine("TIEMPO COBRO: " + ConvertirCuotastring());
                sw.WriteLine("TOTAL + INTERES: " + tbxtotal.Text);
                sw.WriteLine("_________________|_______________");
                sw.WriteLine(" REGISTRADO POR --- CLIENTE");

                sw.Flush();
                byte[] bytes = ms.ToArray();
                ms.Close();

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment;    filename=Factura " + tbxNombre.Text + PrestamoId + ".txt");
                Response.BinaryWrite(bytes);

                Limpiar();

                Response.End();

            }
            catch (Exception e)
            {
                throw e;
            }


        }
        public void Limpiar()
        {
            tbxBuscar.Text = string.Empty;
            tbxCedula.Text = string.Empty;
            tbxCodigoCliente.Text = string.Empty;
            tbxCuotaPrestar.Text = string.Empty;
            tbxDireccion.Text = string.Empty;
            tbxFecha.Text = string.Empty;
            tbxInteres.Text = string.Empty;
            tbxMonto.Text = string.Empty;
            tbxNombre.Text = string.Empty;
            tbxNota.InnerText = string.Empty;
            tbxTaza.Text = string.Empty;
            tbxTelefono.Text = string.Empty;
            tbxtotal.Text = string.Empty;

        }
        public string BuscarDatosEmpresa()
        {
            string Resultado = "";
            int Id = Convert.ToInt32(Session["UsuarioCoId"]);
            DataTable dt = new DataTable();
            dt = Utilitario.Lista(" U.Telefono as Telefono ", " from Usuario as U inner join UsuarioCo as Uc on Uc.UsuarioId = U.UsuarioId ", " where Uc.UsuarioCoId =  " + Id.ToString());

            if (dt.Rows.Count > 0)
            {
                Resultado = dt.Rows[0]["Telefono"].ToString();

            }

            return Resultado;
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
        public void ObtenerGridViewCliente()
        {
            gridCliente.DataSource = (DataTable)ViewState["Detalle2"];
            gridCliente.DataBind();

        }
        public void LLenarGridviewCliente()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ClienteId"), new DataColumn("Nombre"), new DataColumn("Telefono"), new DataColumn("Cedula"), new DataColumn("Direccion") });
            ViewState["Detalle2"] = dt;

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
        public void CapturarDatos(Prestamo pre)
        {
            int UsuarioId = Convert.ToInt32(Session["UsuarioCoId"]);
            pre.ClienteId = Convert.ToInt32(tbxCodigoCliente.Text);  
            pre.UsuarioCoId = UsuarioId;
            pre.Cuota = Convert.ToInt32(dropCuota.SelectedValue);
            pre.Taza = Convert.ToSingle(tbxTaza.Text) / 100;
            pre.Monto = Convert.ToSingle(tbxMonto.Text);
            pre.Interes = Convert.ToSingle(tbxInteres.Text);

            if(radbNumeroCuota.Checked == true)
            {
                pre.FechaTermino = Utilitario.FormatoFecha(TiempoPorCuota().ToString());
            }
            else
            {
               pre.FechaTermino = Utilitario.FormatoFecha(tbxFecha.Text);
            }
            
            


            pre.Total = Convert.ToSingle(tbxtotal.Text);
            pre.FechaInicio = Utilitario.FormatoFecha(DateTime.Now.ToString());
            pre.Estado = 1;
            pre.TotalMora = 0;
            pre.CantidadCuota = Convert.ToSingle(tbxCuotaPrestar.Text);

            pre.FechaCorte = Utilitario.FormatoFecha(Utilitario.FechaCorte(DateTime.Now.ToString(), Utilitario.ObtenerIdUsuarioAdm(UsuarioId), pre.Cuota));  //GENERA LA FECHA DEL CORTE

        }
        protected void dropCuota_TextChanged(object sender, EventArgs e)
        {
            tbxTaza.Text = string.Empty;
        }
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            float taza = Convert.ToSingle(tbxTaza.Text);
            float tiempo = 0;
            try
            {

                string loco = tbxFecha.Text;
                if (radbFecha.Checked == true && tbxFecha.Text == string.Empty)
                {

                    Utilitario.ShowToastr(this, "FORMATO DE LA FECHA ES INCORRECTO DIA/MES/AñO", "Mensaje", "error");

                }
                else if (radbNumeroCuota.Checked == true && tbxCantidadCuota.Text == string.Empty)
                {
                    Utilitario.ShowToastr(this, "CAMPO CUOTAS ESTA VACIO", "Mensaje", "error");
                }
                else
                {

                    if (radbFecha.Checked == true)
                    {
                        tiempo = ObtenerNumeroTiempo(tbxFecha.Text);

                    }
                    else
                    {
                        tiempo = ObtenerNumeroTiempo(Convert.ToString(TiempoPorCuota()));
                    }


                    float monto = Convert.ToSingle(tbxMonto.Text);
                    tbxtotal.Text = InteresSimple(monto, tiempo, taza).ToString("N2");

                    btnGuardar.Visible = true;
                    Cuotas();
                }
            }catch(Exception EX)
            {
                throw EX;
               // Utilitario.ShowToastr(this, "FORMATO DE LA FECHA ES INCORRECTO DIA/MES/AñO", "Mensaje", "error");
            }

        }
        protected void btnNota_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Detalle"];
            DataRow row;
            row = dt.NewRow();

            row["Descripcion"] = tbxNota.InnerText;
            row["Fecha"] = DateTime.Now.ToString("dd/mm/yy");

            dt.Rows.Add(row);
            ViewState["Detalle"] = dt;
            ObtenerGridView();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Prestamo pre = new Prestamo();
            Nota no = new Nota();
            try
            {
                CapturarDatos(pre);
                if (pre.Insertar())
                {
                    CapturaNota(no, pre.PrestamoId, pre.ClienteId);

                    Session["PrestamoId"] = pre.PrestamoId;
                    if (no.Insertar())
                    {
                        Utilitario.ShowToastr(this, "PRESTAMO REGISTRADO & NOTA AGREGADA.!", "Mensaje", "success");

                    }


                    Utilitario.ShowToastr(this, "PRESTAMO REGISTRADO.!", "Mensaje", "success");

                    divNota.Visible = false;
                    divPreta.Visible = false;
                    divFecha.Visible = false;
                    divMonto.Visible = false;
                    divCliente.Visible = false;
                    btnGuardar.Visible = false;
                    divImprimir.Visible = true;


                }


            }
            catch (Exception ex)
            {
                throw ex;


            }
        }
        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string condicion = "";
            int UsuarioCoId = Convert.ToInt32(Session["UsuarioCoId"]);

            if (dropCliente.SelectedValue == "0")
            {
                condicion = " Nombre like '" + tbxBuscar.Text + "%' and UsuarioCoId = " + UsuarioCoId;
            }
            else if (dropCliente.SelectedValue == "1")
            {
                condicion = " Cedula =" + tbxBuscar.Text + "%' and UsuarioCoId = " + UsuarioCoId;
            }
            else if (dropCliente.SelectedValue == "2")
            {
                condicion = " Telefono =" + tbxBuscar.Text + "%' and UsuarioCoId = " + UsuarioCoId;
            }
            else if (dropCliente.SelectedValue == "3")
            {
                condicion = " ClienteId =" + tbxBuscar.Text;
            }

            dt = Utilitario.Lista(" ClienteId,Nombre,Telefono,Cedula,Direccion ", " from Cliente ", " where " + condicion + " and Estado =1");

            if (dt.Rows.Count > 0)
            {

                gridCliente.DataSource = dt;
                gridCliente.DataBind();
                lblNoEncontrado.Visible = false;

            }
            else
            {
                Utilitario.ShowToastr(this, "NO SE ENCONTRARON RESULTADO", "Mensaje", "error");
                lblNoEncontrado.Visible = true;
                gridCliente.DataSource = null;
                gridCliente.DataBind();

            }
        }
        protected void gridCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridCliente.SelectedRow;
            Cliente cli = new Cliente();


            DataTable dtAux = new DataTable();

            dtAux = Utilitario.Lista(" ClienteId ", " from Prestamo ", " where ClienteId = " + row.Cells[0].Text + " and Estado >=1 and Estado <=3 ");

            if (dtAux.Rows.Count > 0)
            {

                Utilitario.ShowToastr(this, "ESTE CLIENTE TIENE PRESTAMO PENDIENTE", "Mensaje", "error");

            }
            else
            {
                Limpiar();
                divNota.Visible = true;
                divPreta.Visible = true;
                divFecha.Visible = true;
                divMonto.Visible = true;
                divCliente.Visible = true;

                tbxCodigoCliente.Text = row.Cells[0].Text;
                tbxNombre.Text = row.Cells[1].Text;
                tbxTelefono.Text = row.Cells[2].Text;
                tbxCedula.Text = row.Cells[3].Text;
                tbxDireccion.Text = row.Cells[4].Text;
                divNota.Visible = true;
                divPreta.Visible = true;


            }




        }
        protected void Imprimir_Click(object sender, EventArgs e)
        {
            txt(Convert.ToInt32(Session["PrestamoId"]));
        }

        public DateTime TiempoPorCuota()
        {

            int CantidadCuota = Convert.ToInt32(tbxCantidadCuota.Text);
            DateTime tiempo = new DateTime();
            DateTime tiempo2 = new DateTime();
                
              tiempo  = DateTime.Now;
          
            if(dropCuota.SelectedValue == "0")
            {   
              tiempo2 =  tiempo.AddMonths(CantidadCuota);

            } else if(dropCuota.SelectedValue == "1")
            {
              tiempo2 =  tiempo.AddDays(CantidadCuota*15);
            }
            else
            {
               tiempo2 = tiempo.AddDays(CantidadCuota);
            }

            return tiempo2;
               // Convert.ToDateTime(tiempo2.Day+"/"+tiempo2.Month+"/"+tiempo2.Year);
    
        }

        protected void radbNumeroCuota_CheckedChanged(object sender, EventArgs e)
        {
            divFinalSaldo.Visible = false;
            radbFecha.Checked = false;
            divCantidadCuota.Visible = true;
        }

        protected void radbFecha_CheckedChanged(object sender, EventArgs e)
        {
            radbNumeroCuota.Checked = false;
            divCantidadCuota.Visible = false;
            divFinalSaldo.Visible = true;

           
        }
    }
}