using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRepuestos
{
   public class VentaRepuestos
    {
        protected List<Repuesto> _listaProductos;
        protected string _nombreComercio;
        protected string _direccion;

        public List<Repuesto> ListaProductos { get => _listaProductos; }
     
        public string NombreComercio { get => _nombreComercio; set => _nombreComercio = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }

        public bool TieneRepuestos { get => _listaProductos.Count > 0; } 

        public VentaRepuestos(string nombreComercio, string direccion)
        {
            this._listaProductos = new List<Repuesto>();
            this._nombreComercio = nombreComercio;
            this._direccion = direccion;

        }
        
        public void AgregarRepuesto(Repuesto repuesto) 
        {
            if (this._listaProductos.SingleOrDefault(x => x.Codigo == repuesto.Codigo) != null)
            {
                throw new Exception("El repuesto ya existe en la lista");
            }
            if (repuesto.Codigo <= 500 || repuesto.Codigo >= 1000)
            {
                throw new Exception("El código no es válido");
            }
            this._listaProductos.Add(repuesto);
        }

        public void AgregarRepuesto(int codigo, string nombre, double precio, int stock /*Categoria ca*/) 
        {
            Repuesto repuesto = new Repuesto(codigo, nombre, precio, stock /*ca*/ );

            this.AgregarRepuesto(repuesto);
        }

        public void QuitarRepuesto(int cod) 
        {
            Repuesto repuesto = this._listaProductos.SingleOrDefault(x => x.Codigo == cod); 


            if (repuesto != null)
            {
                this._listaProductos.Remove(repuesto);
            }
            else
            {
                throw new Exception("El repuesto no se encuentra registrado.");
            }
        }

        public void ModificarPrecio(int codigo, double precio)
        {

            foreach (Repuesto r in this._listaProductos)
            {
                double pivot = 0;
                if (codigo == r.Codigo)
                {
                    pivot = r.Precio;
                    r.Precio = precio;
                }

                Console.WriteLine("El precio se ha modificado de " + pivot + " a " + precio);
            }
            
        }

        public void ModificarNombre(int codigo, string nombre)
        {
            foreach (Repuesto r in this._listaProductos)
            {
                string pivot = null;

                if (codigo == r.Codigo)
                {
                    pivot = r.Nombre;
                    r.Nombre = nombre;
                }

                Console.WriteLine("El nombre se ha modificado de " + pivot + " a " + nombre);
            }
            

        }


        public void AgregarStock(int codigo, int stock)
        {
            foreach (Repuesto r in this._listaProductos)
            {
                if (codigo == r.Codigo)
                {
                    r.Stock = r.Stock + stock;
                }
            }
        }

        public void QuitarStock(int codigo, int stock)
        {
            foreach (Repuesto r in this._listaProductos)
            {
                if (codigo == r.Codigo)
                {
                    

                    r.Stock = r.Stock - stock;
                    if (r.Stock < 0)
                    {
                        throw new Exception("No es posible reducir el stock en esta cantidad"); 
                    }
                }
            }
        }

      /*  public List<Repuesto> TraerPorCategoria(int codigo)
        { }*/
    }
}
