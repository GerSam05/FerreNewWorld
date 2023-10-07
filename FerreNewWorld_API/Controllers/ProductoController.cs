using FerreNewWorld_API.Modelos;
using FerreNewWorld_API.Recursos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace FerreNewWorld_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        protected APIResponse _response;

        public ProductoController()
        {
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<APIResponse> GetAll()
        {
            DataTable tProducto = DbDatos.Listar("[sp_ListarProductos]");

            string jsonProducto = JsonConvert.SerializeObject(tProducto);

            var lista = JsonConvert.DeserializeObject<List<Producto>>(jsonProducto);

            _response.StatusCode = HttpStatusCode.OK;
            _response.Resultado = lista;

            return Ok(_response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<APIResponse> GetById(string id)
        {
            List<Parametro> parametros = new ()
            {
                new Parametro("@id", id)
            };

            DataTable producto = DbDatos.Listar("[sp_ObtenerProducto]", parametros);

            if (producto == null)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsExitoso = false;
                _response.ServerError();
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

            if (producto.Rows.Count == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.ErrorNotFound(id);
                _response.IsExitoso = false;
                return NotFound(_response);
            }

            string jsonProducto = JsonConvert.SerializeObject(producto);
            var result = JsonConvert.DeserializeObject<List<Producto>>(jsonProducto);

            _response.StatusCode = HttpStatusCode.OK;
            _response.Resultado = result;
            
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<APIResponse> Post(ProductoDto productoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Parametro> parametros = new()
            {
                new Parametro("@codigo", productoDto.Codigo),
                new Parametro("@descripcion", productoDto.Descripcion),
                new Parametro("@marca", productoDto.Marca),
                new Parametro("@categoria", productoDto.Categoria),
                new Parametro("@Precio", productoDto.Precio)
            };
            dynamic result = DbDatos.Ejecutar("sp_GuardarProducto", parametros);

            return result;
        }

        [HttpPut("editar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<APIResponse> Put(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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

            return result;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<APIResponse> Delete(string id)
        {
            List<Parametro> parametros = new()
            {
                new Parametro("@id", id)
            };
            dynamic result = DbDatos.Ejecutar("sp_EliminarProducto", parametros);

            return result;
        }
    }
}
