using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrestaGz.Consulta
{

    public partial class BuscarCliente : System.Web.UI.Page
    {
        public int Posicion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Thread.Sleep(3000);

                LLenarGridview();
                LLenarGridviewAbono();

                if (Request.Browser.IsMobileDevice)
                {

                }
                else
                {
                    divCliente.Style.Value = "border-bottom: 6px solid #848484; margin-left: 30%; margin-right: 30%; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";

                    div1.Style.Value = "margin-left:15%; margin-right:15%; border-bottom: 6px solid #848484; border-right: 5px solid #848484; border-radius: 15px; background-color: #045FB4; opacity: 0.93";
                    divGrdiAbono.Style.Value = "margin-left:38%";

                }


            }
        }

        public void ObtenerGridView()
        {
            gridCliente.DataSource = (DataTable)ViewState["Detalle"];
            gridCliente.DataBind();

        }
        public void LLenarGridview()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ClienteId"), new DataColumn("PrestamoId"), new DataColumn("Nombre"), new DataColumn("Telefono"), new DataColumn("Total"), });
            ViewState["Detalle"] = dt;


        }
        public float Total()
        {
            float total = gridAbono.Rows.Cast<GridViewRow>().Sum(x => Convert.ToSingle(x.Cells[0].Text));
            return total;
        }
        public void ObtenerDatos(Abono ab)
        {
            int id = Convert.ToInt32(Session["UsuarioCoId"]);

            ab.ClienteId = Convert.ToInt32(tbxCliente.Text);
            ab.PrestamoId = Convert.ToInt32(tbxPrestamo.Text);
            ab.UsuarioCoId = id;

            foreach (GridViewRow row in gridAbono.Rows)
            {
                ab.AgregarAbono(Convert.ToSingle(row.Cells[0].Text), row.Cells[1].Text);

            }
        }
        public void GuardarMora()
        {
            Mora mo = new Mora();

            mo.Cantidad = Convert.ToSingle(tbxAgregarMora.Text);
            mo.Fecha = Utilitario.FormatoFecha(DateTime.Now.ToString());
            mo.PrestamoId = Convert.ToInt32(tbxPrestamo.Text);
            mo.Estado = 0;

            if (mo.Insertar("Mora"))
            {
                Utilitario.ShowToastr(this, "MoraAgregada", "Mensaje", "success");
            }
        }
        public void ObtenerGridViewAbono()
        {
            gridAbono.DataSource = (DataTable)ViewState["Detalle2"];
            gridAbono.DataBind();

        }
        public void LLenarGridviewAbono()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Cantidad"), new DataColumn("Fecha") });
            ViewState["Detalle2"] = dt;


        }
        public bool ValidarAbonar()
        {
            bool Valor = true;
            if (tbxMontoTotal.Text == string.Empty)
            {
                Utilitario.ShowToastr(this, "BUSCAR UNA CUENTA PRIMERO", "Mensaje", "error");
                Valor = false;

            }
            else if (tbxAbono.Text == "")
            {
                Utilitario.ShowToastr(this, "INTRODUSCA UNA CANTIDAD", "Mensaje", "error");
                Valor = false;
            }

            return Valor;
        }
        public void LimpiarBuscarCliente()
        {

            gridCliente.DataSource = null;
            gridCliente.DataBind();

            ObtenerGridView();
            LLenarGridview();

            gridCliente.DataSource = null;
            gridCliente.DataBind();
            tbxBuscar.Text = string.Empty;

        }
        public void LimpiarDatAbono()
        {

            gridAbono.DataSource = null;
            gridCliente.DataBind();

            ObtenerGridViewAbono();
            LLenarGridviewAbono();

            gridAbono.DataSource = null;
            gridAbono.DataBind();

            div1.Visible = false;
            btnGuardar.Visible = false;

            tbxAtraso.Text = string.Empty;
            tbxAgregarMora.Text = string.Empty;

            divMora.Visible = false;


        }
        public void AplicarMora(int condicion, int cuota)
        {
            Mora Mo = new Mora();

            string FechaInicio = "";
            int cuota2 = 0;
            float auxCuota = 0;
            int cantidad = 0;
            float CantidadCuotaPrestamo = 0; //ESTA ES LA CANTIDAD DE $ CUOTA REGITRADA EN EL PRESTAMO



            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            dt = Utilitario.Lista(" FechaInicio,Cuota", " from Prestamo ", " where PrestamoId = " + tbxPrestamo.Text);
            dt2 = Utilitario.Lista(" Max(Fecha) as Fecha ", " from Abono ", " where PrestamoId  = " + tbxPrestamo.Text);


            FechaInicio = Utilitario.FormatoFecha(dt.Rows[0]["FechaInicio"].ToString());
            DateTime DateFechaInicio = Convert.ToDateTime(FechaInicio);
            cuota2 = Convert.ToInt32(dt.Rows[0]["Cuota"].ToString());

            string valortbla = dt2.Rows[0]["Fecha"].ToString();

            if (valortbla != string.Empty)      // ESTA CONDICIO ES SI HAY ABONO REGISTRADA PARA COMPARAR APARTIR DE AHI
            {
                DateTime FechaUltimaCuota = Convert.ToDateTime(dt2.Rows[0]["Fecha"].ToString());

                auxCuota = Utilitario.Cuota(cuota, DateTime.Now, DateFechaInicio);

            }
            else
            {
                auxCuota = Utilitario.Cuota(cuota, DateTime.Now, DateFechaInicio); //ES ES SI HAY RETRASO APARTIR DEL DIA DEL PRESTAMO
            }

            cantidad = CantidadCuota(auxCuota, cuota2);


            Mo.ClienteId = Convert.ToInt32(tbxCliente.Text);
            Mo.PrestamoId = Convert.ToInt32(tbxPrestamo.Text);
            Mo.Fecha = Utilitario.FormatoFecha(DateTime.Now.ToString());

            CantidadCuotaPrestamo = Convert.ToSingle(tbxCuota.Text);

            int UsuarioId = Utilitario.ObtenerIdUsuarioAdm( Convert.ToInt32(Session["UsuarioCoId"]));  //AQUI HAY QUE EXTRAER EL USUARIO

            if (cantidad == 0)
            {

                Mo.Cantidad = CantidadCuotaPrestamo + Utilitario.PorcientoMora(CantidadCuotaPrestamo, UsuarioId);   //AQUI SE MULTIPICA EL PORCIENTO DE LA MORA + LA CUOTA
                tbxAtraso.Text = Mo.Cantidad.ToString("N2");
            }
            else
            {
                Mo.Cantidad = CantidadCuotaPrestamo + Utilitario.PorcientoMora(CantidadCuotaPrestamo, UsuarioId) * cantidad;    //AQUI SE MULTIPICA EL PORCIENTO DE LA MORA + LA CUOTA X LA CANTIDAD DE TIEMPO DE CUOTA
                tbxAtraso.Text = Mo.Cantidad.ToString("N2");
            }


            if (condicion == 0)
            {

                Mo.Insertar("MoraAcumulada");
            }
            else
            {
                //ESTO ES PARA NO BORRAR LA FECHA DESDE CUANDO COMENZO A ACUMULAR MORA
                dt2 = Utilitario.Lista(" Fecha ", " from MoraAcumulada ", " where PrestamoId  = " + tbxPrestamo.Text);

                if (Utilitario.ValidarTabla(dt2))
                {
                    Mo.Fecha = Utilitario.FormatoFecha(dt2.Rows[0]["Fecha"].ToString());
                    Mo.Actualizar("MoraAcumulada");

                }

            }

        }
        public int CantidadCuota(float tiempo, int cuota2)
        {
            int resultado = 0;
            int cont = 0;

            if (cuota2 == 0)
            {
                resultado = Convert.ToInt32(tiempo);
            }
            else if (cuota2 == 1)
            {
                for (float x = tiempo; x > 1; x--)
                {
                    cont++;

                    if (cont == 16)
                    {
                        resultado += 1;
                        cont = 0;
                    }

                }
            }
            else if (cuota2 == 2)
            {

                if (tiempo == 1)
                {
                    resultado = 0;

                }

            }

            return resultado;
        }
        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string condicion = "";

            if (dropCliente.SelectedValue == "0")
            {
                condicion = " C.Nombre like '" + tbxBuscar.Text + "%'";
            }
            else if (dropCliente.SelectedValue == "1")
            {
                condicion = " C.Cedula =" + tbxBuscar.Text;
            }
            else if (dropCliente.SelectedValue == "2")
            {
                condicion = " C.Telefono =" + tbxBuscar.Text;
            }
            else if (dropCliente.SelectedValue == "3")
            {
                condicion = " P.ClienteId =" + tbxBuscar.Text;
            }

            dt = Utilitario.Lista(" P.ClienteId,P.PrestamoId, C.Nombre, C.Telefono,C.Cedula,P.Total  ", " from Cliente as C inner join Prestamo as P on P.ClienteId = C.ClienteId inner join UsuarioCo as Co on Co.UsuarioCoId  = P.UsuarioCoId inner join Usuario as U on U.UsuarioId = Co.UsuarioId ", " where " + condicion + " and P.Estado >=1 and P.Estado<=3 and Co.UsuarioCoId = "+Session["UsuarioCoId"]);

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
                div1.Visible = false;
                LimpiarBuscarCliente();


            }

        }
        protected void gridCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridCliente.SelectedRow;
            Cliente cli = new Cliente();
            DataTable dt = new DataTable();
          
            // PanelCliente.UpdateMode
           
            LimpiarDatAbono();
            string Campo = " A.PrestamoId,A.Cantidad,Format(A.Fecha,'dd/MM/yy','en-US') AS Fecha,P.Total,P.FechaTermino,P.Cuota,P.CantidadCuota,P.FechaCorte as FechaCorte ";
            string Tabla = " from  Abono as A inner join Prestamo as P on P.PrestamoId = A.PrestamoId ";
            string Condicion = " where A.PrestamoId = ";

            string clienteid = row.Cells[0].Text;
            string PrestamoId = row.Cells[1].Text;
            int cuota = 0;

            tbxCliente.Text = clienteid;
            tbxPrestamo.Text = PrestamoId;

            if (cli.Buscar(Convert.ToInt32(clienteid)))
            {
                lblAbono.Visible = true;
                tbxAbono.Visible = true;
                btnAgregar.Visible = true;
                divGrdiAbono.Visible = true;

                divCliente2.Visible = true;
                tbxNombre.Text = cli.Nombre;
                tbxCedula.Text = cli.Cedula;
                tbxDireccion.Text = cli.Direccion;
                tbxTelefono.Text = cli.Telefono;


                div1.Visible = true;


                dt = Utilitario.Lista(Campo, Tabla, Condicion + PrestamoId);

                if (dt.Rows.Count == 0)
                {
                    Campo = " PrestamoId,Total,FechaTermino,CantidadCuota,Cuota,FechaCorte ";
                    Tabla = " from  Prestamo ";
                    Condicion = " where PrestamoId = ";

                    dt = Utilitario.Lista(Campo, Tabla, Condicion + PrestamoId);

                    if (dt.Rows.Count > 0)
                    {
                        float Pendiente = Convert.ToSingle(dt.Rows[0]["Total"].ToString());
                        float Cuota = Convert.ToSingle(dt.Rows[0]["CantidadCuota"].ToString());


                        tbxPendiente.Text = Pendiente.ToString("N2");
                        tbxCuota.Text = Cuota.ToString("N2");
                        cuota = Convert.ToInt32(dt.Rows[0]["Cuota"].ToString());
                        lblgrid.Text = "0";
                    }

                }
                else
                {
                    lblgrid.Text = "1";
                    gridAbono.DataSource = dt;
                    gridAbono.DataBind();

                    ViewState["Detalle2"] = dt;
                    ObtenerGridViewAbono();

                }

                tbxMontoTotal.Text = dt.Rows[0]["Total"].ToString();
                tbxFecha.Text = Utilitario.FormatoFecha(dt.Rows[0]["FechaTermino"].ToString());
                tbxCuota.Text = dt.Rows[0]["CantidadCuota"].ToString();
                tbxAbono.Text = string.Empty;

            }

            DateTime FechaCorte = Convert.ToDateTime(dt.Rows[0]["FechaCorte"].ToString());

            if (DateTime.Now > FechaCorte)
            {

                DataTable dt2 = new DataTable();
                dt2 = Utilitario.Lista(" Fecha ", " from MoraAcumulada ", " where PrestamoId =" + PrestamoId);

                if (dt2.Rows.Count > 0)
                {
                    AplicarMora(1, cuota);

                }
                else
                {
                    AplicarMora(0, cuota);
                }

                divMora.Visible = true;
                tbxAbono.ReadOnly = true;
                btnAgregar.Visible = false;

            }
            else
            {


            }

            Pendiente();

        }
        public void Pendiente()
        {
            float total = 0;
            total = Convert.ToSingle(Total());

            tbxPendiente.Text = Convert.ToString(Convert.ToSingle(tbxMontoTotal.Text) - total);

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            float total = 0;
            try
            {
                if (ValidarAbonar())
                {
                    total = Convert.ToSingle(Total());

                    DataTable dt = (DataTable)ViewState["Detalle2"];
                    DataRow row;
                    row = dt.NewRow();

                    row["Cantidad"] = tbxAbono.Text;
                    row["Fecha"] = DateTime.Today.ToString("dd/MM/yy");

                    if (Total().ToString() == tbxMontoTotal.Text)
                    {
                        Utilitario.ShowToastr(this, "SALDADA", "Mensaje", "success");
                    }
                    else
                    {
                        dt.Rows.Add(row);
                        ViewState["Detalle2"] = dt;
                        ObtenerGridViewAbono();
                    }

                    tbxPendiente.Text = Convert.ToString(Convert.ToSingle(tbxMontoTotal.Text) - (Convert.ToSingle(tbxAbono.Text) + total));
                    tbxAbono.Text = string.Empty;

                    btnGuardar.Visible = true;
                    tbxAbono.ReadOnly = false;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Abono ab = new Abono();


                if (gridAbono.Rows.Count > 0)
                {

                    ObtenerDatos(ab);


                    if (lblgrid.Text == "0")
                    {
                        if (ab.Insertar())
                        {
                            ActualizarDatos();
                            if (tbxAtraso.Text != string.Empty)
                            {
                                GuardarMora();

                            }
                            else
                            {
                                Utilitario.ShowToastr(this, "Guardado", "Mensaje", "success");
                            }

                            div1.Visible = false;
                            btnGuardar.Visible = false;
                            // LimpiarDatAbono();
                            DivFalse();

                        }

                    }
                    else
                    {
                        ab.PrestamoId = Convert.ToInt32(tbxPrestamo.Text);
                        if (ab.Actualizar())
                        {     //ESTO ES CUANDO HAY UNA TABLA YA REGISTRADA
                            ActualizarDatos();

                            if (tbxAtraso.Text != string.Empty)
                            {
                                GuardarMora();


                            }
                            else
                            {
                                Utilitario.ShowToastr(this, "Abono agregado", "Mensaje", "success");
                            }

                            div1.Visible = false;
                            btnGuardar.Visible = false;
                            LimpiarDatAbono();
                        }

                    }

                    if (Convert.ToSingle(tbxPendiente.Text) <= 0)
                    {
                        Prestamo p = new Prestamo();

                        p.Estado = 4;
                        p.PrestamoId = Convert.ToInt32(tbxPrestamo.Text);
                        p.ActualizarEstado();
                        Utilitario.ShowToastr(this, "PRESTAMO SALDADO", "Mensaje", "error");

                    }
                    DivFalse();

                    
                }
                else
                {
                    Utilitario.ShowToastr(this, "AGREGUE UN ABONO", "Mensaje", "error");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        protected void btnAgregarMora_Click(object sender, EventArgs e)
        {
            Prestamo pre = new Prestamo();


            if (Convert.ToSingle(tbxAgregarMora.Text) == Convert.ToSingle(tbxAtraso.Text))
            {
                pre.Buscar(Convert.ToInt32(tbxPrestamo.Text));

                btnAgregar.Visible = true;
            
                tbxAbono.Text = tbxAgregarMora.Text;
                divMora.Visible = false;

            }
            else
            {
                Utilitario.ShowToastr(this, "ATRASO INCORRECTO", "Mensaje", "error");
                 tbxAgregarMora.Text = string.Empty;
            }

      

        }

        public void ActualizarDatos()
        {
            Prestamo pre = new Prestamo();
            int UsuarioId = Convert.ToInt32(Session["UsuarioCoId"]);
            string FechaCorte = "";

            pre.UsuarioCoId = UsuarioId;
            pre.PrestamoId = Convert.ToInt32(tbxPrestamo.Text);
            pre.Estado = 1;
            pre.Buscar(pre.PrestamoId);

            FechaCorte = Utilitario.FormatoFecha(GenerarFechaProximoCorte(pre.FechaCorte, pre.Cuota,Utilitario.ObtenerIdUsuarioAdm(UsuarioId)));
            pre.FechaCorte = FechaCorte;

            pre.ActualizarFechaCorte();
            pre.ActualizarEstado();



            //GENERARLE LA FECHA QUE REGISTROCORTE AL PRESTAMO Y LLEVARSELA A QUE ABONE ESA MISMA FECHA DE CORTE;
            //CREO QUE HAY QUE HACER OTRA FUNCION CORTE PARA ESTE CASO


        }

        public void txt()
        {
            int UsuarioId = Convert.ToInt32(Session["UsuarioCoId"]);
            DataTable dt = new DataTable();
            dt = Utilitario.Lista(" AbonoId,Cantidad,Fecha ", " from Abono ", " where PrestamoId = " + tbxPrestamo.Text);

            MemoryStream ms = new MemoryStream();
            TextWriter sw = new StreamWriter(ms);

            string Empresa = Utilitario.DatosHerramientas("Descripcion", Convert.ToString(Utilitario.ObtenerIdUsuarioAdm(UsuarioId)) , "5");
            string NumeroEmpresa = Utilitario.Lista(" U.Telefono ", " from Usuario as U inner join UsuarioCo as Uc on Uc.UsuarioId = U.UsuarioId ", " where Uc.UsuarioCoId = " + UsuarioId).Rows[0]["Telefono"].ToString();


            ObtenerGridView();

            sw.WriteLine("----------" + Empresa + "---------");
            sw.WriteLine("-----------Estado Abono------------");
            sw.WriteLine("Telefono:" + NumeroEmpresa);


            sw.WriteLine("------------------------------");
            sw.WriteLine("Cod:" + tbxPrestamo.Text);
            sw.WriteLine("USUARIO: " + Session["UserName"]);
            sw.WriteLine("FECHA: " + DateTime.Now.ToString("yyy/MM/dd"));
            sw.WriteLine("CLIENTE: " + tbxNombre.Text);
            sw.WriteLine("------------------------------");
            sw.WriteLine(" CANTIDAD | FECHA ");

            foreach (DataRow row in dt.Rows)
            {

               sw.WriteLine(" --- " + row[1].ToString() + " --- "

                + Utilitario.FormatoFecha(row[2].ToString()) + "--- ");

            }
      

            sw.WriteLine("------------------------------");
            sw.WriteLine("TOTAL: " + tbxMontoTotal.Text);
            sw.WriteLine("PENDIENTE: " + tbxPendiente.Text);

            sw.WriteLine("________________|____________");
            sw.WriteLine("Despachado Por -- Cliente");


            sw.Flush();
            byte[] bytes = ms.ToArray();
            ms.Close();

            Response.Clear();
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment;    filename=RepoAbono " + tbxPrestamo.Text + ".txt");
            Response.BinaryWrite(bytes);

            Response.End();


        }

        public string GenerarFechaProximoCorte(string Fecha, int cuota, int UsuarioId)
        {
            string Resultado = "";
            DateTime dtime = new DateTime();
            DateTime FechaAux = Convert.ToDateTime(Fecha);

            dtime = DateTime.Now;

            if (cuota == 0)
            {
                Resultado = FechaAux.Day + "/" + dtime.Month + "/" + dtime.Year;
                Resultado = Utilitario.GenerarFechaCorte(cuota, 5, Resultado, UsuarioId);

            }
            else
            {
                Resultado = Utilitario.GenerarFechaCorte(cuota, 5, DateTime.Now.ToString(), UsuarioId);
            }

            return Resultado;
        }

        protected void Imprimir_Click(object sender, EventArgs e)
        {
            txt();
        }

        public void DivFalse()
        {
            divMora.Visible = false;
            divFondo.Visible = false;
            divGrdiAbono.Visible = false;
            div1.Visible = false;
            btnGuardar.Visible = false;

            divImprimir.Visible = true;
        }

        public void Divpositivo()
        {
            divMora.Visible = false;
            divFondo.Visible = false;
            divGrdiAbono.Visible = false;
            div1.Visible = false;
            btnGuardar.Visible = false;

            divImprimir.Visible = true;
        }
    }
}