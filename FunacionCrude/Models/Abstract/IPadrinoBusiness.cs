using FunacionCrude.Models.Entities;
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

        Task EliminarPadrino(Padrino padrino);

        Task<Padrino> ObtenerPadrinoPorCorreo(string correo);

        Task GuardarPadrino(Padrino padrino);

        Task EditarPadrino(Padrino padrino);

    }
}
