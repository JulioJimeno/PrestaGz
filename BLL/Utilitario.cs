using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using BLL;
using DAL;

namespace BLL
{
    public static class Utilitario
    {
        public static void ShowToastr(this Page page, string mensaje, string titulo, string tipo = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", tipo.ToLower(), mensaje, titulo), addScriptTags: true);


        }
        public static string ObtenerEdad(string Fecha)
        {
            int edad = 0;
            string mes = "";
            string dia = "";
            string ano = "";
            string resultado = "";


            try
            {
                DateTime dat = Convert.ToDateTime(Fecha);
                DateTime nacimiento = new DateTime(dat.Year, dat.Month, dat.Day);
                edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                resultado = edad.ToString();

                mes = dat.Month.ToString();
                dia = dat.Day.ToString();
                ano = dat.Year.ToString();

            }
            catch (Exception)
            {
                resultado = dia + "/" + mes + "/" + ano;
            }

            return resultado;
        }
        public static string ObtenerDias(DateTime newdt, DateTime olddt)
        {
            string valor = "";

            TimeSpan ts = newdt - olddt;

            valor = ts.Days.ToString();
            return valor;
        }

        public static float ObtenerMes(DateTime FechaInicio, DateTime FechaFin)
        {

            return Math.Abs((FechaFin.Month - FechaInicio.Month) + 12 * (FechaFin.Year - FechaInicio.Year));

           
        }
        public static float Cuota(int valor, DateTime FechaFin, DateTime FechaInicio)
        {
            float resultado = 0;
            float valor2 = 0;

            if (valor == 0)
            {
                int compMonth = (FechaFin.Month + FechaFin.Year * 12) - (FechaInicio.Month + FechaInicio.Year * 12);

                double daysInEndMonth = (FechaFin - FechaFin.AddMonths(1)).Days; //ESTO ES PARA SABER DE CUANTO DIAS ES EL MES
                double months = compMonth + (FechaInicio.Day - FechaFin.Day) / daysInEndMonth; //ESTO HAY QUE CONVERTIRLO EN UN SOLO NUMERO

                string numStr = months.ToString();
                resultado = Convert.ToSingle(int.Parse(numStr.Split('.')[0]));

            }
            else if (valor == 1)
            {
                valor2 = Convert.ToSingle(ObtenerDias(FechaInicio, FechaFin));

                if (valor2 > 15)
                {
                    resultado = valor2; //si es quincenal pero ponerle un dia mas para completar los 15 dias rrecorridos
                }

            }
            else if (valor == 2)
            {
                valor2 = Convert.ToSingle(ObtenerDias(FechaInicio, FechaFin));

                if (valor2 > 1)
                {
                    resultado = valor2;
                }

            }


            return resultado;
        }
        public static string FormatoFecha(string Fechadata)
        {
            string fecha = "";

            DateTime date = Convert.ToDateTime(Fechadata);

            String var = date.Year.ToString();
            int tam_var = var.Length;
            String Var_Sub = var.Substring((tam_var - 2), 2);      //COJE LOS ULTIMOS DOS CARACTERES DE UNA CADENA

            fecha = date.Day.ToString() + "/" + date.Month.ToString() + "/" + Var_Sub;

            return fecha;
        }
        public static bool AlertarMora(int PrestamoId)
        {
            bool Retornar = false;

            string FechaInicio = "";
            float TiempoCuota = 0;
            int cuota = 0;
            try
            {

                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();

                dt = Lista(" FechaInicio,Cuota ", " from Prestamo ", " where PrestamoId = " + PrestamoId.ToString());
                dt2 = Lista(" Max(Fecha) as Fecha ", " from Abono ", " where PrestamoId  = " + PrestamoId.ToString());

                FechaInicio = dt.Rows[0]["FechaInicio"].ToString();

                    //FormatoFecha(dt.Rows[0]["FechaInicio"].ToString()); ESTO DA ERROR (CONSEJO SOLO USARLO PARA GUARDAR LOS DATOS A LA BASE DE DATO)

                DateTime DateFechaInicio = Convert.ToDateTime(FechaInicio);  //-
                cuota = Convert.ToInt32(dt.Rows[0]["Cuota"].ToString());

                TiempoCuota = Cuota(cuota, DateTime.Today, DateFechaInicio);
                string Abono = dt2.Rows[0]["Fecha"].ToString();

                if (Abono != string.Empty)
                {

                    DateTime dateFechaAbono = Convert.ToDateTime(Abono); //-
                    TiempoCuota = Cuota(cuota, dateFechaAbono, DateTime.Now);

                    if (TiempoCuota >= 1)
                    {
                        Retornar = true;

                    }

                }
                else if (TiempoCuota >= 1)
                {
                    Retornar = true;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


            return Retornar;

        }
        public static DataTable Lista(string Campo, string Tabla, string Condicion)
        {
            DataTable dt = new DataTable();
            DbPresta db = new DbPresta();
            dt = db.ObtenerDatos(String.Format("Select " + Campo + Tabla + Condicion));


            return dt;

        }
        public static bool ValidarTabla(DataTable dt)
        {
            bool Retornar = false;

            if (dt.Rows.Count > 0)
            {
                Retornar = true;
            }

            return Retornar;
        }
        public static float PorcientoMora(float CantidadCuota, int UsuarioId)
        {
            float resultado = 0;
          
            resultado = Convert.ToSingle(DatosHerramientas("Cantidad", UsuarioId.ToString(),"0"));

            return CantidadCuota * (resultado / 100);
        }
        public static string FechaCorte(string fecha, int usuarioId, int Cuota)
        {
            string resultado = "";

            DataTable dt = new DataTable();

            if (Cuota == 0)
            {
                //MENSUAL
                resultado = GenerarFechaCorte(Cuota, 2, fecha, usuarioId);

            }
            else if (Cuota == 1)
            {
                //QUINCENAL     verificar esto
                resultado = GenerarFechaCorte(Cuota, 3, fecha, usuarioId);
            }
            else if (Cuota == 2)
            {
                //DIARIO     y esto
                resultado = GenerarFechaCorte(Cuota, 4, fecha, usuarioId);
            }

            return resultado;

        }
        public static string GenerarFechaCorte(int cuota, int Herramienta, string Fecha, int UsuarioId)
        {
            string resultado = "";
          
            DateTime FechaAux = Convert.ToDateTime(Fecha);
            DataTable dt = new DataTable();
            int diaAux = 0;

            dt = Lista(" Cantidad ", " from Herramienta ", " where Valor = " + Herramienta + " and UsuarioId = " + UsuarioId);


            if (cuota == 1)
            {
                diaAux = 15;

            }
            else if (cuota == 2)
            {
                diaAux = 1;
            }


            if (ValidarTabla(dt))
            {
                 
                int dias = 0;

                if (cuota == 0)
                {  //AQUI SI ES UN MES AGREGO UN MES PRIMERO Y DESPUES LOS DIAS.
                    DateTime FechaDefinitiva = new DateTime();
                    try
                    {
                        FechaDefinitiva = FechaAux.AddMonths(1);

                        dias = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());
                        resultado = Convert.ToString(FechaDefinitiva.AddDays(dias));


                    }
                    catch(Exception )
                    {
                       FechaDefinitiva.AddMonths(1).AddDays(-1);
                       FechaDefinitiva.AddDays(dias);

                        resultado = Convert.ToString(FechaDefinitiva); 
                    }
           
                }
                else
                {
                    int Aux = 0;

                    Aux = Convert.ToInt32(dt.Rows[0]["Cantidad"].ToString());

                    resultado = Convert.ToString(FechaAux.AddDays(Aux + diaAux));
                }


            }

            return resultado;
        }
        public static string DatosHerramientas(string Campo,  string UsuarioId, string Valor)
        {
            string Resultado = "";
            DataTable dt = new DataTable();

            dt = Utilitario.Lista(" H.Descripcion as Descripcion,H.Cantidad as Cantidad,H.Fecha as Fecha  ", " from Herramienta as H inner join Usuario as U on U.UsuarioId = H.UsuarioId ", " where H.Valor = "+Valor+" and U.UsuarioId =" + UsuarioId);

            if(dt.Rows.Count>0)
            {
               Resultado = Convert.ToString(dt.Rows[0][Campo].ToString());

            }else
            {
                Resultado = "0";
            }
            


            return Resultado;
        }
        public static int ObtenerIdUsuarioAdm(int IdUsuarioCo)
        {
            int Resultado = 0;
            DataTable dt = new DataTable();

            dt = Lista(" U.UsuarioId AS UsuarioId "," from Usuario as U inner join UsuarioCo as Uc on Uc.UsuarioId = U.UsuarioId "," where Uc.UsuarioCoId = "+IdUsuarioCo);

            if(dt.Rows.Count>0)
            {
                Resultado = Convert.ToInt32(dt.Rows[0]["UsuarioId"].ToString());
            }

            return Resultado;

        }

        public static int ObtenerIdUsuarioColaborador(int IdUsuario)
        {
            int Resultado = 0;
            DataTable dt = new DataTable();

            dt = Lista(" Max(UsuarioCoId) AS UsuarioCoId ", " from UsuarioCo  ", " where UsuarioId = " + IdUsuario);

            if (dt.Rows.Count > 0)
            {
                Resultado = Convert.ToInt32(dt.Rows[0]["UsuarioCoId"].ToString());
            }

            return Resultado;

        }

    }
}
