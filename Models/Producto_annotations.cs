using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TallerCORE.Models
{
    [ModelMetadataType(typeof(Producto_annotations))]
    public partial class Producto { }

    public class Producto_annotations
    {
        [Display(Description = "Código del artículo",
            Name = "Código: ",
            Prompt = "Código del producto",
            ShortName = "Cód.")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal Id { get; set; }

        [Display(Description = "Nombre del artículo",
            Name = "Nombre: ",
            Prompt = "Nombre del producto",
            ShortName = "Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Display(Description = "Descripción del artículo",
            Name = "Descripción: ",
            Prompt = "Descripción del producto",
            ShortName = "Descr.")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Descripcion { get; set; }

        [Display(Description = "Precio del artículo",
            Name = "Precio: ",
            Prompt = "Precio del producto",
            ShortName = "Precio")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, Double.MaxValue, ErrorMessage = "El valor del campo {0} debe ser mayor que {1}")]
        public decimal Precio { get; set; }

        [Display(Description = "Categoría del artículo",
            Name = "Categoría: ",
            Prompt = "Categoría del producto",
            ShortName = "Cat.")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal Categoria { get; set; }

        [Display(Description = "Categoría del artículo",
            Name = "Categoría: ",
            Prompt = "Categoría del producto",
            ShortName = "Cat.")]
        public virtual Categoria CategoriaNavigation { get; set; }
    }
}
