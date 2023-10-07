using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;

namespace FerreNewWorld_API.Recursos
{
    public class DbDatos
    {
        public static string cadenaConexion = "Server==FerreNewWorld;User ID=sa;Password=;TrustServerCertificate=True;";
        public static DataTable Listar(string nombreProcedimiento)
        {
            SqlConnection conexion = new(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new(nombreProcedimiento, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable tabla = new();
                SqlDataAdapter da = new(cmd);
                da.Fill(tabla);

                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static DataTable Listar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new(nombreProcedimiento, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataTable tabla = new();
                SqlDataAdapter da = new(cmd);
                da.Fill(tabla);

                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static dynamic Ejecutar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new(nombreProcedimiento, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                bool exito = (i > 0) ? true : false;

                return new
                {
                    exito = true,
                    mensaje = "exito"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    exito = false,
                    message = ex.Message
                };
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
