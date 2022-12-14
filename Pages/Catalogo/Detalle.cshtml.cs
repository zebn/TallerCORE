using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TallerCORE.Models;

namespace TallerCORE.Pages.Catalogo
{
    public class DetalleModel : PageModel
    {
        private readonly TallerCORE.Models.BDTallerDAW _context;

        public DetalleModel(TallerCORE.Models.BDTallerDAW context)
        {
            _context = context;
        }

        public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null || _context.Productos == null)
            {
                //return NotFound();
                Producto = null;
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                //return NotFound();
                Producto = null;
            }
            else 
            {
                Producto = producto;
            }
            return Page();
        }
    }
}
