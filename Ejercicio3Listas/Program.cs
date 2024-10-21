using static System.Console;
namespace DiccionarioT
{
    public class DiccionarioT
    {
        static void Main(string[] args)
        {
            List<Tuple<string, string>> diccionario = crearDiccionario();
            traducir(diccionario);
        }

        public static List<Tuple<string, string>> crearDiccionario()
        {
            List<Tuple<string, string>> diccionario = new List<Tuple<string, string>>();
            for (int i = 0; i < 5; i++)
            {
                WriteLine($"Introduzca la palabra {i + 1} en ingles: ");
                string palabra1 = ReadLine();
                WriteLine($"Introduzca la palabra {i + 1} en español: ");
                string palabra2 = ReadLine();
                diccionario.Add(new Tuple<string, string>(palabra1, palabra2));
            }
            return diccionario;
        }
        public static void traducir(List<Tuple<string, string>> diccionario)
        {
            Write("Introduzca la palabra a traducir \n");
            string palcomp = ReadLine();
            bool encontrado = false;
            foreach (var duo in diccionario)
            {
                if (duo.Item1.Equals(palcomp, StringComparison.OrdinalIgnoreCase))
                {
                    Write($"La traducción de la palabra {palcomp} es: {duo.Item2}");
                    encontrado = true;
                    break;
                }
                else if (duo.Item2.Equals(palcomp, StringComparison.OrdinalIgnoreCase))
                {
                    Write($"La traducción de la palabra {palcomp} es: {duo.Item1}");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Write("La palabra no esta en el diccionario");
            }
        }
    }
}

