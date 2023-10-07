namespace FerreNewWorld_API.Modelos
{
    public class Producto
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string? Marca { get; set; }
        public string Categoria { get; set;}
        public string Precio { get; set;}
    }
}
