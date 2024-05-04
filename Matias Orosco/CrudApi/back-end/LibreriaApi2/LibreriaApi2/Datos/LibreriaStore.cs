using LibreriaApi.Modelos.Dto;
using System.Collections.Generic;

namespace LibreriaApi.Datos
{
    public static class LibreriaStore
    {
        public static List<LibreriaDto> libreriaList = new List<LibreriaDto>
        {
            new LibreriaDto {Id=1, Nombre="El Principito", Paginas=25,Totales=2, Detalles="Detalles del libro El Principito",Creador="juan"},
            new LibreriaDto {Id=2, Nombre="Batman", Paginas=300, Totales=20, Detalles="Detalles del libro Batman",Creador="Martin"}
        };
    }
}