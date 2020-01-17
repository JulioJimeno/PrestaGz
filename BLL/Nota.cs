using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Nota
    {
        public int NotaId { get; set; }
        public int PrestamoId { get; set; }
        public int ClienteId { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public List<Nota> Detalle { get; set; }

        public Nota()
        {
            this.NotaId = 0;
            this.PrestamoId = 0;
            this.ClienteId = 0;
            this.Descripcion = "";
            this.Fecha = "";
            this.Detalle = new List<BLL.Nota>();
        }

        public Nota(int PrestamoId, int ClienteId, string Descripcion, string Fecha)
        {
            this.PrestamoId = PrestamoId;
            this.ClienteId = ClienteId;
            this.Descripcion = Descripcion;
            this.Fecha = Fecha;
        }

        public void AgregarNota(int PrestamoId, int ClienteId, string Descripcion, string Fecha)
        {
            this.Detalle.Add(new Nota(PrestamoId, ClienteId, Descripcion, Fecha));
        }


        public bool Insertar()
        {
            bool Retornar = false;

            try
            {
                DbPresta db = new DbPresta();
                foreach (Nota item in this.Detalle)
                {

                    Retornar = db.Ejecutar(String.Format("Insert into Nota(PrestamoId,ClienteId,Descripcion,Fecha) values({0},{1},'{2}',Convert(datetime,'{3}',5))",
                                           item.PrestamoId,item.ClienteId,item.Descripcion,item.Fecha));
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
