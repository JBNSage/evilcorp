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
            //Instanciar un usuario para hacer el LogIn
            Usuario usuario = new Usuario();
            while (usuario.LogIn()== false)
            {
                Console.ReadKey();
            }

            //Llamar al menú principal para la escritura de las opciones
            Console.Clear();
            MenuPrincipal(lectSeleccion);     
            Console.ReadKey();

            
            //Juan Luis: Usuarios
            //Joaquin: Clientes
            //Amaury: Cuentas
            //Todos: Transacciones
        }
        

        

        public static void MenuPrincipal(byte lectSeleccion)
        {
            lectSeleccion = 0;
            do
            {
                
                Console.WriteLine("Menú del core", Color.Green);
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("1- Manejo de Usuarios");
                Console.WriteLine("2- Manejo de Clientes");
                Console.WriteLine("3- Manejo de Cuentas");
                Console.WriteLine("4- Transacciones");
                try
                {
                    lectSeleccion = Convert.ToByte(Console.ReadLine());
                    if (lectSeleccion < 1 || lectSeleccion > 4)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Introduzca una opción válida", Color.Red);
                }

            } while (lectSeleccion < 1 || lectSeleccion > 4);

            //Llamada del switch que presenta el menú de la opción seleccionada
            SwitchManejo(lectSeleccion);
        }

        public static void SwitchManejo(byte lectSeleccion)
        {
            switch (lectSeleccion)
            {
                //Cada switch representa a quien se le realizara un cambio
                case 1:
                    
                    Console.Clear();
                    EscribirOpciones("usuario");
                    break;
                case 2:

                    Console.Clear();
                    EscribirOpciones("cliente");
                    break;
                case 3:

                    Console.Clear();
                    EscribirOpciones("cuenta");
                    break;
                case 4:

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
                    //CREAR
                    switch (opcion)
                    {
                        case "usuario":

                            ConsoleKeyInfo continuar;
                            do
                            {
                                //TODO: LogIN a usuario para ver si tiene permiso de crear usuarios
                                //TODO: utilizar el metodo CrearPerfil de la clase Perfil para crearlo

                                Usuario usuario = new Usuario();
                                usuario.PedirDatos("Crear");
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

                        case "cliente":
                            //TODO: crear cliente
                            
                            do
                            {
                                Cliente cliente = new Cliente();
                                cliente.PedirDatos(opcion);
                                cliente.CrearCliente();

                                Console.Write("\n¿Desea crear otro cliente? (s/n) ");

                                if (Console.ReadLine() != "s")
                                {
                                    Console.Write("\n¿Desea volver al menú principal? (s/n) ");
                                    if (Console.ReadLine() != "s")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        MenuPrincipal(lectSeleccion);
                                    }
                                    break;
                                }

                            } while (true);
                            break;

                        case "cuenta":
                            //TODO: crear cuentas
                            break;

                        case "transacción":
                            //TODO: crear transaccion
                            break;
                    }

                    break;
                case 2:
                    //LEER
                    switch (opcion)
                    {
                        //TODO: leer klk dice el mamaguevo del usuario
                        case "usuario":

                            ConsoleKeyInfo continuar;
                            do
                            {
                                Usuario usuario = new Usuario();
                                usuario.BuscarUsuario();

                                Console.WriteLine("Buscar otro usuario: s");
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
                        //TODO: leer estado de cliente
                        case "cliente":
                            do
                            {
                                Cliente cliente = new Cliente();
                                cliente.LeerCliente();

                                Console.Write("\n¿Desea consultar otro cliente? (s/n) ");

                                if (Console.ReadLine() != "s")
                                {
                                    Console.Write("\n¿Desea volver al menú principal? (s/n) ");
                                    if (Console.ReadLine() != "s")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        MenuPrincipal(lectSeleccion);
                                    }
                                    break;
                                }
                            } while (true);
                            break;
                        //TODO: leer estado de cuenta
                        case "cuenta":
                            break;

                        //TODO: leer historial de transacciones
                        case "transacción":
                            break;
                    }

                    break;
                case 3:
                    //ACTUALIZAR
                    switch (opcion)
                    {
                        case "usuario":
                            ConsoleKeyInfo continuar;
                            do
                            {
                                Usuario usuario = new Usuario();
                                usuario.PedirDatos("Actualizar");
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
                        //TODO: actualizar cliente
                        case "cliente":
                            break;

                        //TODO: actualizar cuenta
                        case "cuenta":
                            break;
                        /* lo toy comentando por siaca
                        case "transacción":
                            break;*/
                    }
                    break;

                case 4:
                    //ELIMINAR
                    switch (opcion)
                    {
                        //TODO: eliminar usuario
                        case "usuario":
                            break;

                        //TODO: eliminar cliente
                        case "cliente":
                            break;
                        //TODO: eliminar cuenta
                        case "cuenta":
                            break;
                        /* Lo toy comentando por siaca
                        case "transacción":
                            break;*/
                    }

                    break;
                case 5:
                  //DAR ATRAS
                    Console.Clear();
                    MenuPrincipal(lectSeleccion);
                    break;

            }
        }
    }
    
}
