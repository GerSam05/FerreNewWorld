using System.Net;

namespace FerreNewWorld_API.Modelos
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsExitoso { get; set; } = true;
        public string? ErrorMessage { get; set; }
        public List<string>? ExceptionMessages { get; set; }
        public Object? Resultado { get; set; }


        public Object Editado() => Resultado = new { message = "Editado" };
        public Object Eliminado() => Resultado = new { message = "Eliminado" };
        public Object Guardado() => Resultado = new { message = "Guardado" };

        public string ErrorNotFound(string id) => this.ErrorMessage = $"El Id={id} no existe en la base de datos";
        public string ErrorPetición() => this.ErrorMessage = $"Error en petición, revisar valores de los campos";

        public void ServerError()
        {
            this.ExceptionMessages = new List<string>()
            {
                $"Error interno del servidor"
            };
        }
    }
}
