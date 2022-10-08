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
    public class ListaMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        
        public IEnumerable<Mascota> listaMascotas {get;set;} 

        public ListaMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(
                new Persistencia.AppContext());
        }
        
        public IActionResult OnGet(int? mascotaId)
        {
            if (mascotaId.HasValue)
            {
                _repoMascota.DeleteMascota(mascotaId.Value);
            }
            listaMascotas = _repoMascota.GetAllMascotas();
            return Page();
        }
    }
}
