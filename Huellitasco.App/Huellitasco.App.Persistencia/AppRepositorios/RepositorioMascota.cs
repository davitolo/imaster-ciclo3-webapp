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
            //return GetAllMascotas_();
            return _appContext.Mascota.Include("Dueno").Include("Veterinario").Include("Historia");
        }

        public IEnumerable<Mascota> GetAllMascotas_()
        {
            return _appContext.Mascota;
        }

        public Mascota AddMascota(Mascota mascota){
            var mascotaAdicionado = _appContext.Mascota.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionado.Entity;
        }
        
        public Mascota UpdateMascota(Mascota mascota){
            var mascotaEncontrado = _appContext.Mascota.FirstOrDefault( d => d.Id == mascota.Id);
            if(mascotaEncontrado != null)
            {
                mascotaEncontrado.Nombre=mascota.Nombre;
                mascotaEncontrado.Color=mascota.Color;
                mascotaEncontrado.Especie=mascota.Especie;
                mascotaEncontrado.Raza=mascota.Raza;
                mascotaEncontrado.Dueno=mascota.Dueno;
                mascotaEncontrado.Veterinario=mascota.Veterinario;
                //mascotaEncontrado.Historia=mascota.Historia;
                _appContext.SaveChanges();
            }
            return mascotaEncontrado;
        }

        public void DeleteMascota(int idMascota){
            var mascotaEncontrado = _appContext.Mascota.FirstOrDefault(d => d.Id == idMascota);
            if (mascotaEncontrado == null)
                return;
            _appContext.Mascota.Remove(mascotaEncontrado);
            _appContext.SaveChanges();
        }

        public Mascota GetMascota(int idMascota){
            //return _appContext.Mascota.FirstOrDefault(d => d.Id == idMascota);
            return _appContext.Mascota.Include("Dueno").Include("Veterinario").Include("Historia").FirstOrDefault(d => d.Id == idMascota);
        }

        public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro){
            var mascotas = GetAllMascotas();
            if(mascotas !=null)
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascotas = mascotas.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return mascotas;
        }

        public Veterinario AsignarVeterinario(int idMascota, int idVeterinario){
            var mascotaEncontrado = _appContext.Mascota.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrado != null)
            {
                var veterinarioEncontrado = _appContext.Veterinario.FirstOrDefault(v => v.Id == idVeterinario);
                if (veterinarioEncontrado != null)
                {
                    mascotaEncontrado.Veterinario = veterinarioEncontrado;
                    _appContext.SaveChanges();
                }
                return veterinarioEncontrado;
            }
            return null;
        }

        public Dueno AsignarDueno(int idMascota, int idDueno){
            var mascotaEncontrado = _appContext.Mascota.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrado != null)
            {
                var duenoEncontrado = _appContext.Dueno.FirstOrDefault(v => v.Id == idDueno);
                if (duenoEncontrado != null)
                {
                    mascotaEncontrado.Dueno = duenoEncontrado;
                    _appContext.SaveChanges();
                }
                return duenoEncontrado;
            }
            return null;
        }

        public Historia AsignarHistoria(int idMascota, int idHistoria){
            var mascotaEncontrado = _appContext.Mascota.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrado != null)
            {
                var historiaEncontrado = _appContext.Historia.FirstOrDefault(v => v.Id == idHistoria);
                if (historiaEncontrado != null)
                {
                    mascotaEncontrado.Historia = historiaEncontrado;
                    _appContext.SaveChanges();
                }
                return historiaEncontrado;
            }
            return null;
        }
    }
}