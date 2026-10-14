//*******************************************************************************************************************
//* Практическая_12                                                                                                 *
//* Выполнила: Абдурахманова Х.Р., группа 2ИСП                                                                      *
//* Задание: Функции. Сравнить шаблон с пользовательским текстом.                                                   *
//*******************************************************************************************************************
using System;

namespace Pr12
{
    internal class Program
    {
        static string HandleError(Exception ex) //вывод сообщения об ошибке
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: " + ex.Message);
            Console.ForegroundColor = ConsoleColor.Blue;
            return "Error";
        }
        static string Checking(string a) //проверка соответствия введенного пользователем значения
        {
            while (String.IsNullOrWhiteSpace(a)) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели число или пустую строку, а нужен текст!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Попробуйте еще раз: ");
                a = Console.ReadLine();
            }
            return "Error";
        }
        static bool Comparison(char[] templateArray, char[] textArray) //сравнение шаблона с пользовательским текстом
        {
            if (templateArray.Length != textArray.Length)
            {
                return false;
            }
            for (int i = 0; i < templateArray.Length; i++)
            {
                if (templateArray[i] != '?' && templateArray[i] != textArray[i])
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                string repeatAnswer;
                Console.Write("Здравствуйте! ");
                do
                {
                    Console.Write("Введите шаблон: ");
                    string template = Console.ReadLine();
                    Checking(template);
                    char[] templateArray = template.ToCharArray();

                    Console.Write("Введите текст, соответствие которого с шаблоном нужно проверить: ");
                    string text = Console.ReadLine();
                    Checking(text); 
                    char[] textArray = text.ToCharArray();

                    bool compare = Comparison(templateArray, textArray);
                    if (compare == true) Console.WriteLine("Совпадение!");
                    else Console.WriteLine("Нет совпадения :(");

                    Console.WriteLine("Введите 'да' если хотите повторить программу, иначе - 'нет'. ");
                    repeatAnswer = Console.ReadLine();
                    repeatAnswer = repeatAnswer.ToLower();
                    while ((repeatAnswer != "да") && (repeatAnswer != "нет"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неподходящее значение.");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Попробуйте еще раз: ");
                        repeatAnswer = Console.ReadLine();
                    }
                    if (repeatAnswer == "нет")
                    {
                        Console.Write("До свидания!");
                    }
                }
                while (repeatAnswer == "да");
                Console.ReadKey();
            }
            catch (FormatException fex)
            {
                HandleError(fex);
            }
            catch (StackOverflowException sofex)
            {
                HandleError(sofex);
            }
            catch (IndexOutOfRangeException ioorex)
            {
                HandleError(ioorex);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

        }
    }
}
