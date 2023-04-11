using System.Threading.Tasks;

namespace Ejercicio4
{
    class Ejercicio4
    {
        static void Main(string[] args)
        {
            int sizeOfArray = AskSizeOfArrray();
            float[] arrayOfFloats = CreateArray(sizeOfArray);
            TryToGuest(arrayOfFloats);
        }

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

        private static void TryToGuest(float[] arrayOfFloats)
        {

            Console.Clear();

            bool isCorrect = false;

            int attempts = 4;

            while (!isCorrect && attempts > 0)
            {
                Console.WriteLine($"Tiene {attempts} intentos.");

                Console.Write("\nIntroduzca un número decimal: ");

                string floatNumberString = Console.ReadLine();

                float floatNumber;

                bool isFloat = false;

                while (!isFloat)
                {
                    if (float.TryParse(floatNumberString, out floatNumber))
                    {

                        if (arrayOfFloats.Contains(floatNumber))
                        {
                            Console.WriteLine("\n¡Ha acertado! Ha adivinado el número.");
                            isCorrect = true;

                        }
                        else
                        {
                            Console.WriteLine("\nNo ha acertado el número.");

                            var maxFloat = 0f;
                            var minFloat = 100f;

                            foreach (var f in arrayOfFloats)
                            {
                                if (f < minFloat && f > maxFloat)
                                {
                                    maxFloat = (f + 0.5f);
                                    minFloat = (f - 0.5f);
                                }
                                else if ((f < minFloat) && !(f > maxFloat))
                                {
                                    minFloat = f - 0.5f;
                                }
                                else if (!(f < minFloat) && (f > maxFloat))
                                {
                                    maxFloat = f + 0.5f;
                                }
                            }

                            Console.WriteLine($"\nEl número se encuentra entre {minFloat} y {maxFloat}");

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