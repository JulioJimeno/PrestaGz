using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
   public class Cuadre
    {
        public int CuadreId { get; set; }
        public int UsuarioCoId { get; set; }
        public string Fecha { get; set; }
        public float Total { get; set; }
        public float P1 { get; set; }
        public float P5 { get; set; }
        public float P10 { get; set; }
        public float P25 { get; set; }
        public float P50 { get; set; }
        public float P100 { get; set; }
        public float P200 { get; set; }
        public float P500 { get; set; }
        public float P1000 { get; set; }
        public float P2000 { get; set; }
        public float TotalCheque { get; set; }
        public float TotalTarjeta { get; set; }
        public float TotalTransaccion { get; set; }
        public int CantidadCheque { get; set; }
        public int CantidadTarjeta { get; set; }
        public int CantidadTransaccion { get; set; }
        public List<Cuadre> Lista { get; set; }
        public string Condicion { get; set; }
        public int Estado { get; set; }

        public Cuadre()
        {
            this.CuadreId = 0;
            this.UsuarioCoId = 0;
            this.Fecha = "";
            this.Total = 0;
            this.P1 = 0;
            this.P5 = 0;
            this.P10 = 0;
            this.P25 = 0;
            this.P50 = 0;
            this.P100 = 0;
            this.P200 = 0;
            this.P500 = 0;
            this.P1000 = 0;
            this.P2000 = 0;
            this.TotalCheque = 0;
            this.TotalTarjeta = 0;
            this.TotalTransaccion = 0;
            this.CantidadCheque = 0;
            this.CantidadTarjeta = 0;
            this.CantidadTransaccion = 0;
            this.Lista = new List<Cuadre>();
            this.Condicion = "";
            this.Estado = 0;

        }
        public Cuadre(int CuadreId, int UsuarioId, string Fecha, float Total, float P1, float P5, float P10, float P20,
          float P50, float P100, float P200, float P500, float P1000, float P2000, float TotalCheque, float TotalTarjeta,
          float TotalTransaccion, int CantidadCheque, int CantidadTarjeta, int CantidadTransaccion)
        {
            this.CuadreId = CuadreId;
            this.UsuarioCoId = UsuarioId;
            this.Fecha = Fecha;
            this.Total = Total;
            this.P1 = P1;
            this.P5 = P5;
            this.P10 = P10;
            this.P25 = P25;
            this.P50 = P50;
            this.P100 = P100;
            this.P200 = P200;
            this.P500 = P500;
            this.P1000 = P1000;
            this.P2000 = P2000;
            this.TotalCheque = TotalCheque;
            this.TotalTarjeta = TotalTarjeta;
            this.TotalTransaccion = TotalTransaccion;
            this.CantidadCheque = CantidadCheque;
            this.CantidadTarjeta = CantidadTarjeta;
            this.CantidadTransaccion = CantidadTransaccion;

        }

        public void AgregarCuadre(int CuadreId, int UsuarioCoId, string Fecha, float Total, float P1, float P5, float P10, float P25,
          float P50, float P100, float P200, float P500, float P1000, float P2000, float TotalCheque, float TotalTarjeta,
          float TotalTransaccion, int CantidadCheque, int CantidadTarjeta, int CantidadTransaccion)
        {
            this.Lista.Add(new Cuadre(CuadreId, UsuarioCoId, Fecha, Total, P1, P5, P10, P25,
          P50, P100, P200, P500, P1000, P2000, TotalCheque, TotalTarjeta,
         TotalTransaccion, CantidadCheque, CantidadTarjeta, CantidadTransaccion));
        }

        public bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DbPresta db = new DbPresta();
            bool Valor = false;
            try
            {
                dt = db.ObtenerDatos(String.Format("Select * from Cuadre " + Condicion));
                if (dt.Rows.Count > 0)
                {
                    Valor = true;
                }

                foreach (DataRow row in dt.Rows)
                {
                    AgregarCuadre(Convert.ToInt32(row["CuadreId"]), Convert.ToInt32(row["UsuarioCoId"]), row["Fecha"].ToString(), Convert.ToSingle(row["Total"]), Convert.ToSingle(row["P1"]),
                       Convert.ToSingle(row["P5"]), Convert.ToSingle(row["P10"]), Convert.ToSingle(row["P25"]), Convert.ToSingle(row["P50"]),
                       Convert.ToSingle(row["P100"]), Convert.ToSingle(row["P200"]), Convert.ToSingle(row["P500"]), Convert.ToSingle(row["P1000"]), Convert.ToSingle(row["P2000"]), Convert.ToSingle(row["TotalCheque"]),
                       Convert.ToSingle(row["TotalTarjeta"]), Convert.ToSingle(row["TotalTransaccion"]), Convert.ToInt32(row["CantidadCheque"]), Convert.ToInt32(row["CantidadTarjeta"]), Convert.ToInt32(row["CantidadTransaccion"]));

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Valor;

        }
        public  bool Insertar()
        {
            DbPresta db = new DbPresta();
            bool Valor = false;
            object Identity;
            int Retornar = 0;
            try
            {
                Identity = db.ObtenerValor(String.Format("Insert into Cuadre(UsuarioCoId,Total,Fecha,P1,P5,P10,P25,P50,P100,P200,P500,P1000,P2000,Estado) values({0},{1},Convert(datetime,'{2}',5),{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) Select @@IDENTITY", this.UsuarioCoId, this.Total, this.Fecha, this.P1, this.P5, this.P10, this.P25, this.P50, this.P100, this.P200, this.P500, this.P1000, this.P2000,this.Estado));
                int.TryParse(Identity.ToString(), out Retornar);
                if (Retornar > 0)
                {
                    this.CuadreId = Retornar;
                    Valor = true;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return Valor;
        }

        
    }
}
