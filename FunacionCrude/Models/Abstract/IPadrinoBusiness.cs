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
        Task<Padrino> ObtenerEmpleadoPorId(int id);
    }
}
