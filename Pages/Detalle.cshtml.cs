using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TallerCORE.Models;
using TallerCORE.Services;

namespace TallerCORE.Pages
{
    public class DetalleModel : PageModel
    {
        public Tienda? tienda { get; set; }

        public void OnGet(decimal id)
        {
            this.tienda = Service.getTiendas().Where(t => t.id == id).FirstOrDefault();
        }
    }
}
