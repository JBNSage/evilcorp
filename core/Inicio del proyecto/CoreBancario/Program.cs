using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace CoreBancario
{
    class Program
    {
        static byte lectSeleccion = 0;
        static void Main(string[] args)
        {
            
            //llamar al menú principal para la escritura de las opciones
            MenuPrincipal(lectSeleccion);

            
            Console.ReadKey();
        }

        

        public static void MenuPrincipal(byte lectSeleccion)
        {
            do
            {
                //Console.Clear();
                Console.WriteLine("Menú del core", Color.Green);
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("1- Manejo de usuarios");
                Console.WriteLine("2- Manejo de Perfiles");
                Console.WriteLine("3- Manejo de clientes");
                Console.WriteLine("4- Manejo de Cuentas");
                Console.WriteLine("5- Transacciones");
                try
                {
                    lectSeleccion = Convert.ToByte(Console.ReadLine());
                    if (lectSeleccion < 1 || lectSeleccion > 5)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Introduzca una opción válida", Color.Red);
                }

            } while (lectSeleccion < 1 || lectSeleccion > 5);

            //llamada del switch que presenta el menú de la opción seleccionada
            SwitchManejo(lectSeleccion);
        }

        public static void SwitchManejo(byte lectSeleccion)
        {
            switch (lectSeleccion)
            {
                case 1:
                    EscribirOpciones("usuario");
                    break;
                case 2:
                    EscribirOpciones("perfil");
                    break;
                case 3:
                    EscribirOpciones("cliente");
                    break;
                case 4:
                    EscribirOpciones("cuenta");
                    break;
                case 5:
                    EscribirOpciones("transacción");
                    break;

            }
        }

        public static void EscribirOpciones(string opcion)
        {
            Console.Clear();
            Console.WriteLine("Menú del CRUD", Color.Green);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"1- Crear {opcion}");
            Console.WriteLine($"2- Consultar {opcion}");
            Console.WriteLine($"3- Actualizar {opcion}");
            Console.WriteLine($"4- Eliminar {opcion}");
            Console.WriteLine("5- Atrás");
            lectSeleccion = Convert.ToByte(Console.ReadLine());
            SwitchCrud(lectSeleccion);
        }

        public static void SwitchCrud(byte lectSeleccion)
        {
            switch (lectSeleccion)
            {
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
                case 5:
                    Console.Clear();
                    MenuPrincipal(lectSeleccion);
                    break;

            }
        }
    }
    
}
