using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using static System.Console;

class Producto
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public Producto(int codigo, string nombre, int cantidad, decimal precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Cantidad = cantidad;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"Código: {Codigo,-5} | Nombre: {Nombre,-15} | Cantidad: {Cantidad,-5} | Precio: {Precio:C}";
    }
}

class Program
{
    static List<Producto> inventario = new List<Producto>();

    static void Main()
    {
        int opcion;
        do
        {
            WriteLine("\n██╗███╗   ██╗██╗   ██╗███████╗███╗   ██╗████████╗ █████╗ ██████╗ ██╗ ██████╗");
            WriteLine("██║████╗  ██║██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔══██╗██╔══██╗██║██╔═══██╗");
            WriteLine("██║██╔██╗ ██║██║   ██║█████╗  ██╔██╗ ██║   ██║   ███████║██████╔╝██║██║   ██║");
            WriteLine("██║██║╚██╗██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║   ██╔══██║██╔══██╗██║██║   ██║");
            WriteLine("██║██║ ╚████║ ╚████╔╝ ███████╗██║ ╚████║   ██║   ██║  ██║██║  ██║██║╚██████╔╝");
            WriteLine("╚═╝╚═╝  ╚═══╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝ ╚═════╝");
            WriteLine("1. Agregar producto");
            WriteLine("2. Eliminar producto");
            WriteLine("3. Modificar producto");
            WriteLine("4. Consultar producto");
            WriteLine("5. Mostrar todos los productos");
            WriteLine("6. Salir");
            WriteLine("============================================================");
            Write("Selecciona una opción (1-6): ");

            if (int.TryParse(ReadLine(), out opcion))
            {
                Clear();
                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;
                    case 2:
                        EliminarProducto();
                        break;
                    case 3:
                        ModificarProducto();
                        break;
                    case 4:
                        ConsultarProducto();
                        break;
                    case 5:
                        MostrarTodosLosProductos();
                        break;
                    case 6:
                        WriteLine("Saliendo del programa... ¡Hasta luego!");
                        break;
                    default:
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Opción no válida. Por favor, intenta de nuevo.");
                        ResetColor();   
                        ReadKey(true);
                        Clear();
                        break;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Entrada inválida. Por favor, ingresa un número entre 1 y 6.");
                ResetColor();
                WriteLine("Presione cualquier tecla para volver a intentar.");
                ReadKey(true);
                Clear();
            }

        } while (opcion != 6);
    }

    static void AgregarProducto()
    {
        WriteLine("========= AGREGAR PRODUCTO =========");
        Write("Código: ");
        int codigo = int.Parse(ReadLine());
        Write("Nombre: ");
        string nombre = ReadLine();
        Write("Cantidad: ");
        int cantidad = int.Parse(ReadLine());
        Write("Precio: ");
        decimal precio = decimal.Parse(ReadLine());

        inventario.Add(new Producto(codigo, nombre, cantidad, precio));
        ForegroundColor = ConsoleColor.Green;
        WriteLine("\nProducto agregado exitosamente.");
        ResetColor();
        WriteLine("\nPresione cualquier tecla para volver al menu principal.");
        ReadKey(true);
        Clear();
    }

    static void EliminarProducto()
    {
        WriteLine("========= ELIMINAR PRODUCTO =========");
        Write("Ingrese el código del producto a eliminar: ");
        int codigo = int.Parse(ReadLine());

        Producto productoAEliminar = inventario.Find(p => p.Codigo == codigo);

        if (productoAEliminar != null)
        {
            inventario.Remove(productoAEliminar);
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\nProducto eliminado.");
            ResetColor();
            WriteLine("\nPresione cualquier tecla para volver al menu principal.");
            ReadKey(true);
            Clear();
        }
        else
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nProducto no encontrado.");
            ResetColor();
            WriteLine("\nPresione cualquier tecla para volver al menu principal.");
            ReadKey(true);
            Clear();
        }
    }

    static void ModificarProducto()
    {
        WriteLine("========= MODIFICAR PRODUCTO =========");
        Write("Ingrese el código del producto a modificar: ");
        int codigo = int.Parse(ReadLine());

        Producto productoAModificar = inventario.Find(p => p.Codigo == codigo);

        if (productoAModificar != null)
        {
            Write("Nuevo nombre (dejar vacío para no modificar): ");
            string nuevoNombre = ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                productoAModificar.Nombre = nuevoNombre;
            }

            Write("Nueva cantidad (dejar vacío para no modificar): ");
            string nuevaCantidadStr = ReadLine();
            if (!string.IsNullOrEmpty(nuevaCantidadStr))
            {
                productoAModificar.Cantidad = int.Parse(nuevaCantidadStr);
            }

            Write("Nuevo precio (dejar vacío para no modificar): ");
            string nuevoPrecioStr = ReadLine();
            if (!string.IsNullOrEmpty(nuevoPrecioStr))
            {
                productoAModificar.Precio = decimal.Parse(nuevoPrecioStr);
            }
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\nProducto modificado.");
            ResetColor();
            WriteLine("\nPresione cualquier tecla para volver al menu principal.");
            ReadKey(true);
            Clear();
        }
        else
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nProducto no encontrado.");
            ResetColor();
            WriteLine("\nPresione cualquier tecla para volver al menu principal.");
            ReadKey(true);
            Clear();
        }
    }

    static void ConsultarProducto()
    {
        WriteLine("========= CONSULTAR PRODUCTO =========");
        Write("Ingrese el código del producto: ");
        int codigo = int.Parse(ReadLine());

        Producto productoAConsultar = inventario.Find(p => p.Codigo == codigo);

        if (productoAConsultar != null)
        {
            WriteLine("\n--- Información del producto ---");
            WriteLine(productoAConsultar);
            WriteLine("\nPresione cualquier tecla para volver al menu principal.");
            ReadKey(true);
            Clear();
        }

        else
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nProducto no encontrado.");
            ResetColor();
            WriteLine("\nPresione cualquier tecla para volver al menu principal.");
            ReadKey(true);
            Clear();
        }
    }

    static void MostrarTodosLosProductos()
    {
        WriteLine("========= TODOS LOS PRODUCTOS =========");
        if (inventario.Count > 0)
        {
            WriteLine("\n--- Inventario Actual ---");
            foreach (var producto in inventario)
            {
                WriteLine(producto);
            }
            WriteLine("\nPresione cualquier tecla para volver al menu principal.");
            ReadKey(true);
            Clear();
        }
        else
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nEl inventario está vacío.");
            ResetColor();
            WriteLine("\nPresione cualquier tecla para volver al menu principal.");
            ReadKey(true);
            Clear();
        }
    }
}
