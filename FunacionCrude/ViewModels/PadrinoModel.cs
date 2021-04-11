using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FunacionCrude.ViewModels
{
    public class PadrinoModel
    {
        public int PadrinoId { get; set; }

        public string Nombre { get; set; }

      
        public string Correo { get; set; }

        
        public string Contraseña { get; set; }

        public int Edad { get; set; }

        public string Profesion { get; set; }
                  
        public int Usuario { get; set; }
        public string Descripcion { get; set; }
    }
}
