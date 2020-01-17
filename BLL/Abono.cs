using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Abono
    {
        public int AbonoId { get; set; }
        public int ClienteId { get; set; }
        public int PrestamoId { get; set; }
        public int UsuarioCoId { get; set; }
        public float Cantidad { get; set; }
        public string Fecha { get; set; }
        public List<Abono> Detalle { get; set; }

        public Abono()
        {
            this.AbonoId = 0;
            this.ClienteId = 0;
            this.UsuarioCoId = 0;
            this.PrestamoId = 0;
            this.Cantidad = 0;
            this.Fecha = "";
            this.Detalle = new List<Abono>();

        }

        public Abono(float Cantidad, string Fecha)
        {
            this.Cantidad = Cantidad;
            this.Fecha = Fecha;
        }

        public void AgregarAbono(float Cantidad, string Fecha)
        {
            this.Detalle.Add(new Abono(Cantidad, Fecha));
        }

        public bool Insertar()
        {
            bool Retornar = false;

            try
            {
                DbPresta db = new DbPresta();

                foreach (Abono item in this.Detalle)
                {
                    Retornar = db.Ejecutar(String.Format("Insert into Abono(ClienteId,PrestamoId,Cantidad,Fecha,UsuarioCoId) Values({0},{1},{2},Convert(datetime,'{3}',5),{4} )", this.ClienteId, this.PrestamoId, item.Cantidad, item.Fecha,this.UsuarioCoId));
                }


            }
            catch (Exception e)
            {
                throw e;
            }

            return Retornar;
        }

        public bool Actualizar()
        {
            bool Retornar = false;

            try
            {

                DbPresta db = new DbPresta();
                db.Ejecutar(String.Format("delete from Abono where PrestamoId =" + this.PrestamoId));

                foreach (Abono item in this.Detalle)
                {   
                    Retornar = db.Ejecutar(String.Format("Insert into Abono(ClienteId,PrestamoId,Cantidad,Fecha,UsuarioCoId) Values({0},{1},{2},Convert(datetime,'{3}',5),{4} )", this.ClienteId, this.PrestamoId, item.Cantidad, item.Fecha,this.UsuarioCoId));
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
