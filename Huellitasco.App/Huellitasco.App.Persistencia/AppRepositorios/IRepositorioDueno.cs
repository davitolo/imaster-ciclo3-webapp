using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Huellitasco.App.Dominio;
namespace Huellitasco.App.Persistencia
{
    public interface IRepositorioDueno
    {
        IEnumerable<Dueno> GetAllDuenos();//listar todos los dueños
        IEnumerable<Dueno> GetAllDuenos_();
        Dueno AddDueno(Dueno dueno); //agregar dueño
        Dueno UpdateDueno(Dueno dueno); //actualizar dueño
        void DeleteDueno(int idDueno);//borrar dueño
        Dueno GetDueno(int idDueno); //buscar por id
        IEnumerable<Dueno> GetDuenosPorFiltro(string filtro); //buscar por filtro
    }
}