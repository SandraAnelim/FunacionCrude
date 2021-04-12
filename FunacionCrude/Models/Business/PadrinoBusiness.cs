using FunacionCrude.Models.Abstract;
using FunacionCrude.Models.DAL;
using FunacionCrude.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunacionCrude.Models.Business
{
    public class PadrinoBusiness : IPadrinoBusiness
    {
        private readonly DbContextFundacion _context;

        public PadrinoBusiness(DbContextFundacion context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Padrino>> ObtenerListaPadrinos()
        {
            return (await _context.Padrinos.Include("Usuario").ToListAsync());


        }

        public async Task<Padrino> ObtenerEmpleadoPorId(int id)
        {
            return (await _context.Padrinos.FirstOrDefaultAsync(m => m.PadrinoId == id));

        }
    }
}
