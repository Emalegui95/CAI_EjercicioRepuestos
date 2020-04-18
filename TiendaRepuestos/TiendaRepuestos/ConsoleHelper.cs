using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRepuestos
{
   public static class ConsoleHelper
    {

        public static string PedirString(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            string n = Console.ReadLine();

           
            return n;
        }

        public static int PedirInt(string msg)
        {
            Console.WriteLine("Ingrese " + msg);

          
            int c = int.Parse(Console.ReadLine());


            return c;
        }

        public static double PedirDouble(string msg)
        {
            Console.WriteLine("Ingrese " + msg);

            double c = double.Parse(Console.ReadLine());

            return c;
        }
        public static bool EsOpcionValida(string input, string opcionesValidas)
        {
           try
            {
                
                if (string.IsNullOrEmpty(input)  
                    || input.Length > 1               
                    || !opcionesValidas.ToUpper().Contains(input.ToUpper())) 
                {
                    return false;
                }

                return true;
            }
          
            catch
            {
               

                return false;
            }
        }

      
    }
}
