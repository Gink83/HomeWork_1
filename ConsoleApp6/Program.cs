using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 1
            //1. Дана строка символов. Необходимо проверить, является ли эта строка палиндромом.
            Console.WriteLine("Введите строку для проверки на строку-палиндром");
            string str = Console.ReadLine();
            bool isPalindrome = true;

            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                Console.WriteLine("Строка является палиндромом");
            }
            else
            {
                Console.WriteLine("Строка не является палиндромом");
            }
            #endregion
            #region 2
            //2. Написать программу, подсчитывающую количество слов, гласных и согласных букв в строке,
            //введёной пользователем. Дополнительно выводить количество знаков пунктуации, цифр и др. символов.
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            int wordCount = 0;
            int vowelCount = 0;
            int consonantCount = 0;
            int punctuationCount = 0;
            int numbersCount = 0;

            foreach (char c in input)
            {
                if (Char.IsWhiteSpace(c))
                {
                    wordCount++;
                }
                else if (Char.IsPunctuation(c))
                {
                    punctuationCount++;
                }
                else if (Char.IsNumber(c))
                {
                    numbersCount++;
                }
                else if (Char.IsLetter(c))
                {
                    if (IsVowel(c))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }

            // учитываем последнее слово после последнего разделителя
            if (!String.IsNullOrEmpty(input))
            {
                wordCount++;
            }

            Console.WriteLine("Количество слов: " + wordCount);
            Console.WriteLine("Количество гласных букв: " + vowelCount);
            Console.WriteLine("Количество согласных букв: " + consonantCount);
            Console.WriteLine("Количество цифр: " + numbersCount);
            Console.WriteLine("Количество знаков препинания: " + punctuationCount);
            Console.ReadLine();


            bool IsVowel(char c)
            {
                char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'а', 'о', 'и', 'ы', 'у', 'э' };
                return Array.IndexOf(vowels, Char.ToLower(c)) > -1;
            }

            #endregion
            #region 3
            //Написать программу, проверяющую, является ли одна строка анаграммой для другой строки
            Console.WriteLine("Введите 1/2 строку для проверки на строки-анаграммы");
            string userStr1 = Console.ReadLine();
            Console.WriteLine("Введите 2/2 строку для проверки на строки-анаграммы");
            string userStr2 = Console.ReadLine();

            if(CheckIfAnagram(userStr1, userStr2))
            {
                Console.WriteLine("строки являются анаграммами");
            }
            else
            {
                Console.WriteLine("строки не являются анаграммами");
            }
            Console.ReadLine();    

            bool CheckIfAnagram(string str1, string str2)
            {
                char[] firstArray = str1.ToLower().ToCharArray();
                char[] secondArray = str2.ToLower().ToCharArray();

                Array.Sort(firstArray);
                Array.Sort(secondArray);

                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        //отлично работает без символов. сколько не добавлял тут проверок - все равно символы не игнорирует, соответственно с ними не работает
                        if (!Char.IsSymbol(firstArray[i]) || !Char.IsPunctuation(firstArray[i]) || !Char.IsWhiteSpace(firstArray[i]) || Char.IsControl(firstArray[i]) || Char.IsSeparator(firstArray[i]))
                            return false;
                    }
                }

                return true;
            }

            #endregion
        }
    }

}
