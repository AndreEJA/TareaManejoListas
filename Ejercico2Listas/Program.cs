using System;
using static System.Console;

class Cuenta
{
    private decimal balance;

    public Cuenta(decimal saldoInicial)
    {
        balance = saldoInicial;
    }

    public void MostrarSaldo()
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"\nEl saldo actual es: {balance:C}\n");
        ResetColor();
        WriteLine("Presione cualquier tecla para continuar");
        ReadKey();
        Clear();
    }

    public void AgregarFondos(decimal monto)
    {
        if (monto <= 0)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nLa cantidad a agregar debe ser positiva.\n");
            ResetColor();
            WriteLine("Presione cualquier tecla para continuar");
            ReadKey();
            Clear() ;
            return;
        }

        balance += monto;
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"\nSe han agregado {monto:C}. Saldo actualizado: {balance:C}\n");
        ResetColor();
        WriteLine("Presione cualquier tecla para continuar");
        ReadKey();
        Clear();

    }

    public void RetirarFondos(decimal monto)
    {
        if (monto <= 0)
        {
            ForegroundColor= ConsoleColor.Red;
            WriteLine("\nLa cantidad a retirar debe ser positiva.\n");
            ResetColor();
            WriteLine("Presione cualquier tecla para continuar");
            ReadKey();
            Clear ();
            return;
        }

        if (monto > balance)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nNo hay suficiente saldo para realizar este retiro.\n");
            ResetColor();
            WriteLine("Presione cualquier tecla para continuar");
            ReadKey();
            Clear () ;
        }
        else
        {
            balance -= monto;
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"\nSe han retirado {monto:C}. Saldo restante: {balance:C}\n");
            ResetColor();
            WriteLine("Presione cualquier tecla para continuar");
            ReadKey();
            Clear ();
        }
    }
}

class GestorCuenta
{
    static void Main(string[] args)
    {
        int eleccion;
        Cuenta miCuenta = new Cuenta(1000);

        do
        {
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("\n██████╗  █████╗ ███╗   ██╗ ██████╗ ██████╗     ▄▄███▄▄·");
            WriteLine("██╔══██╗██╔══██╗████╗  ██║██╔════╝██╔═══██╗    ██╔════╝");
            WriteLine("██████╔╝███████║██╔██╗ ██║██║     ██║   ██║    ███████╗");
            WriteLine("██╔══██╗██╔══██║██║╚██╗██║██║     ██║   ██║    ╚════██║");
            WriteLine("██████╔╝██║  ██║██║ ╚████║╚██████╗╚██████╔╝    ███████║");
            WriteLine("╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═════╝     ╚═▀▀▀══╝");
            ResetColor() ;
                                                       
            WriteLine("1. Ver saldo");
            WriteLine("2. Depositar dinero");
            WriteLine("3. Retirar dinero");
            WriteLine("4. Salir");
            Write("Seleccione una opción: ");

            if (int.TryParse(ReadLine(), out eleccion))
            {
                switch (eleccion)
                {
                    case 1:
                        miCuenta.MostrarSaldo();
                        break;
                    case 2:
                        Write("\nIngrese la cantidad a depositar: ");
                        if (decimal.TryParse(ReadLine(), out decimal deposito))
                        {
                            miCuenta.AgregarFondos(deposito);
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("\nCantidad no válida.\n");
                            ResetColor();
                            WriteLine("Presione cualquier tecla para continuar");
                            ReadKey();
                            Clear();
                        }
                        break;
                    case 3:
                        Write("\nIngrese la cantidad a retirar: ");
                        if (decimal.TryParse(ReadLine(), out decimal retiro))
                        {
                            miCuenta.RetirarFondos(retiro);
                        }
                        else
                        {
                            ForegroundColor= ConsoleColor.Red;
                            WriteLine("\nCantidad no válida.\n");
                            ResetColor();
                            WriteLine("Presione cualquier tecla para continuar");
                            ReadKey();
                            Clear();
                        }
                        break;
                    case 4:
                        WriteLine("Saliendo del programa. Gracias por usar el sistema.");
                        break;
                    default:
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Opción no reconocida. Por favor, intente de nuevo.");
                        ResetColor();
                        ReadKey();
                        Clear();
                        break;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Entrada no válida. Por favor ingrese un número.");
                ResetColor();
                ReadKey();
                Clear ();
            }
        } while (eleccion != 4);
    }
}
