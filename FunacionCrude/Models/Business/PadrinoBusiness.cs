using FunacionCrude.Models.Abstract;
using FunacionCrude.Models.DAL;
using FunacionCrude.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return (await _context.Padrinos.ToListAsync());


        }

        public async Task<Padrino> ObtenerPadrinoPorId(int id)
        {
            return (await _context.Padrinos.FirstOrDefaultAsync(m => m.PadrinoId == id));

        }
        public async Task<Padrino> ObtenerPadrinoPorCorreo(string correo)
        {
            return (await _context.Padrinos.AsNoTracking().FirstOrDefaultAsync(m => m.Correo == correo));

        }
          
                      

         public async Task GuardarPadrino(Padrino padrino)
         {
            try
            {
                _context.Add(padrino);
                await _context.SaveChangesAsync();
            

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task EditarPadrino(Padrino padrino)
        {
            try
            {
                _context.Update(padrino);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async Task EliminarPadrino(Padrino padrino)
        {
            try
            {
                _context.Remove(padrino);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }

        }

    }
}
