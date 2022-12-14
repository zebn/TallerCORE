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
    public class BorrarModel : PageModel
    {
        private readonly TallerCORE.Models.BDTallerDAW _context;

        public BorrarModel(TallerCORE.Models.BDTallerDAW context)
        {
            _context = context;
        }

        [BindProperty]
      public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null || _context.Productos == null)
            {
                //    return NotFound();
                TempData["error"] = "Error al eliminar  un producto: dato no encontrado";
                return RedirectToPage("./Catalogo");
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                // return NotFound();
                TempData["error"] = "Error al eliminar  un producto: dato no encontrado";
                return RedirectToPage("./Catalogo");
            }
            else 
            {
                Producto = producto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null || _context.Productos == null)
            {
                // return NotFound();
                TempData["error"] = "Error al eliminar  un producto: dato no encontrado";
                return RedirectToPage("./Catalogo");
            }
            var producto = await _context.Productos.FindAsync(id);

            if (producto != null)
            {
                Producto = producto;
                _context.Productos.Remove(Producto);
                await _context.SaveChangesAsync();
                TempData["ok"] = "Producto eliminado correctamente";

            }
            else
            {
                TempData["error"] = "Error al eliminar  un producto: dato no encontrado";
                return RedirectToPage("./Catalogo");
            }

            return RedirectToPage("./Catalogo");
        }
    }
}
