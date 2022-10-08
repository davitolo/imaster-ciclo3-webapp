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
    public class EditarVeterinariosModel : PageModel
    {
        private readonly IRepositorioVeterinario _repoVeterinario;
        [BindProperty]
        public Veterinario veterinario{get; set;}
        public EditarVeterinariosModel(){
            this._repoVeterinario = new RepositorioVeterinario(
                new Persistencia.AppContext());
        }
        
        public IActionResult OnGet(int? veterinarioId){
            if(veterinarioId.HasValue){
                veterinario = _repoVeterinario.GetVeterinario(
                    veterinarioId.Value);
            }
            else{
                veterinario= new Veterinario();
            }
            if(veterinario==null){
                return RedirectToPage("./NotFound.html");
            }
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid){
                return Page();
            }
            if (veterinario.Id > 0){
                veterinario = _repoVeterinario.UpdateVeterinario(veterinario);
            }
            else{
                _repoVeterinario.AddVeterinario(veterinario);
            }
            return Page();
        }
    }
}
