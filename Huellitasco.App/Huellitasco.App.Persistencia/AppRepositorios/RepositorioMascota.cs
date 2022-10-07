using System;
using System.Collections.Generic;
using System.Linq;
using Huellitasco.App.Dominio;
using Microsoft.EntityFrameworkCore;
namespace Huellitasco.App.Persistencia
{
    public class RepositorioMascota:IRepositorioMascota
    {
        /// <summary>
        /// Referencia al contexto de Mascota
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Mascota> GetAllMascotas()
        {
            return GetAllMascotas_();
            //return _appContext.Mascota.Include("Dueno").Include("Veterinario").Include("Historia");
        }

        public IEnumerable<Mascota> GetAllMascotas_()
        {
            return _appContext.Mascota;
        }

        
        
    }
}