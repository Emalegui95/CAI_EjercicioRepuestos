using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRepuestos
{
   public class Categoria
    {

        protected int _codigo;
        protected string _nombre;

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }


    }
}
