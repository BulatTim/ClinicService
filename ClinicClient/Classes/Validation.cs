using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicClient.Classes
{
    public static class Validation
    {
        public static int ValidateInput(int min, int max)
        {
            
            if (min > max)
                throw new ArgumentException(string.Format("Минимум {0} не должен быть больше максимума {1}", min, max));
            var msg = string.Format("Введенное значение должно быть от {0} до {1}", min, max);
            for (;;)
            {
                try
                {
                    Console.WriteLine("Введите значение");
                    var value = Int32.Parse(Console.ReadLine());
                    if (value > max || value < min)
                        throw new ArgumentOutOfRangeException();
                    return value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine(msg);
                    Console.WriteLine();
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine(msg);
                    Console.WriteLine();
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine(msg);
                    Console.WriteLine();
                    continue;
                }
            }
        }
        public static DateTime ValidateInput(DateTime min, DateTime max)
        {

            if (min > max)
                throw new ArgumentException(string.Format("Минимум {0} не должен быть больше максимума {1}", min, max));
            var msg = string.Format("Введенное значение должно быть от {0} до {1}", min, max);
            for (; ; )
            {
                try
                {
                    Console.WriteLine("Введите значение");
                    var value = DateTime.Parse(Console.ReadLine());
                    if (value > max || value < min)
                        throw new ArgumentOutOfRangeException();
                    return value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine(msg);
                    Console.WriteLine();
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine(msg);
                    Console.WriteLine();
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine(msg);
                    Console.WriteLine();
                    continue;
                }
            }
        }

        public static string ValidateInput(string pattern, string msg,bool isEmpty=false)
        {
            
            for (;;)
            {
                try
                {
                    var inputString = Console.ReadLine().Trim();
                    if (String.IsNullOrEmpty(inputString) && !isEmpty)
                        throw new ArgumentException();
                    if (String.IsNullOrEmpty(inputString) && isEmpty)
                    {
                        return null;
                    }
                    var match = Regex.IsMatch(inputString, pattern, RegexOptions.IgnoreCase);
                    if (match)
                        return inputString;
                    throw new ArgumentException();
                }
                catch (ArgumentException)
                {

                    Console.WriteLine(msg);
                }
            }

        }


    }
}
