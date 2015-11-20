using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleBoats
{
    public class PatrolBoat : Boats
    {
        public PatrolBoat(uint x, uint y) : base(x,y)
        {
        }
        public PatrolBoat(uint x, uint y, Direction direction) : base(x,y,1,direction)
        {
        }
        public PatrolBoat(uint x, uint y, uint length, Direction direction) : base(x, y, length, direction)
        {
        }
        public override bool Equals(object obj)
        {
            var pb = obj as PatrolBoat;
            return pb?.X == X && pb.Y == Y;
        }
    }
}
