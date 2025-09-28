using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int idImagen { get; set; }
        public int idArticulo { get; set; }
        public string urlImagen { get; set; }

        /*
        public string direccionImgen()
        {
            return urlImagen;
        }*/ 
    }
}
