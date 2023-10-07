using System.ComponentModel.DataAnnotations;

namespace FerreNewWorld_API.Modelos
{
    public class ProductoDto
    {
        [Required(ErrorMessage = "Campo Codigo es requerido")]
        [MaxLength(30, ErrorMessage = "El Campo Código no debe exceder los 50 Caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "El Campo Código sólo admite letras y números")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo Descripción es requerido")]
        [MaxLength(30, ErrorMessage = "El Campo Descipcion no debe exceder los 50 Caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "El Campo Descripción sólo admite letras y números")]
        public string Descripcion { get; set; }


        [MaxLength(30, ErrorMessage = "El Campo Marca no debe exceder los 50 Caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "El Campo Marca sólo admite letras y números")]
        public string? Marca { get; set; }


        [Required(ErrorMessage = "Campo Categoria es requerido")]
        [MaxLength(30, ErrorMessage = "El Campo Categoría no debe exceder los 50 Caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "El Campo Categoría sólo admite letras y números")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Campo Precio es requerido")]
        [MaxLength(7, ErrorMessage = "Campo Precio no debe ser inferior a 0$ ni superior a 9999999$")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El Campo Precio sólo admite números")]
        public string Precio { get; set; }
    }
}
