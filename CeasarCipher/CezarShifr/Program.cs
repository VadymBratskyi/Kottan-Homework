using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nunit.Framework.TestCaseStorage;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CezarShifr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество преходов: ");
            var i = Console.ReadLine();

            if (i == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                CeasarCipher shifr = new CeasarCipher(Convert.ToInt32(i));

                Console.Write("Введите слово для зашифровки: ");
                var txt = Console.ReadLine();
                Console.WriteLine($"Зашифровано: {shifr.Encrypt(txt)}");
                var txt2 = shifr.Encrypt(txt);
                Console.WriteLine($"Разшифровано: {shifr.Decrypt((txt2))}");
            }

            Console.ReadLine();
        }
    }
}
