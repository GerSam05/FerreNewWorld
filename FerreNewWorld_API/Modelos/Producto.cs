namespace FerreNewWorld_API.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string? Marca { get; set; }
        public string Categoria { get; set;}
        public decimal Precio { get; set;}
    }
}
