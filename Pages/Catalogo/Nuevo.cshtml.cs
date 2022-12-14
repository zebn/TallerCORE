using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TallerCORE.Models;

namespace TallerCORE.Pages.Catalogo
{
    public class NuevoModel : PageModel
    {
        private readonly TallerCORE.Models.BDTallerDAW _context;

        public NuevoModel(TallerCORE.Models.BDTallerDAW context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            ViewData["Categoria"] = getLista();




   //     ViewData["Categoria"] = new SelectList(_context.Categorias, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public Producto Producto { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                ViewData["Categoria"] = getLista();

                return Page();
            }

            _context.Productos.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Catalogo");
        }

        private List<SelectListItem> getLista()
        {



            var listCats = (from c in _context.Categorias
                            select new SelectListItem { Text = c.Nombre, Value = c.Id.ToString() })
              .ToList<SelectListItem>();
            listCats.Insert(0, new SelectListItem { Text = "sel cat", Value = "" });
            ViewData["Categoria"] = listCats;

            return listCats;

        }



    }
}
