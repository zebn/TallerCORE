using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TallerCORE.Models;
using TallerCORE.Services;

namespace TallerCORE.Pages
{
    public class TiendasModel : PageModel
    {

        public List<Tienda> list { get; set; }
        public string orden { get; set; }

        public void OnGet(string orden="N")
        {
            if (String.IsNullOrEmpty(this.orden))
            {
                this.orden = orden;
            }

            IQueryable<Tienda> aux = Service.getTiendas().AsQueryable();

            switch(orden)
            {
                case "N":
                    aux = aux.OrderBy(t => t.nombre);
                    break;
                case "D":
                    aux = aux.OrderBy(t => t.direccion);
                    break;
                case "E":
                    aux = aux.OrderBy(t => t.email);
                    break;
            }

            this.orden = orden;
            this.list = aux.ToList();
        }

        public JsonResult OnGetDetalle(decimal id)
        {
            Tienda? tienda = Service.getTiendas().Where(t => t.id == id).FirstOrDefault();
            return new JsonResult(tienda);
        }
    }
}
