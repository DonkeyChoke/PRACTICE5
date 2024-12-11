using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
public class MainMenu
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Лабараторная №5. Вариант 7\nГлавное меню:");
            Console.WriteLine("1. Двумерные массивы");
            Console.WriteLine("2. Рваные массивы");
            Console.WriteLine("3. Строки");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите пункт меню: ");

            string menu = Console.ReadLine();

            try
            {
                switch (menu)
                {
                    case "1":
                        Console.Clear();
                        TwoDimensionalArrayMenu();
                        break;
                    case "2":
                        Console.Clear();
                        RaggedArrayMenu();
                        break;
                    case "3":
                        Console.Clear();
                        StringMenu();
                        break;
                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nНажмите любую клавишу для выхода...");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНапишите цифру от 1 - 4.");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Произошла ошибка: {error.Message}");
            }
        }
    }

    //ДВУМЕРНЫЕ МАССИВЫ//

    static void TwoDimensionalArrayMenu()
    {
        int[,] array = null;
        while (true)
        {
            Console.WriteLine("\nМеню двумерных массивов:");
            if (array == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("1. Создать двумерный массив");
            Console.ResetColor();
            Console.WriteLine("2. Заполнить массив случайными числами");
            Console.WriteLine("3. Заполнить массив вручную");
            Console.WriteLine("4. Вывести массив");
            Console.WriteLine("5. Добавить K строк в конец матрицы");
            Console.WriteLine("6. Выйти в главное меню");
            Console.Write("Введите номер задания: ");

            string window = Console.ReadLine();

            try
            {
                switch (window)
                {
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        array = CreateArray();
                        Console.WriteLine("Двумерный массив создан.");
                        Console.ResetColor();
                        break;
                    case "2":
                        if (array == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Сначала создайте массив.");
                            Console.ResetColor();
                        }
                        else
                        {
                            FillArrayRandom(array);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Массив заполнен случайными числами.");
                            Console.ResetColor();
                        }
                        break;
                    case "3":
                        if (array == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Сначала создайте массив.");
                            Console.ResetColor();
                        }
                        else
                        {
                            FillArrayManual(array);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Массив заполнен вручную.");
                            Console.ResetColor();
                        }
                        break;
                    case "4":
                        PrintArray(array);
                        break;
                    case "5":
                        if (array == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Сначала создайте массив.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Clear();
                            array = AddToArray(array);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Строки добавленны и заполнены.");
                            Console.ResetColor();
                            Console.WriteLine("\nВведите 4, чтобы увидеть результат.");
                        }
                        break;
                    case "6":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите цифру от 1 - 6");
                        Console.ResetColor();
                        break;
                }
            }
            catch (FormatException error)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка ввода данных: {error.Message}");
                Console.ResetColor();
            }
        }
    }

    //СОЗДАТЬ ДВУМЕРНЫЙ МАССИВ//

    static int[,] CreateArray()
    {
        bool didParse = false;
        string buffer = "";
        int length, height;
        Console.ResetColor();
        do
        {
            if (!didParse)
            {
                Console.Write("Введите количество строк: ");
                buffer = Console.ReadLine();
            }
            didParse = (int.TryParse(buffer, out length) && length > 0);
            if (!didParse)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите положительное число\n");
                Console.ResetColor();
            }
        } while (!didParse);
        didParse = false;
        do
        {
            if (!didParse)
            {
                Console.Write("Введите количество столбов: ");
                buffer = Console.ReadLine();
            }
            didParse = (int.TryParse(buffer, out height) && height > 0);
            if (!didParse)
            {
                Console.Clear();
                Console.WriteLine("\nВведите положительное число");
            }
        } while (!didParse);
        didParse = false;
        Console.Clear();
        return new int[length, height];
    }

    //ЗАПОЛНИТЬ ДВУМЕРНЫЙ МАССИВ РАНДОМНЫМИ ЧИСЛАМИ//

    static void FillArrayRandom(int[,] array)
    {
        Console.ResetColor();
        Random random = new Random();
        int lenght = array.GetLength(0);
        int height = array.GetLength(1);
        for (int i = 0; i < lenght; i++)
        {
            for (int j = 0; j < height; j++)
            {
                array[i, j] = random.Next(-100, 100);
            }
        }
    }

    //ЗАПОЛНИТЬ ДВУМЕРНЫЙ МАССИВ САМОМУ//

    static void FillArrayManual(int[,] array)
    {
        bool didParse = false;
        string buffer = "";
        Console.ResetColor();
        int length = array.GetLength(0);
        int height = array.GetLength(1);
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Console.Clear();
                do
                {
                    if (!didParse)
                    {
                        Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                        buffer = Console.ReadLine();
                    }
                    didParse = (int.TryParse(buffer, out array[i, j]));
                    if (!didParse)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите число!\n");
                        Console.ResetColor();
                    }
                } while (!didParse);
                didParse = false;
            }
        }
    }

    //ВЫВЕСТИ ДВУМЕРНЫЙ МАССИВ//

    static void PrintArray(int[,] array)
    {
        Console.ResetColor();
        if (array == null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Массив не создан.");
            Console.ResetColor();
            return;
        }
        int lenght = array.GetLength(0);
        int height = array.GetLength(1);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Массив:");
        Console.ResetColor();
        for (int i = 0; i < lenght; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Console.Write($"{array[i, j],4} ");
            }
            Console.WriteLine();
        }
    }

    //ДОБАВИТЬ СТРОКИ В ДВУМЕРНЫЙ  МАССИВ//

    static int[,] AddToArray(int[,] array)
    {
        bool didParse = false;
        string buffer = "";
        int k; 
        Console.Clear();
        Console.ResetColor();
        Console.WriteLine("Введите значение K: ");
        do
        {
            if (!didParse)
            {
                Console.WriteLine("Введите значение K: ");
                buffer = Console.ReadLine();
            }
            didParse = (int.TryParse(buffer, out k) && k>0);
            if (!didParse)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите положительное число!\n");
                Console.ResetColor();
            }
        } while (!didParse);
        didParse = false;
        Random random = new Random();
        int length = array.GetLength(0);
        int height = array.GetLength(1);
        int[,] newArray = new int[length + k, height];
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                newArray[i, j] = array[i, j];
            }
        }
        for (int i = length; i < length + k; i++)
        {
            for (int j = 0; j < height; j++)
            {
                newArray[i, j] = random.Next(-100, 100);
            }
        }
        array = new int[length + k, height];
        for (int i = 0; i < length + k; i++)
        {
            for (int j = 0; j < height; j++)
            {
                array[i, j] = newArray[i, j];
            }
        }
        return (array);
    }

    //РВАНЫЕ МАССИВЫ//

    static void RaggedArrayMenu()
    {
        int[][] RaggedArray = null;

        while (true)
        {
            Console.WriteLine("\nМеню рваных массивов:");
            if (RaggedArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("1. Создать рваный массив");
            Console.ResetColor();
            Console.WriteLine("2. Заполнить массив случайными числами");
            Console.WriteLine("3. Заполнить массив вручную");
            Console.WriteLine("4. Вывести массив");
            Console.WriteLine("5. Удалить первую строку с нулями");
            Console.WriteLine("6. Выйти в главное меню");
            Console.Write("Введите номер задания: ");

            string window = Console.ReadLine();

            try
            {
                switch (window)
                {
                    case "1":
                        RaggedArray = CreateRaggedArray();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Рваный массив создан.");
                        Console.ResetColor();
                        break;
                    case "2":
                        if (RaggedArray == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Сначала создайте массив.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Clear();
                            FillRaggedArrayRandom(RaggedArray);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Массив заполнен случайными числами.");
                            Console.ResetColor();
                        }
                        break;
                    case "3":
                        if (RaggedArray == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Сначала создайте массив.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            FillRaggedArrayManual(RaggedArray);
                            Console.WriteLine("Массив заполнен вручную.");
                            Console.ResetColor();
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Ваш массив: \n");
                        PrintRaggedArray(RaggedArray);
                        Console.ResetColor();
                        break;
                    case "5":
                        if (RaggedArray == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Сначала создайте массив.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            RaggedArray = RemoveFirstRowWithZeros(RaggedArray);
                            Console.WriteLine("Первая строка с нулями удалена (если была).");
                            Console.ResetColor();
                        }
                        break;
                    case "6":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите цифру од 1 до 6");
                        Console.ResetColor();
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка ввода данных: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }

    //СОЗДАТЬ РВАНЫЙ МАССИВ//

    static int[][] CreateRaggedArray()
    {
        bool didParse = false;
        string buffer = "";
        int length, height, count=1;
        Console.Clear();
        do
        {
            if (!didParse)
            {
                Console.Write("Введите количество строк: ");
                buffer = Console.ReadLine();
            }
            didParse = (int.TryParse(buffer, out length) && length > 0);
            if (!didParse)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите положительное число!\n");
                Console.ResetColor();
            }
        } while (!didParse);
        int[][] RaggedArray = new int[length][];
        for (int i = 0; i < length; i++)
        {
            Console.Clear();
            didParse = false;
            do
            {
                if (!didParse)
                {
                    Console.Write($"Введите количество столбов в строке {count}: ");
                    buffer = Console.ReadLine();
                }
                didParse = (int.TryParse(buffer, out height) && height > 0);
                count++;
                if (!didParse)
                {
                    Console.Clear();
                    Console.WriteLine("\nВведите положительное число");
                }
            } while (!didParse);
            RaggedArray[i] = new int[height];
        }
        return RaggedArray;
    }

    //ЗАПОЛНИТЬ РВАНЫЙ МАССИВ РАНДОМОМ//

    static void FillRaggedArrayRandom(int[][] RaggedArray)
    {
        Console.Clear();
        Random random = new Random();
        for (int i = 0; i < RaggedArray.Length; i++)
        {
            for (int j = 0; j < RaggedArray[i].Length; j++)
            {
                RaggedArray[i][j] = random.Next(-100, 100);
            }
        }
    }

    //ЗАПОЛНИТЬ РВАНЫЙ МАССИВ САМОМУ//

    static void FillRaggedArrayManual(int[][] RaggedArray)
    {
        Console.ResetColor();
        bool didParse = false;
        string buffer = "";
        for (int i = 0; i < RaggedArray.Length; i++)
        {
            for (int j = 0; j < RaggedArray[i].Length; j++)
            {
                Console.Clear();
                do
                {
                    if (!didParse)
                    {
                        Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                        buffer = Console.ReadLine();
                    }
                    didParse = (int.TryParse(buffer, out RaggedArray[i][j]));
                    if (!didParse)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите число!\n");
                        Console.ResetColor();
                    }
                } while (!didParse);
            }
        }
    }

    //УДАЛИТЬ ПЕРВУЮ СТРОКУ С НУЛЯМИ//

    static int[][] RemoveFirstRowWithZeros(int[][] RaggedArray)
    {
        for (int i = 0; i < RaggedArray.Length; i++)
        {
            bool isZero = false;
            foreach (int num in RaggedArray[i])
            {
                if (num == 0)
                {
                    isZero = true;
                    break;
                }
            }
            if (isZero)
            {
                int[][] newArray = new int[RaggedArray.Length - 1][];
                for (int j = 0; j < i; j++)
                {
                    newArray[j] = RaggedArray[j];
                }
                for (int j = i + 1; j < RaggedArray.Length; j++)
                {
                    newArray[j - 1] = RaggedArray[j];
                }
                return newArray;
            }
        }
        return RaggedArray;
    }

    //ВЫВЕСТИ РВАНЫЙ МАССИВ//

    static void PrintRaggedArray(int[][] RaggedArray)
    {
        Console.ResetColor();
        if (RaggedArray == null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Сначало создайте массив.");
            Console.ResetColor();
            return;
        }
        for (int i = 0; i < RaggedArray.Length; i++)
        {
            Console.Write($"Строка {i + 1}: [");
            for (int j = 0; j < RaggedArray[i].Length; j++)
            {
                Console.Write(RaggedArray[i][j]);
                if (j < RaggedArray[i].Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }

    //СТРОКИ//

    static void StringMenu()
    {
        string inputString = null;
        {
            while (true)
            {
                Console.WriteLine("\nМеню строк:");
                if (inputString == null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("1. Ввести строку");
                Console.ResetColor();
                Console.WriteLine("2. Обработать строку (циклический сдвиг влево)");
                Console.WriteLine("3. Вывести строку");
                Console.WriteLine("4. Выйти в общее меню");
                Console.Write("Введите номер задания: ");

                string window = Console.ReadLine();

                try
                {
                    switch (window)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Введите строку слов, разделяя их знаками препинания, (, ; :) - чтобы разделить слова, (! . ?) - чтобы разделить предложения.\n");
                            Console.WriteLine("Введите строку:");
                            inputString = Console.ReadLine();
                            break;
                        case "2":
                            if (inputString == null || inputString == "") 
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Сначала введите строку.");
                                Console.ResetColor();
                            }
                            else
                            {
                                string processedString = ProcessString(inputString);
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nОбработанная строка:");
                                Console.ResetColor();
                                Console.WriteLine(processedString);
                            }
                            break;
                        case "3":
                            if (inputString == null || inputString == "")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Сначала введите строку.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nВаша строка:");
                                printString();
                                Console.ResetColor();
                            }
                            break;
                        case "4":
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ведите цифру от 1 до 3");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите текст!");
                    Console.ResetColor();
                }
                catch (Exception error)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Произошла ошибка: {error.Message}");
                    Console.ResetColor();
                }
            }
        }

        // ОБРАБОТКА СТРОКИ //
        static string ProcessString(string inputString)
        {
            string[] sentences = Regex.Split(inputString, @"(?<=[.!?])\s*");
            string result = "";
            foreach (string sentence in sentences)
            {
                result += ProcessSentence(sentence) + " ";
            }
            return result.Trim();
        }

        static string ProcessSentence(string sentence)
        {
            string punctuation = "";
            if (sentence.Length > 0 && char.IsPunctuation(sentence[sentence.Length - 1])) 
            {
                punctuation = sentence.Substring(sentence.Length - 1);
                sentence = sentence.Substring(0, sentence.Length - 1);
            }
            string[] parts = Regex.Split(sentence, @"(\s*[,;:]+\s*)"); 
            string processedSentence = "";
            int wordIndex = 0;
            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i].Trim();
                if (part.Length > 0)
                {
                    if (Regex.IsMatch(part, @"^[,;:]+$")) 
                    {
                        processedSentence += part;
                    }
                    else
                    {
                        string shiftedWord = ShiftWord(part, wordIndex + 1);
                        processedSentence += shiftedWord;
                        wordIndex++;
                    }
                    if (i < parts.Length - 1)
                    { 
                        processedSentence += parts[i + 1].Trim().Length == 0 ? "" : parts[i + 1].Trim().Length > 0 && Regex.IsMatch(parts[i + 1].Trim(), @"^[,;:]+$") ? "" : " ";
                    }
                }
            }
            return processedSentence.TrimEnd() + punctuation;
        }
        static string ShiftWord(string word, int shift)
        {
            shift %= word.Length;
            return word.Substring(shift) + word.Substring(0, shift);
        }
        static void printString()
        {
            Console.WriteLine($"{inputString}");
        }
    }
}