using FunacionCrude.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunacionCrude.Models.Abstract
{
    public interface IUsuarioBusiness
    {
        Task<IEnumerable<Usuario>> ObtenerListaDeUsuarios();
        Task<Usuario> ObtenerUsuarioPorId(int id);
        


        Task<Usuario> ObtenerUsuarioPorCorreo(string correo);

        Task GuardarUsuario(Usuario usuario);

        Task EditarUsuario(Usuario usuario);
        Task EliminarUsuario(Usuario usuario);

    }
}
