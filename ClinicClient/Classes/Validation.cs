using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
           for (; ; )
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
      


    }
}
