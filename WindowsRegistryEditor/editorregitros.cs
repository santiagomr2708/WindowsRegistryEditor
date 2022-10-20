using System;
using Microsoft.Win32;

namespace WindowsRegistryEditor
{
    class WindowsRegistry
    {
        static void Main()
        {
            int opc = Menu();
            if (opc == 1)
            {
                Console.WriteLine("Ingrese la ruta del registro a leer. ");
                string source = Console.ReadLine();
                Console.WriteLine("Ingresa la llave del registro a leer");
                string key = Console.ReadLine();
                Console.WriteLine($"El valor que se encontro en la ruta{source}: es: {ReadRegistryValue(source, key)}");
            }
            else if (opc == 2)
            {
                Console.WriteLine("Ingrese la ruta del registro a leer. Nota:debes de agregarle un '\' al final");
                string source = Console.ReadLine();
                Console.WriteLine("Ingrese la llave del registro a editar");
                string keyname = Console.ReadLine();
                Console.WriteLine($"Ingrese el valor de la llave: {keyname}");
                string Value = Console.ReadLine();
                SetRegistryKeyValue(source, keyname, Value);
            }
            Console.WriteLine();
        }

        private static void SetRegistryKeyValue(string source, string keyname, string Value)
        {
            Registry.SetValue(source, keyname, Value);
        }
        private static string ReadRegistryValue(string source, string key)
        {
            return Registry.GetValue(source, key, "No found").ToString();
        }

        static int Menu()
        {
            Console.WriteLine("Bienvenido al editor de registro del sistema.\n\n");
            Console.WriteLine("Seleccione una opcion:\n");
            Console.WriteLine("\t1.-Leer un valor en el Registro del sistema");
            Console.WriteLine("\t2.-Editar una llave en el Registro del sistema");
            int opc = int.Parse(Console.ReadLine());
            return opc;


        }
    }
}