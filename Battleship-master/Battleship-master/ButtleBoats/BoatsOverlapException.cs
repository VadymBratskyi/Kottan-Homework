using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleBoats
{
    public class BoatsOverlapException : Exception
    {
        public BoatsOverlapException()
        {
        }

        public BoatsOverlapException(string message) : base(message)
        {
        }
    }
}
