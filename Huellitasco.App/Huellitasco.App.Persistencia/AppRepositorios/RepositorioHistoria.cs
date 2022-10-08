using System;
using System.Collections.Generic;
using System.Linq;
using Huellitasco.App.Dominio;
using Microsoft.EntityFrameworkCore;
namespace Huellitasco.App.Persistencia
{
    public class RepositorioHistoria:IRepositorioHistoria
    {
        /// <summary>
        /// Referencia al contexto de Historia
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioHistoria(AppContext appContext){
            _appContext = appContext;
        }

        public IEnumerable<Historia> GetAllHistorias()
        {
            return _appContext.Historia;
        }

        public Historia AddHistoria(Historia historia)
        {
            var historiaAdicionado = _appContext.Historia.Add(historia);
            _appContext.SaveChanges();
            return historiaAdicionado.Entity;
        }

        public Historia UpdateHistoria(Historia historia)
        {
            var historiaEncontrado = _appContext.Historia.FirstOrDefault(d => d.Id == historia.Id);
            if (historiaEncontrado != null)
            {
                historiaEncontrado.FechaInicial = historia.FechaInicial;
                historiaEncontrado.VisitasPyP = historia.VisitasPyP;

                _appContext.SaveChanges();
            }
            return historiaEncontrado;
        }

        public void DeleteHistoria(int idHistoria){
            var historiaEncontrado = _appContext.Historia.FirstOrDefault(d=>d.Id == idHistoria);
            if (historiaEncontrado ==null)
            {
                return;
            }
            _appContext.Historia.Remove(historiaEncontrado);
            _appContext.SaveChanges();
        }

        public Historia GetHistoria(int idHistoria)
        {
            return _appContext.Historia.Include(a => a.VisitasPyP).FirstOrDefault(d => d.Id == idHistoria);
        }

        public IEnumerable<VisitasPyP> GetVisitasHistoria(int idHistoria)
        {
            var historia = _appContext.Historia.Where (h => h.Id == idHistoria)
                                                .Include( h => h.VisitasPyP)
                                                .FirstOrDefault();

            return historia.VisitasPyP;
        }
    }
}