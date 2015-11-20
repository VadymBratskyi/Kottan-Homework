using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleBoats
{
    public class BoardIsNotReadyException : Exception
    {
        public BoardIsNotReadyException()
        {
        }

        public BoardIsNotReadyException(string message) : base(message)
        {
        }
    }
}
