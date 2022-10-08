using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Huellitasco.App.Dominio;
namespace Huellitasco.App.Persistencia
{
    public interface IRepositorioVisitaPyP
    {
        IEnumerable<VisitasPyP> GetAllVisitasPyP();//listar todos los visitas
        VisitasPyP AddVisitaPyP(VisitasPyP visitaPyP); //agregar visita
        VisitasPyP UpdateVisitaPyP(VisitasPyP visitaPyP); //actualizar visita
        void DeleteVisitaPyP(int idVisitaPyP);//borrar visita
        //VisitaPyP GetVisitaPyP(int idVisitaPyP); //buscar por id

        //IEnumerable<VisitaPyP> GetVisitasPyPPorFiltro(int filtro);//buscar por filtro
    }
}