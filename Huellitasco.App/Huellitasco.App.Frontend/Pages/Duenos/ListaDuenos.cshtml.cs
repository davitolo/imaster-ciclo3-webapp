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
    public class ListaDuenosModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno;
        public IEnumerable<Dueno> listaDuenos {get;set;} 

        public ListaDuenosModel(){
            this._repoDueno = new RepositorioDueno(
                new Persistencia.AppContext());
        }
        
        public IActionResult OnGet(int? duenoId){
            if (duenoId.HasValue)
            {
                _repoDueno.DeleteDueno(duenoId.Value);
            }

            listaDuenos = _repoDueno.GetAllDuenos();
            return Page();
        }
    }
}
