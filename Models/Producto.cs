using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TallerCORE.Models
{
    public partial class Producto
    {
        
        public decimal Id { get; set; }

        
        public string Nombre { get; set; }

        
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        
        public decimal Categoria { get; set; }

        
        public virtual Categoria CategoriaNavigation { get; set; }
    }
}
