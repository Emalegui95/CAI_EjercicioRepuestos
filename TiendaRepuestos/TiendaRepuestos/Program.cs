using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRepuestos
{

    static 
    class Program
    {
        static void Main(string[] args)
        {

            bool continuarActivo = true;

            string menu = "1) Agregar Repuesto \n2) Quitar Repuesto \n3) Modificar Precio " +
                "\n4) Agregar Stock \n5) Quitar Stock \n6) Mostrar según Categoría \n7) Mostrar Listado \n8) Modificar nombre de repuesto \nX) Salir";

      
            VentaRepuestos negocio = new VentaRepuestos ("Mi tienda", "Av. Santa Fe 3000, Ciudad de Buenos Aires"); 

         
            

            do 
            {
                Console.WriteLine("Bienvenido a " + negocio.NombreComercio + " ubicado en " + negocio.Direccion);
                Console.WriteLine(menu); 

                try
                {
                    
                    string opcionSeleccionada = Console.ReadLine(); 

               
                    if (ConsoleHelper.EsOpcionValida(opcionSeleccionada, "12345678X"))
                    {
                        if (opcionSeleccionada.ToUpper() == "X")
                        {
                            continuarActivo = false;
                            continue;
                        }

                        switch (opcionSeleccionada)
                        {
                            case "1":
                                
                                Program.AgregarRepuesto(negocio);
                                break;
                            case "2":
                                
                                Program.QuitarRepuesto(negocio);

                                break;
                            case "3":
                                
                                Program.ModificarPrecio(negocio);

                                break;
                            case "4":
                               
                                Program.AgregarStock(negocio);
                                break;
                            case "5":
                                // borrar
                                Program.QuitarStock(negocio);
                                break;
                          /*  case "6":
                                Program.TraerPorCategoria(negocio);
                                break; */
                            case "7":
                                Program.ListarProductos(negocio);
                                break;
                            case "8":
                                Program.ModificarNombre(negocio);
                                break;

                            default:
                                Console.WriteLine("Opción inválida.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error durante la ejecución del comando. Por favor intente nuevamente. Mensaje: " + ex.Message);
                }
                Console.WriteLine("Presione una tecla para continuar.");

                Console.ReadKey();
                Console.Clear();
            }
            while (continuarActivo);

            Console.WriteLine("Gracias por usar la app.");
            Console.ReadKey();
        }


        public static void AgregarRepuesto(VentaRepuestos venta) 
        {
            try
            {
                string n = ConsoleHelper.PedirString("producto");
                int c = ConsoleHelper.PedirInt("código (A partir del 501)");
                int s = ConsoleHelper.PedirInt("stock");
                double p = ConsoleHelper.PedirDouble("precio");

         
                venta.AgregarRepuesto(c, n, p, s);
                Console.WriteLine("Artículo agregado.");

            }
           catch (Exception ex)
            {
                // podemos usar recursión para que no salga del método hasta que no lo haga bien.
                Console.WriteLine("Error en uno de los datos ingresados. " + ex.Message + ". Intente nuevamente. \n\n");

                // podemos preguntarle si quiere hacerlo de nuevo. Depende de nuestro negocio.
                // if(quiereIntentarNuevamente)
                AgregarRepuesto(venta);
            }
        }


        public static void QuitarRepuesto(VentaRepuestos venta) //ok
        {

            if (venta.TieneRepuestos)
            {

                ListarProductos(venta);
          
                Console.WriteLine("Seleccione el repuesto a eliminar: ");
                try
                {
                    int c = ConsoleHelper.PedirInt("Codigo");

                    venta.QuitarRepuesto(c);

                    Console.WriteLine("El repuesto ha sido eliminado.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No es posible eliminar el repuesto solicitado. " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Por el momento no hay repuestos para eliminar");
            }
            }
    

        public static void ModificarPrecio(VentaRepuestos venta)
        {

        try
        {
            int c = ConsoleHelper.PedirInt("Codigo");
            double pr = ConsoleHelper.PedirDouble("Precio");

            venta.ModificarPrecio(c, pr);

           
        }
        catch (Exception ex)
        {
            Console.WriteLine("No es posible cambiar el precio al repuesto solicitado. " + ex.Message);
        }
        }

        public static void ModificarNombre(VentaRepuestos venta)
        {
            try
            {
                int c = ConsoleHelper.PedirInt("código");
                string n = ConsoleHelper.PedirString("nombre");

                venta.ModificarNombre(c, n);
            }
            catch (FormatException)
            {
                Console.WriteLine("NO ha Ingresado un formato correcto");
            }
        }
        public static void AgregarStock(VentaRepuestos venta)
        {
            try
            {
                int c = ConsoleHelper.PedirInt("Codigo");
                int s = ConsoleHelper.PedirInt("Cantidad de unidades a agregar");

                venta.AgregarStock(c, s);
            }
            catch (Exception ex)
            {

                Console.WriteLine("No es posible cambiar las unidades del repuesto solicitado. " + ex.Message);
            }

        }

        public static void QuitarStock(VentaRepuestos venta)
        {

          
            try
            {
                int c = ConsoleHelper.PedirInt("Codigo");
                int s = ConsoleHelper.PedirInt("Cantidad unidades a quitar");

                venta.QuitarStock(c, s);
            }
            catch (FormatException)
            {

                Console.WriteLine("Ingrese solo números");
            }
        }

        public static void ListarProductos(VentaRepuestos venta)
        {
            if (venta.TieneRepuestos)
            {
                foreach (Repuesto a in venta.ListaProductos)
                {
                    MostrarDescripcion(a);
                }
            }
            else
            {
                Console.WriteLine("Aún no hay listados repuestos.");
            }
        }

        private static void MostrarDescripcion(Repuesto repuesto)
        {
            Console.WriteLine(repuesto.GetDescripcion());
        }

    }
}
