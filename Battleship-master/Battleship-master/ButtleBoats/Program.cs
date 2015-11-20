using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleBoats
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new Board();
            for (var i = 0; i < 2; i++)
            {
                b.Add(new PatrolBoat(1, 1));
            }
            Console.ReadKey();
        }
    }
}
