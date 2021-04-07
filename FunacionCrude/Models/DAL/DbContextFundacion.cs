using FunacionCrude.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunacionCrude.Models.DAL
{
    public class DbContextFundacion: DbContext
    {
        public DbContextFundacion(DbContextOptions <DbContextFundacion> options): base (options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Padrino> Padrinos { get; set; }

    }
}
