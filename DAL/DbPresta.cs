using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbPresta
    {
        public SqlConnection cone;
        public SqlCommand coma;

        public DbPresta()
        {
            cone = new SqlConnection(ConfigurationManager.ConnectionStrings["DbPresta"].ConnectionString);
            coma = new SqlCommand();
        }

        public bool Ejecutar(String command)
        {
            bool Valor = false;
            try
            {
                cone.Open();
                coma.Connection = cone;
                coma.CommandText = command;
                coma.ExecuteNonQuery();
                Valor = true;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                cone.Close();
            }

            return Valor;
        }
        public DataTable ObtenerDatos(String command)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter;
            try
            {
                cone.Open();
                coma.Connection = cone;
                coma.CommandText = command;

                adapter = new SqlDataAdapter(coma);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                cone.Close();
            }
            return dt;
        }
        public Object ObtenerValor(String command)
        {
            object Valor = null;
            try
            {
                cone.Open();
                coma.Connection = cone;
                coma.CommandText = command;

                Valor = coma.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                cone.Close();
            }
            return Valor;

        }
    }
}
