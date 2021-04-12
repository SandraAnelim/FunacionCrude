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
    public class UsuarioBusiness: IUsuarioBusiness
    {
       
            private readonly DbContextFundacion _context;

            public UsuarioBusiness(DbContextFundacion context)
            {
                _context = context;
            }
        
        public async Task<IEnumerable<Usuario>> ObtenerListaDeUsuarios()
            {
                return (await _context.Usuarios.ToListAsync());


            }

            public async Task<Usuario> ObtenerUsuarioPorId(int id)
            {
            //return (await _context.Usuarios.FirstOrDefaultAsync(m => m.UsuarioId == id));
            return (await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == id));

            }
            public async Task<Usuario> ObtenerUsuarioPorCorreo(string correo)
            {
                return (await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Correo == correo));

            }







           

            public async Task GuardarUsuario(Usuario usuario)
            {
                try
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();


                }
                catch (Exception e)
                {

                    throw e;
                }

            }

            public async Task EditarUsuario(Usuario usuario)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {

                    throw e;
                }

            }
            public async Task EliminarUsuario(Usuario usuario)
            {
                try
                {
                    _context.Remove(usuario);
                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        
    }
}
