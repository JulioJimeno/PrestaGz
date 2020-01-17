using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Ubicacion
    {
        public int UbicacionId { get; set; }
        public int ClienteId { get; set; }
        public string Descripcion { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public Ubicacion(int ClienteId, string Descripcion, float Latitude, float Longitude)
        {  
            this.ClienteId = ClienteId;
            this.Descripcion = Descripcion;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }
}
