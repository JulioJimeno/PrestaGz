using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int UsuarioCoId { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string FechaCreacion { get; set; }
        public int Estado { get; set; }
        public string RNC { get; set; }

        public Usuario()
        {
            this.UsuarioId = 0;
            this.Nombre = "";
            this.Contrasena = "";
            this.Telefono = "";
            this.Correo = "";
            this.FechaCreacion = "";
            this.Estado = 0;
            this.UsuarioCoId = 0;
            this.RNC = "";
        }
        public bool Insertar(string Tabla)
        {
            bool Resultado = false;
            object Identity = null;
            int Retornar = 0;
            DbPresta db = new DbPresta();


            try
            {

                if (Tabla == "UsuarioCo")
                {
                    Identity = db.ObtenerValor(String.Format("Insert into " + Tabla + " (Nombre,Contrasena,Telefono,Correo,FechaCreacion,Estado,UsuarioId) Values('{0}','{1}','{2}','{3}',Convert(datetime,'{4}',5),{5},{6}) select @@IDENTITY", this.Nombre, this.Contrasena, this.Telefono, this.Correo, this.FechaCreacion, this.Estado, this.UsuarioId));

                    int.TryParse(Identity.ToString(), out Retornar);

                    if (Retornar > 0)
                    {
                        this.UsuarioId = Retornar;

                        Resultado = true;
                    }


                }
                else
                {
                    Identity = db.ObtenerValor(String.Format("Insert into " + Tabla + " (Nombre,Contrasena,Telefono,Correo,FechaCreacion,Estado,RNC) Values('{0}','{1}','{2}','{3}',Convert(datetime,'{4}',5),{5},'{6}') select @@IDENTITY", this.Nombre, this.Contrasena, this.Telefono, this.Correo, this.FechaCreacion, this.Estado, this.RNC));

                    int.TryParse(Identity.ToString(), out Retornar);

                    if (Retornar > 0)
                    {
                        this.UsuarioId = Retornar;
                        Resultado = true;
                    }


                }



            }
            catch (Exception e)
            {
                throw e;
            }

            return Resultado;
        }

        public bool Editar(string Tabla, string TipoUsuarioId)
        {
            bool Retornar = false;
            DbPresta db = new DbPresta();
            try
            {

                Retornar = db.Ejecutar(String.Format("Update " + Tabla + " set Nombre='{0}',FechaCreacion= Convert(datetime,'{1}',5),Contrasena='{2}',Telefono='{3}',Correo='{4}' where " + TipoUsuarioId + " = {5}", this.Nombre, this.FechaCreacion, this.Contrasena, this.Telefono, this.Correo, this.UsuarioId));

            }
            catch (Exception e)
            {
                throw e;
            }

            return Retornar;
        }

        public bool Buscar(int id, string TipoUsuario, string UsuarioId)
        {
            bool Retornar = false;
            DbPresta db = new DbPresta();
            DataTable dt = new DataTable();
            try
            {
                dt = db.ObtenerDatos(String.Format("select * from " + TipoUsuario + " where " + UsuarioId + " = "+ id));

                if (dt.Rows.Count > 0)
                {

                    this.UsuarioId = id;
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.Contrasena = dt.Rows[0]["Contrasena"].ToString();
                    this.Telefono = dt.Rows[0]["Telefono"].ToString();
                    this.Correo = dt.Rows[0]["Correo"].ToString();
                    this.FechaCreacion = dt.Rows[0]["FechaCreacion"].ToString();
                    this.Estado = Convert.ToInt32(dt.Rows[0]["Estado"]);

                    if (TipoUsuario == "Usuario")
                    {
                        this.RNC = dt.Rows[0]["RNC"].ToString();
                    }
                   

                    if (TipoUsuario == "UsuarioCo")
                    {
                        this.UsuarioCoId = id;
                        this.UsuarioId = Convert.ToInt32(dt.Rows[0]["UsuarioId"].ToString());
                    }

                    Retornar = true;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return Retornar;
        }

        public bool ValidarLog(string Correo, string Contrasena, string TipoUsuario, string UsuarioId)
        {
            DbPresta db = new DbPresta();

            bool Valor = false;

            DataTable dt = new DataTable();
            dt = db.ObtenerDatos(String.Format("Select * from " + TipoUsuario + " where Correo ='{0}' AND Contrasena='{1}' ", Correo, Contrasena));
            try
            {
                if (dt.Rows.Count > 0)
                {
                   
                    if (TipoUsuario == "UsuarioCo")
                    {
                        this.UsuarioCoId = Convert.ToInt32(dt.Rows[0][UsuarioId]);

                    }
       
                    this.UsuarioId = Convert.ToInt32(dt.Rows[0]["UsuarioId"]);

                    this.Correo = dt.Rows[0]["Correo"].ToString();
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.FechaCreacion = Utilitario.FormatoFecha(dt.Rows[0]["FechaCreacion"].ToString());
                   
                 

                }else
                {
                    Valor = false;

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            if (this.UsuarioId > 0)
            {
                Valor = true;
            }



            return Valor;
        }

        public void ValidarEstadoAdministrativo(int UsuarioId)
        {
            DbPresta db = new DbPresta();
            DataTable dt = new DataTable();

            dt = db.ObtenerDatos(String.Format("Select Estado from Usuario where UsuarioId ="+UsuarioId));
            try
            {
                if (dt.Rows.Count > 0)
                {   
                   // this.UsuarioId = Convert.ToInt32(dt.Rows[0]["UsuarioId"].ToString());                  
                    this.Estado = Convert.ToInt32(dt.Rows[0]["Estado"].ToString());

                }
              
            }
            catch (Exception e)
            {
                throw e;
            }
 
        }

        public void ActualizarEstadoSubscripcion(int UsuarioId)
        {
            DbPresta db = new DbPresta();
            DataTable dt = new DataTable();
            float AuxiliarMes = 0;


           try
            {
                ValidarEstadoAdministrativo(UsuarioId);


               if(this.Estado == 1)
                {
                    AuxiliarMes = Utilitario.ObtenerMes(DateTime.Now, Convert.ToDateTime(this.FechaCreacion));

                    if (AuxiliarMes>=1)
                    {   
                        db.Ejecutar(String.Format("update Usuario set Estado = {0} where UsuarioId = {1}",3,UsuarioId));   //3 ES EL ESTADO DE BENCIMIENTO DE LA PRUEBA GRATIS    

                        db.Ejecutar(String.Format("update UsuarioCo set Estado = {0} where UsuarioId = {1}", 3, UsuarioId));

                        this.Estado = 3;
                    }


                }
                                                                                       
      
            }catch(Exception ex)
            {
                throw ex;
            }


        }


    }
}
