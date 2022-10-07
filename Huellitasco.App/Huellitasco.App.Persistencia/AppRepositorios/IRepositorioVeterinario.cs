using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Huellitasco.App.Dominio;
namespace Huellitasco.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();//listar todos los veterinarios
        Veterinario AddVeterinario(Veterinario veterinario); //agregar veterinario
        void DeleteVeterinario(int iDVeterinario); //borrar veterinario
        Veterinario UpdateVeterinario(Veterinario veterinario); //actualizar veterinario
        Veterinario GetVeterinario(int iDVeterinario); //buscar veterinario por id
        IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro);
    }
}