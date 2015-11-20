using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleBoats
{
    public class AircraftCarrier : Boats
    {
        public AircraftCarrier(uint x, uint y) : base(x, y)
        {
        }

        public AircraftCarrier(uint x, uint y, Direction direction) : base(x, y,4, direction)
        {

        }
        public AircraftCarrier(uint x, uint y, uint length, Direction direction) : base(x, y, length, direction)
        {

        }

    }
}
