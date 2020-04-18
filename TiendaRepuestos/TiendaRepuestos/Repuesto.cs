using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRepuestos
{
    public class Repuesto
    {

        protected int _codigo;
        protected string _nombre;
        protected double _precio;
        protected int _stock;
        /* protected Categoria _categoria;*/

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public int Stock { get => _stock; set => _stock = value; }

        // public Categoria Categoria { get => _categoria; set => _categoria = value; }

        public Repuesto(int cod, string nombre, double precio, int stock /*Categoria cate*/)
        {
            this._codigo = cod;
            this._nombre = nombre;
            this._precio = precio;
            this._stock = stock;
        //  this._categoria = cate;

        }


        public virtual string GetDescripcion()
        {
             string ficha = string.Format("Código: {0} - Producto: {1} - Precio: ${2} - Cantidad en stock: {3}", this._codigo, this._nombre, this._precio, this._stock);

            return ficha;
        }


       /*  public string ToString(string a)
        {
            return a;
        } */

        

    }
}
