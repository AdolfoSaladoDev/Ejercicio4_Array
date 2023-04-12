using System.Threading.Tasks;

namespace Ejercicio4
{
    class Ejercicio4
    {
        // Guardarán los valores máximos y mínimo del array.
        private static float maxNumber;
        private static float minNumber;

        static void Main(string[] args)
        {
            int sizeOfArray = AskSizeOfArrray();
            float[] arrayOfFloats = CreateArray(sizeOfArray);
            TryToGuest(arrayOfFloats);
        }

        /// <summary>
        /// Método encargado de solicitar el tamaño del array. 
        /// </summary>
        /// <returns>Número de elementos que contendrá el array.</returns>
        private static int AskSizeOfArrray()
        {
            int sizeOfArray = 0;
            bool isCorrect = false;

            while (!isCorrect)
            {
                Console.Write("Introduzca el tamaño que tendrá el array: ");
                string numberUserString = Console.ReadLine();

                if (int.TryParse(numberUserString, out sizeOfArray))
                {
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("No ha introducido un número válido.");
                }
            }

            return sizeOfArray;
        }

        /// <summary>
        /// Método encargado de crear el array de números decimales.
        /// </summary>
        /// <param name="sizeOfArray">Tamaño que tendrá el array</param>
        /// <returns>Array de números decimales.</returns>
        private static float[] CreateArray(int sizeOfArray)
        {
            List<float> floatList = new List<float>();

            while (floatList.Count < sizeOfArray)
            {
                float floatNumber;

                Console.Write("\nIntroduce un número decimal: ");
                string floatNumberString = Console.ReadLine();

                if (float.TryParse(floatNumberString, out floatNumber))
                {
                    floatList.Add(floatNumber);

                    Console.WriteLine("\nNúmero introducido correctamente.");
                }
                else
                {
                    Console.WriteLine("\nNo ha introducido un número válido. Debe ser un número decimal.");
                }
            }


            return floatList.ToArray();
        }

        /// <summary>
        /// Método que ejecuta la lógica del juego.
        /// El usuario tendrá cuatro intentos para adivinar un número que se encuentra en el array.
        /// </summary>
        /// <param name="arrayOfFloats">Array de números decimales.</param>
        private static void TryToGuest(float[] arrayOfFloats)
        {
            Console.Clear();

            bool isCorrect = false;

            maxNumber = arrayOfFloats.Max() - 10;
            minNumber = arrayOfFloats.Min() - 10;

            int attempts = 4;

            while (!isCorrect && attempts > 0)
            {
                Console.WriteLine($"Tiene {attempts} intentos.");

                Console.Write("\nIntroduzca un número decimal: ");

                string floatNumberString = Console.ReadLine();

                bool isFloat = false;

                while (!isFloat)
                {
                    if (float.TryParse(floatNumberString, out float floatNumber))
                    {

                        if (arrayOfFloats.Contains(floatNumber))
                        {
                            Console.WriteLine("\n¡Ha acertado! Ha adivinado el número.");
                            isCorrect = true;

                        }
                        else
                        {
                            Console.WriteLine("\nNo ha acertado el número.");

                            Console.WriteLine($"\nEl número se encuentra entre {minNumber} y {maxNumber}");
                        }

                        attempts--;
                        isFloat = true;

                    }
                    else
                    {
                        Console.WriteLine("No ha introducido un número decimal. Vuelva a intentarlo.");
                    }
                }
            }
        }

    }
}