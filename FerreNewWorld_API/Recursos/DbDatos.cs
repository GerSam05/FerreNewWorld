using Azure;
using FerreNewWorld_API.Modelos;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using System.Reflection.Metadata;

namespace FerreNewWorld_API.Recursos
{
    public class DbDatos
    {
        public static string cadenaConexion = "Server=;DataBase=FerreNewWorld;User ID=sa;Password=;TrustServerCertificate=True;";
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

        public static dynamic Listar(string nombreProcedimiento, List<Parametro> parametros = null)
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
            APIResponse _response = new();
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

                if (nombreProcedimiento == "sp_GuardarProducto" && exito == true)
                {
                    _response.StatusCode = HttpStatusCode.Created;
                    _response.Guardado();
                    return _response;
                }
                if (nombreProcedimiento == "sp_EditarProducto" && exito == true)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Editado();
                    return _response;
                }
                if (nombreProcedimiento == "sp_EliminarProducto" && exito == true)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Eliminado();
                    return _response;
                }

                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorPetición();
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ExceptionMessages = new List<string> { ex.ToString() };
                return _response;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
