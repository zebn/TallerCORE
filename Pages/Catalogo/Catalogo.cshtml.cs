using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerCORE.Models;

namespace TallerCORE.Pages.Catalogo
{
    public class CatalogoModel : PageModel
    {
        private readonly TallerCORE.Models.BDTallerDAW _context;

        



        public CatalogoModel(TallerCORE.Models.BDTallerDAW context)
        {
            _context = context;
            orden = "N";
            dir = "ASC";
            cat = "";
        }

        public IList<SelectListItem> Categorias { get; set; }

        public IList<Producto> Producto { get;set; }

        public string orden { get; set; }

        public string dir { get; set; }

        public string cat { get; set; }


        public async Task OnGetAsync(string o = "N", string d="ACS", string c="")
        {


            IQueryable<Producto> list = null;
            if (String.IsNullOrEmpty(c))
            {
                list = from p in _context.Productos select p;
            }
            else
            {
                try
                {
                    decimal idCat = Convert.ToDecimal(c);
                    list = from p in _context.Productos where p.Categoria == idCat select p;
                }
                catch
                {
                    list = from p in _context.Productos select p;
                }

                cat = c;

            }
            Expression<Func<Producto, object>> expression = (x => x.Nombre);
            switch (o)
            {

                case "N":
                    expression = (x => x.Nombre);
                    break;
                case "P":
                    expression = (x => x.Precio);
                    break;
                case "C":
                    expression = (x => x.CategoriaNavigation.Nombre);
                    break;

            }

            if (d == "ASC")

            {
                list = list.OrderBy(expression);
            }
            else
            {
                list = list.OrderByDescending(expression);


            }

            dir = (d == "ASC" ? "DESC" : "ASC");

            Producto = await list.AsNoTracking().Include(p => p.CategoriaNavigation).ToListAsync();

            var cats = await _context.Categorias.OrderBy(c => c.Nombre).ToListAsync();

            Categorias = new List<SelectListItem>();

            Categorias.Add(new SelectListItem { Text = "Todas", Value = "" });
            foreach (Categoria aux in cats)
            {
                Categorias.Add(new SelectListItem { Text = aux.Nombre, Value = aux.Id.ToString() });
            }
        }
    }
}
