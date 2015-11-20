using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleBoats
{
    public class NotABoatException : Exception
    {
        public NotABoatException()
        {
        }

        public NotABoatException(string message):base(message)
        {
        }
    }
}
