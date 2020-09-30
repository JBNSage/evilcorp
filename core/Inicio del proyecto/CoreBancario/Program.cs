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
            lectSeleccion = 0;
            do
            {
                
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
                    
                    Console.Clear();
                    EscribirOpciones("usuario");
                    break;
                case 2:
                    
                    Console.Clear();
                    EscribirOpciones("perfil");
                    break;
                case 3:
                    
                    Console.Clear();
                    EscribirOpciones("cliente");
                    break;
                case 4:
                   
                    Console.Clear();
                    EscribirOpciones("cuenta");
                    break;
                case 5:
                    
                    Console.Clear();
                    EscribirOpciones("transacción");
                    break;

            }
        }

        public static void EscribirOpciones(string opcion)
        {
            lectSeleccion = 0;
            do
            {
                Console.WriteLine("Menú del CRUD", Color.Green);
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine($"1- Crear {opcion}");
                Console.WriteLine($"2- Consultar {opcion}");
                Console.WriteLine($"3- Actualizar {opcion}");
                Console.WriteLine($"4- Eliminar {opcion}");
                Console.WriteLine("5- Atrás");
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
            
            
            SwitchCrud(lectSeleccion, opcion);
        }

        public static void SwitchCrud(byte lectSeleccion, string opcion)
        {
            switch (lectSeleccion)
            {
                case 1:
                    switch (opcion)
                    {
                        case "usuario":

                            ConsoleKeyInfo continuar;
                            do
                            {
                                Usuario usuario = new Usuario("Crear");
                                usuario.CrearUsuario();

                                Console.WriteLine("Registrar otro usuario: s");
                                Console.WriteLine("Salir: n");

                                do
                                {
                                    continuar = Console.ReadKey(true);
                                    if (continuar.Key == ConsoleKey.S || continuar.Key == ConsoleKey.N)
                                    {
                                        Console.WriteLine(continuar.KeyChar);
                                        break;
                                    }
                                } while (true);

                            } while (continuar.Key == ConsoleKey.S);

                            Console.Clear();
                            EscribirOpciones(opcion);

                            break;

                        case "perfil":
                            do
                            {
                                Perfil perfil = new Perfil("Crear");

                                perfil.CrearPerfil();

                                Console.WriteLine("Registrar otro perfil: s");
                                Console.WriteLine("Salir: n");

                                do
                                {
                                    continuar = Console.ReadKey(true);
                                    if (continuar.Key == ConsoleKey.S || continuar.Key == ConsoleKey.N)
                                    {
                                        Console.WriteLine(continuar.KeyChar);
                                        break;
                                    }
                                } while (true);

                            } while (continuar.Key == ConsoleKey.S);

                            Console.Clear();
                            EscribirOpciones(opcion);
                            break;

                        case "cliente":
                            break;

                        case "cuenta":
                            break;

                        case "transacción":
                            break;
                    }

                    break;
                case 2:
                    switch (opcion)
                    {
                        case "usuario":
                            break;

                        case "perfil":
                            break;

                        case "cliente":
                            break;

                        case "cuenta":
                            break;

                        case "transacción":
                            break;
                    }

                    break;
                case 3:
                    switch (opcion)
                    {
                        case "usuario":
                            ConsoleKeyInfo continuar;
                            do
                            {
                                Usuario usuario = new Usuario("Actualizar");
                                usuario.ActualizarUsuario();

                                Console.WriteLine("Actualizar otro usuario: s");
                                Console.WriteLine("Salir: n");

                                do
                                {
                                    continuar = Console.ReadKey(true);
                                    if (continuar.Key == ConsoleKey.S || continuar.Key == ConsoleKey.N)
                                    {
                                        Console.WriteLine(continuar.KeyChar);
                                        break;
                                    }
                                } while (true);

                            } while (continuar.Key == ConsoleKey.S);

                            Console.Clear();
                            EscribirOpciones(opcion);

                            break;

                        case "perfil":
                            do
                            {
                                Perfil perfil = new Perfil("Actualizar");

                                perfil.ActualizarPerfil();

                                Console.WriteLine("Actualizar otro perfil: s");
                                Console.WriteLine("Salir: n");

                                do
                                {
                                    continuar = Console.ReadKey(true);
                                    if (continuar.Key == ConsoleKey.S || continuar.Key == ConsoleKey.N)
                                    {
                                        Console.WriteLine(continuar.KeyChar);
                                        break;
                                    }
                                } while (true);

                            } while (continuar.Key == ConsoleKey.S);

                            Console.Clear();
                            EscribirOpciones(opcion);
                            break;

                        case "cliente":
                            break;

                        case "cuenta":
                            break;

                        case "transacción":
                            break;
                    }
                    break;

                case 4:
                    switch (opcion)
                    {
                        case "usuario":
                            break;

                        case "perfil":
                            break;

                        case "cliente":
                            break;

                        case "cuenta":
                            break;

                        case "transacción":
                            break;
                    }

                    break;
                case 5:
                  
                    Console.Clear();
                    MenuPrincipal(lectSeleccion);
                    break;

            }
        }
    }
    
}
