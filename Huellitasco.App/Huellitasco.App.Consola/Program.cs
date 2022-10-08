using System;
using Huellitasco.App.Dominio;
using Huellitasco.App.Persistencia;
using System.Collections.Generic;

namespace Huellitasco.App.Consola
{
    class Program
    {

        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        private static IRepositorioHistoria _repoHistoria =new RepositorioHistoria(new Persistencia.AppContext());
        

        static void Main(string[] args)
        {
            Console.WriteLine("Consola de Huellistasco");

            //AddDueno();
            //BuscarDueno(1);
            //AddVeterinario();
            //AddMascota();
            //AsignarDueno();
            //DeleteMascota();
            //AsignarVeterinario();
            //AddHistoria();
            AsignarHistoria();
        }

        private static void AddDueno()//agregar dueño
        {
            var dueno = new Dueno
            {
                Nombres = "Pedro",
                Apellidos = "Perez",
                Direccion = "Av juarez",
                Telefono = "123123123",
                Correo = "pedro123@gmail.com"
            };
            Console.WriteLine("dueño agregado");
            _repoDueno.AddDueno(dueno);
        }

        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Id + " " + dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
        }

        private static void AddVeterinario()//agrega veterinario
        {
            var veterinario = new Veterinario
            {
                Nombres = "Maria",
                Apellidos = "Herrera",
                Direccion = "Barrio blanco",
                Telefono = "333333",
                TarjetaPreofesional = "TP12345"
            };
            _repoVeterinario.AddVeterinario(veterinario);
            Console.WriteLine("Veterinario agregado con exito!");
        }

        private static void AddMascota()//agrega mascota
        {
            var mascota = new Mascota
            {
                Nombre = "Copito",
                Color = "blanco",
                Especie = "Perro",
                Raza = "Frespudul"
            };
            _repoMascota.AddMascota(mascota);
            Console.WriteLine("mascota agregada con exito! ");
        }

        private static void AsignarDueno()
        {
            var dueno = _repoMascota.AsignarDueno(1, 1);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos);
        }

        private static void DeleteMascota()
        {
            _repoMascota.DeleteMascota(2);
            Console.WriteLine("mascota Borrada!!!");
        }

        private static void AsignarVeterinario()
        {
            var veterinario = _repoMascota.AsignarVeterinario(1, 2);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

        private static void AddHistoria()
        {
            var historia = new Historia
            {
                FechaInicial = new DateTime(2020, 01, 01)
                
            };
            _repoHistoria.AddHistoria(historia);
            Console.WriteLine("historia creada");
        }

        private static void AsignarHistoria()
        {
            var historia = _repoMascota.AsignarHistoria(1,1);
            Console.WriteLine("historia asignada");
        }
    }

}
