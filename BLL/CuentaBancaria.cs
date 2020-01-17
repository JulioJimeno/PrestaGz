using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
   public class CuentaBancaria
    {
        public int CuentaBancariaId { get; set; }
        public int UsuarioId { get; set; }
        public string NombreTitular { get; set; }
        public string TipoCuenta { get; set; }
        public string NombreBanco { get; set; }
        public string FechaCaducidad { get; set; }
        public float CodigoSeguridad { get; set; }
        public string MarcaTarjeta { get; set; }
        public string NumeroCuenta { get; set; }
        public string  Cedula { get; set; }


        public CuentaBancaria()
        {
            this.CuentaBancariaId = 0;
            this.UsuarioId = 0;
            this.NombreTitular = "";
            this.TipoCuenta = "";
            this.NombreBanco = "";
            this.FechaCaducidad = "";
            this.CodigoSeguridad = 0;
            this.MarcaTarjeta = "";
            this.NumeroCuenta = "";
            this.Cedula = "";


        }

        public bool Insertar()
        {
            bool Resultado = false;
            DbPresta db = new DbPresta();

            try
            {

                Resultado = db.Ejecutar(String.Format("Insert into CuentaBancaria(NombreBanco,TipoCuenta,Cedula,NumeroCuenta,UsuarioId) values('{0}','{1}','{2}','{3}',{4})",this.NombreBanco,this.TipoCuenta,this.Cedula,this.NumeroCuenta,this.UsuarioId));

            } catch(Exception e)
            {
                throw e;
            }
             
            return Resultado;

        }

        public bool Actualizar()
        {
            bool Resultado = false;
            DbPresta db = new DbPresta();

            try
            {

                Resultado = db.Ejecutar(String.Format("Ubdate CuentaBancaria set NombreBanco='{0}',TipoCuenta='{1}',Cedulta='{2}',NumeroCuenta='{3}' where UsuarioId = {4}", this.NombreBanco, this.TipoCuenta, this.Cedula, this.NumeroCuenta,this.UsuarioId));

            }
            catch (Exception e)
            {
                throw e;
            }

            return Resultado;

        }

        public bool Buscar()
        {
            bool Retornar = false;
            DbPresta db = new DbPresta();
            DataTable dt = new DataTable();
            try
            {
                dt = db.ObtenerDatos(String.Format("select UsuarioId,NombreBanco,TipoCuenta,NumeroCuenta,Cedula from CuentaBancaria where UsuarioId = {0}", this.UsuarioId));

                if (dt.Rows.Count > 0)
                {

                    this.UsuarioId = Convert.ToInt32(dt.Rows[0]["UsuarioId"]);
                    this.NombreBanco = dt.Rows[0]["NombreBanco"].ToString();
                    this.TipoCuenta = dt.Rows[0]["TipoCuenta"].ToString();
                    this.NumeroCuenta = dt.Rows[0]["NumeroCuenta"].ToString();
                    this.Cedula = dt.Rows[0]["Cedula"].ToString();

          
                }
              

            }
            catch (Exception e)
            {
                throw e;
            }

            return Retornar;
        }

    }
}
