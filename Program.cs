using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pr12
{
    internal class Program
    {
        static string HandleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: " + ex.Message);
            Console.ForegroundColor = ConsoleColor.Blue;
            return "Error";
        }
        static string Checking(string a)
        {
            while (String.IsNullOrWhiteSpace(a)) //проверка соответствия введенного пользователем значения
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели число или пустую строку, а нужен текст!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Попробуйте еще раз: ");
                a = Console.ReadLine();
            }
            return "Error";
        }
        static bool Comparison(char[] templateArray, char[] textArray, bool check)
        {
            for (int i = 0; i < textArray.Length; i++)
            {
                if (templateArray[i] == '?') check = true;
                else
                {
                    if (templateArray[i] == textArray[i]) check = true;
                }
            }
            return check;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                string repeatAnswer;
                bool check = false;
                Console.Write("Здравствуйте! ");
                do
                {
                    Console.Write("Введите шаблон: ");
                    string template = Console.ReadLine();
                    Checking(template);
                    //while (String.IsNullOrWhiteSpace(template)) //проверка соответствия введенного пользователем значения
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("Вы ввели число или пустую строку, а нужен текст!");
                    //    Console.ForegroundColor = ConsoleColor.Blue;
                    //    Console.Write("Попробуйте еще раз: ");
                    //    template = Console.ReadLine();
                    //}
                    char[] templateArray = template.ToCharArray();
                    Console.Write("Введите текст, соответствие которого с шаблоном нужно проверить: ");
                    string text = Console.ReadLine();
                    Checking(text);                    //while (String.IsNullOrWhiteSpace(text)) //проверка соответствия введенного пользователем значения
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("Вы ввели число или пустую строку, а нужен текст!");
                    //    Console.ForegroundColor = ConsoleColor.Blue;
                    //    Console.Write("Попробуйте еще раз: ");
                    //    text = Console.ReadLine();
                    //}
                    char[] textArray = text.ToCharArray();
                    Comparison(templateArray, textArray, check);
                    //for (int i = 0; i < textArray.Length; i++)
                    //{
                    //    if (templateArray[i] != '?')
                    //    {
                    //        if (templateArray[i] != textArray[i])
                    //        {
                    //            check = false;
                    //        }
                    //    }
                    //}
                    if (check == true) Console.WriteLine("Совпадение!");
                    else Console.WriteLine("Нет совпадения :(");
                    Console.WriteLine("Введите 'да' если хотите повторить программу, иначе - 'нет'. ");
                    repeatAnswer = Console.ReadLine();
                    while ((repeatAnswer != "да") && (repeatAnswer != "нет"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неподходящее значение.");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Попробуйте еще раз: ");
                        repeatAnswer = Console.ReadLine();
                    }
                    if (repeatAnswer == "нет") Console.Write("До свидания!");
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
