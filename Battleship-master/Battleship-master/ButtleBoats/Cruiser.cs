using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleBoats
{
    public class Cruiser : Boats
    {
        public Cruiser(uint x, uint y) : base(x,y)
        {
        }
        public Cruiser(uint x, uint y,Direction direction) : base(x,y,2,direction)
        {
        }
        public Cruiser(uint x, uint y, uint length, Direction direction) : base(x, y, length, direction)
        {
        }

    }
}
