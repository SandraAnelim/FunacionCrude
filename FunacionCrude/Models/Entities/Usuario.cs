using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunacionCrude.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Correo { get; set; }

        [Required (ErrorMessage = "Se requiere Rol")]
        public int RolId { get; set; }

        public string Estado { get; set; }


    }
}
