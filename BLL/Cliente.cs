using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using BLL;

namespace BLL
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int UsuarioCoId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string FechaNacimiento { get; set; }
        public string FechaRegistro { get; set; }
        public int Estado { get; set; }
        public int CantidadCliente { get; set; }

        //--------------------------DATOS DEL CLIENTE--------------------------
        public int DatosClienteId { get; set; }
        public int EstadoCivil { get; set; }
        public int Hijo { get; set; }
        public int Vivienda { get; set; }
        public int Vehiculo { get; set; }
        public string DireccionTrabajo { get; set; }
        public string TelefonoTrabajo { get; set; }
        public float Ingreso { get; set; }
        public float Remesa { get; set; }
        public List<Ubicacion> Ubicacion { get; set; }

        public Cliente()
        {
            this.ClienteId = 0;
            this.UsuarioCoId = 0;
            this.Nombre = "";
            this.Telefono = "";
            this.Cedula = "";
            this.Direccion = "";
            this.FechaNacimiento = "";
            this.FechaRegistro = "";
            this.Estado = 0;
            this.CantidadCliente = 0;

            this.DatosClienteId = 0;
            this.EstadoCivil = 0;
            this.Hijo = 0;
            this.Vivienda = 0;
            this.Vehiculo = 0;
            this.DireccionTrabajo = "";
            this.TelefonoTrabajo = "";
            this.Ingreso = 0;
            this.Remesa = 0;
            this.Ubicacion = new List<Ubicacion>();

        }

        public void AgregarUbicacion(int ClienteId, string Descripcion, float Latitude, float Longitude)
        {
            this.Ubicacion.Add(new Ubicacion(ClienteId, Descripcion, Latitude, Longitude));
        }

        public bool Insertar()
        {
            bool Retornar = false;
            int id = 0;
            object identity = null;

            try
            {


                DbPresta db = new DbPresta();

                identity = db.ObtenerValor(String.Format("Insert into Cliente(UsuarioCoId,Nombre,Telefono,Cedula,Direccion,FechaNacimiento,FechaRegistro,Estado) values({0},'{1}','{2}','{3}','{4}',Convert(datetime,'{5}',5), Convert(datetime,'{6}',5),{7}) Select @@IDENTITY",
                                                         this.UsuarioCoId, this.Nombre, this.Telefono, this.Cedula, this.Direccion, this.FechaNacimiento, this.FechaRegistro, this.Estado));

                int.TryParse(identity.ToString(), out id);
                if (id > 0)
                {
                    Retornar = db.Ejecutar(String.Format("Insert into DatosClientes(ClienteId,EstadoCivil,Hijo,Vivienda,Vehiculo,DireccionTrabajo,TelefonoTrabajo,Ingreso,Remesa) Values({0},{1},{2},{3},{4},'{5}','{6}',{7},{8})",
                                                        id, EstadoCivil, this.Hijo, this.Vivienda, this.Vehiculo, this.DireccionTrabajo, this.TelefonoTrabajo, this.Ingreso, this.Remesa));

                    if (this.Ubicacion.Count > 0)
                    {
                        foreach (Ubicacion item in this.Ubicacion)
                        {
                            db.Ejecutar(String.Format("Insert into Ubicacion(ClienteId,Descripcion,Latitude,Longitude) Values({0},'{1}',{2},{3})", id, item.Descripcion, item.Latitude, item.Longitude));
                        }
                    }

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

            DataTable dt = new DataTable();
           // int id = 0;



            try
            {
                DbPresta db = new DbPresta();

                Retornar = db.Ejecutar(string.Format("update Cliente set Nombre ='{0}', Telefono ='{1}', Cedula='{2}', Direccion='{3}', Estado ={4} where ClienteId ={5}", this.Nombre, this.Telefono, this.Cedula, this.Direccion, this.Estado, this.ClienteId));

                if (this.ClienteId > 0)
                {

                    Retornar = db.Ejecutar(String.Format("update DatosClientes set EstadoCivil ={0}, Hijo={1}, Vehiculo ={2},DireccionTrabajo='{3}', TelefonoTrabajo='{4}', Ingreso={5}, Remesa={6} where ClienteId={7}",
                                                          this.EstadoCivil, this.Hijo, this.Vehiculo, this.DireccionTrabajo, this.TelefonoTrabajo, this.Ingreso, this.Remesa, this.ClienteId));


                    if (this.Ubicacion.Count > 0)
                    {
                        
                        db.Ejecutar(String.Format("delete from Ubicacion where ClienteId ={0}", this.ClienteId));

                        foreach (Ubicacion item in this.Ubicacion)
                        {   

                            db.Ejecutar(String.Format("Insert into Ubicacion(ClienteId,Descripcion,Latitude,Longitude) Values({0},'{1}','2',{3})", ClienteId, item.Descripcion, item.Latitude, item.Longitude));
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retornar;
        }

        public bool Buscar(int id)
        {
            bool Retornar = false;

            try
            {
                DbPresta db = new DbPresta();
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();


                dt = db.ObtenerDatos(String.Format("Select * from Cliente where ClienteId = {0}", id));
                dt2 = db.ObtenerDatos(String.Format("Select * from DatosClientes where ClienteId = {0}", id));

                if (dt.Rows.Count > 0)
                {
                    this.ClienteId = Convert.ToInt32(dt.Rows[0]["ClienteId"]);
                    this.UsuarioCoId = Convert.ToInt32(dt.Rows[0]["UsuarioCoId"]);
                    this.Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                    this.Telefono = Convert.ToString(dt.Rows[0]["Telefono"]);
                    this.Cedula = Convert.ToString(dt.Rows[0]["Cedula"]);
                    this.Direccion = Convert.ToString(dt.Rows[0]["Direccion"]);
                    this.FechaNacimiento = Convert.ToString(dt.Rows[0]["FechaNacimiento"]);
                    this.FechaRegistro = Convert.ToString(dt.Rows[0]["FechaRegistro"]);
                    this.Estado = Convert.ToInt32(dt.Rows[0]["Estado"]);

                    if (dt2.Rows.Count > 0)
                    {

                        this.DatosClienteId = Convert.ToInt32(dt2.Rows[0]["DatosClienteId"]);
                        this.EstadoCivil = Convert.ToInt32(dt2.Rows[0]["EstadoCivil"]);
                        this.Hijo = Convert.ToInt32(dt2.Rows[0]["Hijo"]);
                        this.Vivienda = Convert.ToInt32(dt2.Rows[0]["Vivienda"]);
                        this.Vehiculo = Convert.ToInt32(dt2.Rows[0]["Vehiculo"]);
                        this.DireccionTrabajo = Convert.ToString(dt2.Rows[0]["DireccionTrabajo"]);
                        this.TelefonoTrabajo = Convert.ToString(dt2.Rows[0]["TelefonoTrabajo"]);
                        this.Ingreso = Convert.ToSingle(dt2.Rows[0]["Ingreso"]);
                        this.Remesa = Convert.ToSingle(dt2.Rows[0]["Remesa"]);

                    }


                    //this.Ubicacion = dt3.


                    Retornar = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }
        public bool ValidarCliente(string Cedula, string Nombre, int UsuarioId)
        {
            DbPresta db = new DbPresta();

            bool Valor = false;

            DataTable dt = new DataTable();
            dt = db.ObtenerDatos(String.Format("Select C.ClienteId as ClienteId,C.Nombre as Nombre from Cliente as C inner join UsuarioCo as Uc on Uc.UsuarioCoId = C.UsuarioCoId inner join Usuario as U on U.UsuarioId = Uc.UsuarioId"
                + " where C.Cedula ='{0}' or C.Nombre='{1}' and U.UsuarioId = " + UsuarioId, Cedula, Nombre));
            try
            {
                if (dt.Rows.Count > 0)
                {

                    Valor = true;
                    this.ClienteId = Convert.ToInt32(dt.Rows[0]["ClienteId"]);
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();

                    this.CantidadCliente = dt.Rows.Count;

                }
                else
                {
                    Valor = false;

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
