using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Huellitasco.App.Dominio;
using Huellitasco.App.Persistencia;

namespace Huellitasco.App.Frontend.Pages
{
    public class DetallesMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        [BindProperty] 
        public Mascota mascota{get;set;}

        public DetallesMascotasModel(){
            this._repoMascota = new RepositorioMascota(
                new Persistencia.AppContext());
        }

        public IActionResult OnGet(int mascotaId){
            mascota = _repoMascota.GetMascota(mascotaId);
            if (mascota == null)
            {
                return RedirectToPage("./NotFound.html");
            }
            else
            {
                return Page();
            }
        }
    }
}
