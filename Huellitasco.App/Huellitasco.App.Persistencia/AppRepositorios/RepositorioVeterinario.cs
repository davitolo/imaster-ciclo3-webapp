using System;
using System.Collections.Generic;
using System.Linq;
using Huellitasco.App.Dominio;
using Microsoft.EntityFrameworkCore;
namespace Huellitasco.App.Persistencia
{
    public class RepositorioVeterinario:IRepositorioVeterinario
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return GetAllVeterinarios_();
        }

        public IEnumerable<Veterinario> GetAllVeterinarios_()
        {
            return _appContext.Veterinario;
        }

        public Veterinario AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.Veterinario.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

        public void DeleteVeterinario(int iDVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinario.FirstOrDefault(d=>d.Id==iDVeterinario);
            if (veterinarioEncontrado==null)
                return;
            _appContext.Veterinario.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        public Veterinario UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinario.FirstOrDefault( d => d.Id == veterinario.Id);
            if(veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombres=veterinario.Nombres;
                veterinarioEncontrado.Apellidos=veterinario.Apellidos;
                veterinarioEncontrado.Direccion=veterinario.Direccion;
                veterinarioEncontrado.Telefono=veterinario.Telefono;
                veterinarioEncontrado.TarjetaPreofesional=veterinario.TarjetaPreofesional;

                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }

        public Veterinario GetVeterinario(int iDVeterinario)
        {
            return _appContext.Veterinario.FirstOrDefault(d => d.Id == iDVeterinario);
        }

        public IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro)
        {
            var veterinarios = GetAllVeterinarios();
            if(veterinarios != null)
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    veterinarios = veterinarios.Where(s => s.Nombres.Contains(filtro));     
                }
                
            }
            return veterinarios;
        }

    }
}