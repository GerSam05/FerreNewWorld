using FerreNewWorld_API.Modelos;
using FerreNewWorld_API.Recursos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FerreNewWorld_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public dynamic GetAll()
        {
            DataTable tProducto = DbDatos.Listar("[sp_ListarProductos]");

            string jsonProducto = JsonConvert.SerializeObject(tProducto);

            var lista = JsonConvert.DeserializeObject<List<Producto>>(jsonProducto);
            return lista;
        }

        [HttpGet("{id}")]
        public dynamic GetById(string id)
        {
            List<Parametro> parametros = new ()
            {
                new Parametro("@id", id)
            };

            DataTable producto = DbDatos.Listar("[sp_ObtenerProducto]", parametros);

            string jsonProducto = JsonConvert.SerializeObject(producto);

            var result = JsonConvert.DeserializeObject<List<Producto>>(jsonProducto);
            return result;
        }

        [HttpPost]
        public dynamic Post(Producto producto)
        {
            List<Parametro> parametros = new()
            {
                new Parametro("@codigo", producto.Codigo),
                new Parametro("@descripcion", producto.Descripcion),
                new Parametro("@marca", producto.Marca),
                new Parametro("@categoria", producto.Categoria),
                new Parametro("@Precio", producto.Precio)
            };
            dynamic result = DbDatos.Ejecutar("sp_GuardarProducto", parametros);

            return new
            {
                succes = result.exito,
                message = result.mensaje,
                result = ""
            };
        }

        [HttpPut("editar")]
        public dynamic Put(Producto producto)
        {
            List<Parametro> parametros = new()
            {
                new Parametro("@id", producto.Id),
                new Parametro("@codigo", producto.Codigo),
                new Parametro("@descripcion", producto.Descripcion),
                new Parametro("@marca", producto.Marca),
                new Parametro("@categoria", producto.Categoria),
                new Parametro("@Precio", producto.Precio)
            };
            dynamic result = DbDatos.Ejecutar("sp_EditarProducto", parametros);

            return new
            {
                succes = result.exito,
                message = result.mensaje,
                result = ""
            };
        }

        [HttpDelete("{id}")]
        public dynamic Delete(string id)
        {
            List<Parametro> parametros = new()
            {
                new Parametro("@id", id)
            };
            dynamic result = DbDatos.Ejecutar("sp_EliminarProducto", parametros);

            return new
            {
                succes = result.exito,
                message = result.mensaje,
                result = ""
            };
        }
    }
}
