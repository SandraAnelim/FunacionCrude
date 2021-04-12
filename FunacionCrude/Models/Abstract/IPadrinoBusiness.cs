﻿using FunacionCrude.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunacionCrude.Models.Abstract
{
    public interface IPadrinoBusiness
    {
        Task<IEnumerable<Padrino>> ObtenerListaPadrinos();
        Task<Padrino> ObtenerPadrinoPorId(int id);
        IEnumerable<Usuario> ObtenerListaUsuarios();

        Task<Padrino> ObtenerPadrinoPorCorreo(string correo);

        Task GuardarPadrino(Padrino padrino);

        Task EditarPadrino(Padrino padrino);
        Task EliminarPadrino(Padrino padrino);


    }
}
