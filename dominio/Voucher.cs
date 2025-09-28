using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Voucher
    {
        public string CodVoucher { get; set; }

        //falta agregar clase cliente
        public int idCliente { get; set; }

        public DateTime fecha { get; set; }

        public Articulo IdArticulo { get; set; }
    }
}
