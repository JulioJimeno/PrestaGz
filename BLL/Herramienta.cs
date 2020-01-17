using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class Herramienta
    {

        public int HerramientaId { get; set; }
        public int UsuarioId { get; set; }
        public int Valor { get; set; }
        public float Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }

        public Herramienta()
        {
            this.HerramientaId = 0;
            this.UsuarioId = 0;
            this.Cantidad = 0;
            this.Descripcion = "";
            this.Fecha = "";
            this.Valor = 0;
        }

        public bool ActualizarFecha()
        {
            bool Resultado = false;
            DbPresta db = new DbPresta();
            try
            {                                   //SE ACTUALIZARA PORQUE EL ADMINISTRADOR TIENE QUE ACTUALIZAR LA FECHA
                Resultado = db.Ejecutar(String.Format(" Update Herramienta set Fecha = Convert(datetime,'{0}',5) where Valor = 4 and UsuarioId = {1}", this.Fecha, this.UsuarioId));

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return Resultado;
        }
        public bool Actualizar(string DbDato, string Valor, string ValorCondicion)
        {
            bool Resultado = false;
            DbPresta db = new DbPresta();
            try
            {                                   //SE ACTUALIZARA PORQUE EL ADMINISTRADOR TIENE QUE ACTUALIZAR LA FECHA
                Resultado = db.Ejecutar(String.Format(" update Herramienta set " + DbDato + " where Valor ={1} and UsuarioId = {2} ", Valor, ValorCondicion, this.UsuarioId));

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return Resultado;


        }

        public bool Insertar()
        {

            bool Resultado = false;

            try
            {
                DbPresta db = new DbPresta();

                Resultado = db.Ejecutar(String.Format("Insert Herramienta(UsuarioId,Valor,Cantidad,Descripcion,Fecha) Values({0},{1},{2},'{3}',Convert(datetime,'{4}',5))", this.UsuarioId, this.Valor, this.Cantidad, this.Descripcion, this.Fecha));


            }
            catch (Exception e)
            {
                throw e;
            }

            return Resultado;
        }

        public bool Buscar(int UsuarioId)
        {
            bool Resultado = false;
            DataTable dt = new DataTable();

            try
            {
                DbPresta db = new DbPresta();

                dt = db.ObtenerDatos(String.Format("Select * from Herramienta where UsuarioId =" + UsuarioId));
               

                if (dt.Rows.Count > 0)
                {

                    this.UsuarioId = Convert.ToInt32(dt.Rows[0]["UsuarioId"].ToString());
                    Resultado = true;
            

                }


            }
            catch (Exception e)
            {
                throw e;
            }


            return Resultado;

        }


    }
}
