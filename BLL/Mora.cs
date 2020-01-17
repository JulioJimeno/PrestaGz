using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Mora
    {
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public int ClienteId { get; set; }
        public float Cantidad { get; set; }
        public string Fecha { get; set; }
        public int Estado { get; set; }

        public Mora()
        {
            this.MoraId = 0;
            this.PrestamoId = 0;
            this.ClienteId = 0;
            this.Cantidad = 0;
            this.Fecha = "";
            this.Estado = 0;
        }

        public bool Actualizar(string tabla)  // TABLA PORQUE ME FUNCIONA PARA REGISTRAR LAS MORAS PAGADAS Y TAMBIEN LAS MORAS ACUMULADAS
        {
            bool Retornar = false;

            try
            {
                DbPresta db = new DbPresta();
                Retornar = db.Ejecutar(String.Format("Update " + tabla + " set Cantidad = {0},Fecha = Convert(datetime,'{1}',5) where PrestamoId = {1}", this.Cantidad,this.Fecha ,this.PrestamoId));

            }
            catch (Exception e)
            {
                throw e;
            }

            return Retornar;
        }

        public bool Insertar(string tabla)
        {
            bool Retornar = false;

            try
            {
                DbPresta db = new DbPresta();

                Retornar = db.Ejecutar(String.Format("Insert into " + tabla + "(PrestamoId,Cantidad,Fecha) Values({0},{1},Convert(datetime,'{2}',5))", this.PrestamoId,  this.Cantidad, this.Fecha));

            }
            catch (Exception e)
            {
                throw e;
            }

            return Retornar;
        }




    }
}
