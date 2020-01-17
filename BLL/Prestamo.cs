using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public int UsuarioCoId { get; set; }
        public int ClienteId { get; set; }
        public int Cuota { get; set; }
        public float Taza { get; set; }
        public float Monto { get; set; }
        public float Interes { get; set; }
        public float Total { get; set; }
        public float CantidadCuota { get; set; }
        public float TotalMora { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string FechaCorte { get; set; }
        public int Estado { get; set; }
  

        public Prestamo()
        {
            this.PrestamoId = 0;
            this.ClienteId = 0;
            this.UsuarioCoId = 0;
            this.Cuota = 0;
            this.Cuota = 0;
            this.Monto = 0;
            this.Interes = 0;
            this.FechaInicio = "";
            this.FechaTermino = "";
            this.FechaCorte = "";
            this.Estado = 0;
            this.Total = 0;
            this.TotalMora = 0;
            this.CantidadCuota = 0;
           
        }
        public bool Insertar()
        {
            bool Retornar = false;
            object identity = null;
            int id = 0;
            try
            {
                DbPresta db = new DbPresta();

                identity = db.ObtenerValor(String.Format("Insert into Prestamo(ClienteId,Cuota,Taza,Monto,Interes,FechaInicio,FechaTermino,Estado,Total,CantidadCuota,FechaCorte,UsuarioCoId) values({0},{1},{2},{3},{4},Convert(datetime,'{5}',5),Convert(datetime,'{6}',5),{7},{8},{9},Convert(datetime,'{10}',5),{11}) select @@Identity",
                                                     this.ClienteId,this.Cuota,this.Taza,this.Monto,this.Interes,this.FechaInicio,this.FechaTermino,this.Estado,this.Total,this.CantidadCuota,this.FechaCorte,this.UsuarioCoId));

                int.TryParse(identity.ToString(), out id);
                if(id>0)
                {
                    Retornar = true;
                    this.PrestamoId = id;
                }

            }
            catch(Exception e)
            {
                throw e;
            }

            return Retornar;
        }
        public bool Buscar(int id)
        {
            bool retornar = false;
            DataTable dt = new DataTable();
            DbPresta db = new DbPresta();
            
            try
            {

                dt = db.ObtenerDatos(String.Format("Select * from Prestamo where PrestamoId = "+id.ToString()+" and UsuarioCoId = "+this.UsuarioCoId));  

                if(dt.Rows.Count>0)
                {
                    this.Total = Convert.ToSingle(dt.Rows[0]["Total"].ToString());
                    this.Interes = Convert.ToSingle(dt.Rows[0]["Interes"].ToString());
                    this.CantidadCuota = Convert.ToSingle(dt.Rows[0]["CantidadCuota"].ToString());
                    this.Cuota = Convert.ToInt32(dt.Rows[0]["Cuota"].ToString());
                    this.FechaCorte = dt.Rows[0]["FechaCorte"].ToString();
                }

            }catch(Exception e)
            {
                throw e;
            }

            return retornar;
        }
        public void ActualizarEstado()
        {
            DbPresta db = new DbPresta();

            try
            {        
                db.Ejecutar(String.Format("Update Prestamo set Estado = {0} where PrestamoId = {1}",this.Estado,this.PrestamoId));

            }catch(Exception ex)
            {
                throw ex;
            }

        }
        public void ActualizarFechaCorte()
        {

            DbPresta db = new DbPresta();

            try
            {        
                db.Ejecutar(String.Format("Update Prestamo set FechaCorte = Convert(datetime,'{0}',5) where PrestamoId = {1} and UsuarioCoId = {2}",this.FechaCorte,this.PrestamoId,this.UsuarioCoId));

            }catch(Exception ex)
            {
                throw ex;
            }

        }
       


    }
}
