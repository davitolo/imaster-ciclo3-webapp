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
    public class ListaVeterinariosModel : PageModel
    {
        
        private readonly IRepositorioVeterinario _repoVeterinario;

        public IEnumerable<Veterinario> listaVeterinarios {get;set;} 
        
        public ListaVeterinariosModel()
        {
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? veterinarioId)
        {
            if(veterinarioId.HasValue){
                _repoVeterinario.DeleteVeterinario(veterinarioId.Value);
            }
            listaVeterinarios=_repoVeterinario.GetAllVeterinarios();
            return Page();
        }
    }
}
