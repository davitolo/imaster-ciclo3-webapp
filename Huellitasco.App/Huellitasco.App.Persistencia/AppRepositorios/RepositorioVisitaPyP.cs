using System;
using System.Collections.Generic;
using System.Linq;
using Huellitasco.App.Dominio;
using Microsoft.EntityFrameworkCore;
namespace Huellitasco.App.Persistencia
{
    public class RepositorioVisitaPyP:IRepositorioVisitaPyP
    {
        /// <summary>
        /// Referencia al contexto de Visita
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//}

        public RepositorioVisitaPyP(AppContext appContext){
            _appContext=appContext;
        }

        public IEnumerable<VisitasPyP> GetAllVisitasPyP(){
            return _appContext.VisitasPyP;
        }

        public VisitasPyP AddVisitaPyP(VisitasPyP visitasPyP){
            
            var visitaPyPAdicionado = _appContext.VisitasPyP.Add(visitasPyP);
            _appContext.SaveChanges();
            return visitaPyPAdicionado.Entity;
        }

        public VisitasPyP UpdateVisitaPyP(VisitasPyP visitaPyP){
            
            var visitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(d => d.Id == visitaPyP.Id);

            if (visitaPyPEncontrada != null)
            {

                visitaPyPEncontrada.FechaVisita = visitaPyP.FechaVisita;
                visitaPyPEncontrada.Temperatura = visitaPyP.Temperatura;
                visitaPyPEncontrada.Peso = visitaPyP.Peso;
                visitaPyPEncontrada.FrecuenciaRespiratoria = visitaPyP.FrecuenciaRespiratoria;
                visitaPyPEncontrada.FrecuenciaCardiaca = visitaPyP.FrecuenciaCardiaca;
                visitaPyPEncontrada.EstadoAnimo = visitaPyP.EstadoAnimo;
                visitaPyPEncontrada.IdVeterinario = visitaPyP.IdVeterinario;
                visitaPyPEncontrada.Recomendaciones = visitaPyP.Recomendaciones;
                _appContext.SaveChanges();
            }

            return visitaPyPEncontrada;
        }

        public void DeleteVisitaPyP(int idVisitaPyP){

            var visitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisitaPyP);
            if (visitaPyPEncontrada == null)
                return;
            _appContext.VisitasPyP.Remove(visitaPyPEncontrada);
            _appContext.SaveChanges();
        }
    }
}