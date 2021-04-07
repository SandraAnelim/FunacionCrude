﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunacionCrude.Models.Entities
{
    public class Padrino
    {
        public int PadrinoId { get; set; }

        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se requiere  correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Se requiere  contraseña")]
        public string Contraseña { get; set; }

        public int Edad { get; set; }

        public string Profesion { get; set; }

        [Required(ErrorMessage = "Se requiere  UsuarioId")]
        public int UsuarioId { get; set; }

        public string Descripcion { get; set; }




    }
}